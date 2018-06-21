import {
  forceCenter,
  forceLink,
  forceManyBody,
  forceSimulation,
  Simulation,
  SimulationLinkDatum,
  SimulationNodeDatum
} from "d3-force-3d";
import { throttle } from "lodash";
import * as React from "react";
import {
  AmbientLight,
  BufferAttribute,
  BufferGeometry,
  Float32BufferAttribute,
  GridHelper,
  Line,
  LineBasicMaterial,
  Mesh,
  MeshBasicMaterial,
  MeshLambertMaterial,
  MeshNormalMaterial,
  MeshPhongMaterial,
  OrbitControls,
  PerspectiveCamera,
  PlaneBufferGeometry,
  Renderer,
  Scene,
  ShadowMaterial,
  Sphere,
  SphereBufferGeometry,
  SphereGeometry,
  SpotLight,
  SpotLightShadow,
  TrackballControls as TrackballControlsType,
  Vector3,
  VectorKeyframeTrack,
  VertexColors,
  VRControls,
  WebGLRenderer
} from "three";
import DragControls from "three-dragcontrols";
import { ForceGraphElement, ForceGraphLink, ForceGraphNode } from "./domain";
import "./styles.scss";
import MyWorker from "./webworker";
import {
  EVENT_TYPE,
  EventData,
  NewSimulationResponse,
  NodePositionsUpdated,
  POSITIONS_ARRAY_INDICES,
  UpdateGraphDataResponse
} from "./webworker/types";

const TrackballControls: any = require("three-trackballcontrols");

export interface Props {
  id: string;
  width: number;
  height: number;
  nodes: ForceGraphNode[];
  links: ForceGraphLink[];
}

export interface State {
  needsUpdate: boolean;
  nodes: Map<string, ForceGraphNode>;
  links: Map<string, ForceGraphLink>;
  addedNodes: Map<string, ForceGraphNode>;
  addedLinks: Map<string, ForceGraphLink>;
  removedNodes: Set<string>;
  removedLinks: Set<string>;
}

type NodePair = [ForceGraphNode, ForceGraphNode];

export default class ForceGraph extends React.PureComponent<Props, State> {
  public static getDerivedStateFromProps(
    nextProps: Props,
    prevState: State
  ): State {
    const nodes = new Map<string, ForceGraphNode>(
      nextProps.nodes.map(n => [n.id, n] as [string, ForceGraphNode])
    );
    const links = new Map<string, ForceGraphLink>(
      nextProps.links.map(l => [l.id, l] as [string, ForceGraphLink])
    );
    return ForceGraph.calculateStateFromPropChanges(prevState, nodes, links);
  }
  private static calculateStateFromPropChanges(
    prev: State,
    nodes: Map<string, ForceGraphNode>,
    links: Map<string, ForceGraphLink>
  ): State {
    const addedNodes = new Map<string, ForceGraphNode>();
    const addedLinks = new Map<string, ForceGraphLink>();
    const removedNodes: Set<string> = new Set<string>();
    const removedLinks: Set<string> = new Set<string>();
    const nextNodes = new Map<string, ForceGraphNode>();
    const nextLinks = new Map<string, ForceGraphLink>();
    nodes.forEach(e => {
      // node not in prev.nodes -> added
      if (!prev.nodes.has(e.id)) {
        addedNodes.set(e.id, e);
        nextNodes.set(e.id, e);
        return;
      }
      // node in prev.nodes -> existing
      nextNodes.set(e.id, e);
    });
    prev.nodes.forEach((e, i) => {
      if (!nodes.has(e.id)) {
        removedNodes.add(e.id);
      }
    });

    links.forEach(e => {
      // node not in prev.nodes -> added
      if (!prev.links.has(e.id)) {
        addedLinks.set(e.id, e);
        nextLinks.set(e.id, e);
        return;
      }
      // node in prev.nodes -> existing
      nextLinks.set(e.id, e);
    });
    prev.links.forEach((e, i) => {
      if (!links.has(e.id)) {
        removedNodes.add(e.id);
      }
    });

    return {
      addedLinks,
      addedNodes,
      links: nextLinks,
      needsUpdate: true,
      nodes: nextNodes,
      removedLinks,
      removedNodes
    };
  }
  public state: State = {
    addedLinks: new Map<string, ForceGraphLink>(),
    addedNodes: new Map<string, ForceGraphNode>(),
    links: new Map<string, ForceGraphLink>(),
    needsUpdate: true,
    nodes: new Map<string, ForceGraphNode>(),
    removedLinks: new Set<string>(),
    removedNodes: new Set<string>()
  };
  private spotlight: SpotLight;
  private webWorker: Worker;
  private containerDiv: HTMLDivElement;
  private currentNodePositions: NodePositionsUpdated;
  private currentLinks: Map<string, ForceGraphLink> = new Map<
    string,
    ForceGraphLink
  >();
  private scene: Scene = new Scene();
  private camera: PerspectiveCamera;
  private renderer: WebGLRenderer;
  private spheres = new Map<string, Mesh>();
  private lines = new Map<string, Line>();
  private trackballControls: TrackballControlsType;
  private dragControls: DragControls;
  private renderedNode: React.ReactNode = null;
  private debouncedUpdateControls: () => void;

  constructor(props: Props, state: State) {
    super(props, state);
    this.setupSceneBasicRigging();
    this.currentNodePositions = new Map<string, ArrayLike<number>>();
    this.webWorker = new (MyWorker as any)(); // todo: this shares the worker and means only 1 graph at a time -need to fix to create new https://github.com/webpack-contrib/worker-loader/issues/118
    this.webWorker.onmessage = (event: MessageEvent): void => {
      switch (event.data.type) {
        case EVENT_TYPE.NEW_SIMULATION_RESPONSE: {
          console.log("[cr] NEW_SIMULATION_RESPONSE");
          const payload = event.data.payload as NewSimulationResponse;
          this.state.nodes = payload.addedNodes;
          this.state.links = payload.addedLinks;
        }
        case EVENT_TYPE.NODE_POSITIONS_UPDATED: {
          console.log("[cr] NODE_POSITIONS_UPDATED");
          this.currentNodePositions = event.data
            .payload as NodePositionsUpdated;
          break;
        }
        case EVENT_TYPE.UPDATE_GRAPH_ELEMENTS_RESPONSE: {
          console.log("[cr] UPDATE_GRAPH_ELEMENTS_RESPONSE");
          const payload = event.data.payload as UpdateGraphDataResponse;
          payload.removedNodes.forEach(this.removeSphere);
          payload.removedLinks.forEach(this.removeSphereLink);
          payload.addedNodes.forEach(this.addSphere);
          payload.addedLinks.forEach(this.addSphereLink);
          break;
        }
      }
    };
    console.log("[cs] NEW_SIMULATION_REQUEST")
    this.webWorker.postMessage({
      payload: {
        links: this.props.links,
        nodes: this.props.nodes
      },
      type: EVENT_TYPE.NEW_SIMULATION_REQUEST
    });
    this.webWorker.postMessage({ type: EVENT_TYPE.TICK_REQUEST });
  }

  public componentWillUnmount(): void {
    this.webWorker.terminate();
    this.webWorker = null;
  }

  public componentDidMount(): void {
    this.containerDiv.appendChild(this.renderer.domElement);
    this.renderFrame();
    this.animate();
  }

  public render(): React.ReactNode {
    if (!this.renderedNode) {
      this.renderedNode = <div ref={node => (this.containerDiv = node)} />;
    }
    if (this.state.needsUpdate) {
      this.updateGraphData();
    }
    return this.renderedNode;
  }

  public componentDidUpdate() {
    this.setState((state, props) => {
      this.state.needsUpdate = false;
      return null; // don't trigger re-render
    });
  }

  private updateGraphData() {
    // verify needs update
    // create request for simulation
    this.state.removedNodes.forEach(this.removeSphere);
    this.state.removedLinks.forEach(this.removeSphereLink);
    this.state.addedNodes.forEach(e => this.addSphere(e.id));
    this.state.addedLinks.forEach(e => this.addSphereLink(e.id));
  }

  private removeSphere(id: string): void {
    const sphere = this.spheres.get(id);
    if (sphere == null) {
      return;
    }
    this.scene.remove(sphere);
    sphere.geometry.dispose();
  }

  private removeSphereLink(linkId: string): void {
    const line = this.lines.get(linkId);
    if (line == null) {
      return;
    }
    this.scene.remove(line);
    line.geometry.dispose();
    line.material.dispose();
  }

  private addSphere(id: string): void {
    const geometry = new SphereBufferGeometry(10);
    const material = new MeshLambertMaterial({ color: 0xff00ff });
    const mesh = new Mesh(geometry, material);
    this.spheres.set(id, mesh);
    this.scene.add(mesh);
  }

  private setupHelperPlane(): void {
    const planeGeometry = new PlaneBufferGeometry(2000, 2000);
    planeGeometry.rotateX(-Math.PI / 2);
    const planeMaterial = new ShadowMaterial({ opacity: 0.2 });
    const plane = new Mesh(planeGeometry, planeMaterial);
    plane.position.y = -200;
    plane.receiveShadow = true;
    this.scene.add(plane);
    const helper = new GridHelper(2000, 100);
    helper.position.y = -199;
    helper.material.opacity = 0.25;
    helper.material.transparent = true;
    this.scene.add(helper);
  }

  private setupLight() {
    this.scene.add(new AmbientLight(0xbbbbbb));
    const light = new SpotLight(0xffffff, 1.5);
    light.position.set(0, 1500, 200);
    light.castShadow = true;
    light.shadow = new SpotLightShadow(new PerspectiveCamera(70, 1, 200, 2000));
    light.shadow.bias = -0.000222;
    light.shadow.mapSize.width = 1024;
    light.shadow.mapSize.height = 1024;
    this.scene.add(light);
    this.spotlight = light;
  }

  private setupRenderer() {
    this.renderer.setClearColor(0xf0f0f0);
    this.renderer.setPixelRatio(window.devicePixelRatio);
    this.renderer.setSize(this.props.width, this.props.height);
    this.renderer.shadowMap.enabled = true;
  }

  private setupTrackballControls() {
    this.trackballControls = new TrackballControls(this.camera);
    this.trackballControls.rotateSpeed = 1.0;
    this.trackballControls.zoomSpeed = 1.2;
    this.trackballControls.panSpeed = 0.8;
    this.trackballControls.noZoom = false;
    this.trackballControls.noPan = false;
    this.trackballControls.noRotate = false;
    this.trackballControls.staticMoving = true;
    this.trackballControls.dynamicDampingFactor = 0.3;
    this.trackballControls.keys = [65, 83, 68];
    this.debouncedUpdateControls = throttle(this.trackballControls.update, 100);
  }

  private addSphereLink(id: string) {
    const lineMaterial = new LineBasicMaterial({
      color: 0x00ff00
    });
    const lineGeometry = new BufferGeometry();
    const floatArray = new Float32Array(2 * 3);
    const buffer = new Float32BufferAttribute(floatArray, 3);
    lineGeometry.addAttribute("position", buffer);
    const line = new Line(lineGeometry, lineMaterial);
    this.lines.set(id, line);
    this.scene.add(line);
  }

  private animate = () => {
    requestAnimationFrame(this.animate);
    if (!this.currentNodePositions || !this.currentNodePositions.size) {
      return;
    }
    console.log("[cs] TICK_REQUEST")
    this.webWorker.postMessage({ type: EVENT_TYPE.TICK_REQUEST });
    this.currentNodePositions.forEach((id, buffer) => {
      this.updateSpherePosition(id, buffer);
    });
    const sourceVector = new Vector3();
    const targetVector = new Vector3();
    this.state.links.forEach((link, i) => {
      this.updateLinkPosition(link, sourceVector, targetVector);
    });

    this.debouncedUpdateControls();
    this.renderFrame();
  };

  private renderFrame = () => {
    this.renderer.render(this.scene, this.camera);
  };

  private updateLinkPosition(
    e: ForceGraphLink,
    sourceVector: Vector3,
    targetVector: Vector3
  ) {
    const line = this.lines.get(e.id);
    if (!line) {
      console.error(`Could not find sphere link with id "${e.id}"`);
      return;
    }
    const geometry = this.lines.get(e.id).geometry as BufferGeometry;
    const buffer = geometry.getAttribute("position") as Float32BufferAttribute;
    const source = this.spheres.get(e.source);
    const target = this.spheres.get(e.target);
    source.geometry.computeBoundingBox();
    target.geometry.computeBoundingBox();
    const sourcePosition = source.geometry.boundingBox.getCenter(sourceVector);
    const targetPosition = target.geometry.boundingBox.getCenter(targetVector);
    (buffer.array as Float32Array)[0] = sourceVector.x || 0;
    (buffer.array as Float32Array)[1] = sourceVector.y || 0;
    (buffer.array as Float32Array)[2] = sourceVector.z || 0;
    (buffer.array as Float32Array)[3] = targetVector.x || 0;
    (buffer.array as Float32Array)[4] = targetVector.y || 0;
    (buffer.array as Float32Array)[5] = targetVector.z || 0;
    buffer.needsUpdate = true;
  }

  private updateSpherePosition(positions: ArrayLike<number>, id: string) {
    const sphere = this.spheres.get(id);
    if (!sphere) {
      console.error(`Sphere with id "${id}" could not be found`);
      return;
    }
    const geometry = sphere.geometry as SphereBufferGeometry;
    const vx = positions[POSITIONS_ARRAY_INDICES.VX] || 0;
    const vy = positions[POSITIONS_ARRAY_INDICES.VY] || 0;
    const vz = positions[POSITIONS_ARRAY_INDICES.VZ] || 0;
    const position = geometry.getAttribute("position");
    const arr = position.array as Float32Array;
    for (let i2 = 0; i2 < arr.length; i2++) {
      const mod = i2 % 3;
      switch (mod) {
        case 0:
          arr[i2] += vx;
          break;
        case 1:
          arr[i2] += vy;
          break;
        case 2:
          arr[i2] += vz;
          break;
      }
    }
    (position as BufferAttribute).needsUpdate = true;
  }

  private setupSceneBasicRigging() {
    this.camera = new PerspectiveCamera(
      70,
      this.props.width / this.props.height,
      1,
      10000
    );
    this.camera.position.set(0, 250, 1000);
    this.renderer = new WebGLRenderer({
      antialias: true
    });
    this.setupTrackballControls();
    this.setupRenderer();
    this.setupLight();
    this.setupHelperPlane();
    const objects: Mesh[] = [];
    this.dragControls = new DragControls(
      objects,
      this.camera,
      this.renderer.domElement
    );
    this.dragControls.addEventListener(
      "dragstart",
      e => (this.trackballControls.enabled = false)
    );
    this.dragControls.addEventListener(
      "dragend",
      e => (this.trackballControls.enabled = true)
    );
  }
}
