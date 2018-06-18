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
  BoxBufferGeometry,
  BoxGeometry,
  BufferAttribute,
  BufferGeometry,
  Camera,
  Float32BufferAttribute,
  Geometry,
  GridHelper,
  LightShadow,
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
  NodePositionsUpdated,
  POSITIONS_ARRAY_INDICES
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
  nodes: ForceGraphNode[];
  links: ForceGraphLink[];
}

type NodePair = [ForceGraphNode, ForceGraphNode];

export default class ForceGraph extends React.PureComponent<Props, State> {
  
  public static getDerivedStateFromProps(nextProps: Props, prevState:State): State {
    return {needsUpdate: true, nodes: nextProps.nodes, links: nextProps.links};
  }
  public state:State = {needsUpdate: false, nodes: [], links:[]}

  private spotlight: SpotLight;
  private webWorker: Worker;
  private containerDiv: HTMLDivElement;
  private currentNodePositions: NodePositionsUpdated;
  private currentLinks: Map<string, ForceGraphLink> = new Map<string, ForceGraphLink>();
  private scene: Scene;
  private camera: PerspectiveCamera;
  private renderer: WebGLRenderer;
  private spheres: { [id: string]: Mesh };
  private lines: { [id: string]: Line };
  private buffers: { [id: string]: BufferAttribute };
  private trackballControls: TrackballControlsType;
  private dragControls: DragControls;
  private hasEnded = false;
  private numTicks = 180;
  private count = 0;
  private debouncedUpdateControls: () => void;
  private renderedNode: React.ReactNode = null;
  
  constructor(props: Props, state: State) {
    super(props, state);
    this.state = {
      links: this.props.links,
      needsUpdate: false,
      nodes: this.props.nodes
    };
    state.links.forEach((e, i) => {
      this.currentLinks.set(e.id, e);
    });
    const ref = React.createRef();
    this.buffers = {};
    this.currentNodePositions = {} as Map<string, ArrayLike<number>>;
    this.webWorker = new (MyWorker as any)();
    this.webWorker.postMessage({
      payload: this.state,
      type: EVENT_TYPE.NEW_SIMULATION_REQUEST
    });
    this.webWorker.onmessage = (event: MessageEvent): void => {
      const data = event.data as EventData;
      switch (event.data.type) {
        case EVENT_TYPE.NODE_POSITIONS_UPDATED:
          this.currentNodePositions = data.payload as NodePositionsUpdated;
          break;
      }
    };
    this.webWorker.postMessage({ type: EVENT_TYPE.TICK_REQUEST });
  }

  public componentWillUnmount(): void {
    this.webWorker.terminate();
    this.webWorker = null;
  }

  public componentDidMount(): void {
    
    this.scene = new Scene();
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

    this.renderer.setClearColor(0xf0f0f0);
    this.renderer.setPixelRatio(window.devicePixelRatio);
    this.renderer.setSize(this.props.width, this.props.height);
    this.renderer.shadowMap.enabled = true;
    this.containerDiv.appendChild(this.renderer.domElement);

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
    const objects: Mesh[] = [];

    this.spheres = {};
    this.state.nodes.forEach((e, i) => {
      const geometry = new SphereBufferGeometry(10);
      const material = new MeshLambertMaterial({ color: 0xff00ff });
      const mesh = new Mesh(geometry, material);
      this.spheres[e.id] = mesh;
      this.scene.add(mesh);
    });

    const lineMaterial = new LineBasicMaterial({
      color: 0x00ff00
    });
    this.lines = {};
    this.state.links.forEach((e, i) => {
      const lineGeometry = new BufferGeometry();
      const sourceId = e.source.id;
      const targetId = e.target.id;
      const sourceObj = this.spheres[sourceId];
      const targetObj = this.spheres[targetId];
      const floatArray = new Float32Array(2 * 3);
      const buffer = new Float32BufferAttribute(floatArray, 3);
      this.buffers[e.id] = buffer;
      lineGeometry.addAttribute("position", buffer);
      const line = new Line(lineGeometry, lineMaterial);
      this.lines[e.id] = line;
      this.scene.add(line);
    });

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

    (window as any).scene = this.scene;
    (window as any).THREE = require("three");
    this.renderFrame();
    this.animate();
  }


  public render(): React.ReactNode {
    if(this.state.needsUpdate) {
      const addedNodes:ForceGraphNode[] = [];
      const addedLinks:ForceGraphLink[] = [];
      const removedNodes:Set<string> = new Set<string>();
      const removedLinks:Set<string> = new Set<string>();
      const processed:Set<string> = new Set<string>();;
      this.state.nodes.forEach((e,i) => {
        processed.add(e.id);
        if(this.currentNodePositions.has(e.id)) {
          return;
        }
        addedNodes.push(e);
      });
      this.currentNodePositions.forEach((e, i) => {
        if(!processed.has(i)){
          removedNodes.add(i);
        }
      });
      processed.clear();
      this.state.links.forEach((e, i) => {
        processed.add(e.id);
        if(this.currentLinks.has(e.id)){
          return;
        }
        addedLinks.push(e);
      });
      this.currentLinks.forEach((e, i) => {
        if(!processed.has(i)) {
          removedLinks.add(i);
        }
      });
      this.webWorker.postMessage({payload: {
        addedLinks,
        addedNodes,
        removedLinks,
        removedNodes        
      }, type: EVENT_TYPE.UPDATE_GRAPH_DATA_REQUEST})
      this.setState((state, props) => {
        this.state.needsUpdate = false;
        return null; // don't trigger re-render
      });
    }
    if(!this.renderedNode) {
      this.renderedNode = <div ref={node => (this.containerDiv = node)} />;
    }
    return this.renderedNode;
  }

  private animate = () => {
    requestAnimationFrame(this.animate);
    if (!this.currentNodePositions || !this.currentNodePositions.size) {
      return;
    }
    if (this.count++ > this.numTicks) {
      this.hasEnded = true;
    }
    if (!this.hasEnded) {
      this.currentNodePositions.forEach((v, k) => {
        const data = v;
        const sphere = this.spheres[k];
        const geometry = sphere.geometry as SphereBufferGeometry;
        const vx = data[POSITIONS_ARRAY_INDICES.VX] || 0;
        const vy = data[POSITIONS_ARRAY_INDICES.VY] || 0;
        const vz = data[POSITIONS_ARRAY_INDICES.VZ] || 0;
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
      });
    }
    const sourceVector = new Vector3();
    const targetVector = new Vector3();
    this.state.links.forEach((e, i) => {
      const geometry = this.lines[e.id].geometry as BufferGeometry;
      const buffer = geometry.getAttribute(
        "position"
      ) as Float32BufferAttribute;
      const source = this.spheres[e.source.id];
      const target = this.spheres[e.target.id];
      source.geometry.computeBoundingBox();
      target.geometry.computeBoundingBox();
      const sourcePosition = source.geometry.boundingBox.getCenter(
        sourceVector
      );
      const targetPosition = target.geometry.boundingBox.getCenter(
        targetVector
      );
      (buffer.array as Float32Array)[0] = sourceVector.x || 0;
      (buffer.array as Float32Array)[1] = sourceVector.y || 0;
      (buffer.array as Float32Array)[2] = sourceVector.z || 0;
      (buffer.array as Float32Array)[3] = targetVector.x || 0;
      (buffer.array as Float32Array)[4] = targetVector.y || 0;
      (buffer.array as Float32Array)[5] = targetVector.z || 0;
      buffer.needsUpdate = true;
    });

    this.trackballControls.update();
    this.renderFrame();
    this.webWorker.postMessage({ type: EVENT_TYPE.TICK_REQUEST });
  };

  private renderFrame = () => {
    this.renderer.render(this.scene, this.camera);
  };
}
