import {
  forceCenter,
  forceLink,
  forceManyBody,
  forceSimulation,
  Simulation,
  SimulationLinkDatum,
  SimulationNodeDatum
} from "d3-force-3d";
import {throttle} from "lodash";
import * as React from "react";
import {
  AmbientLight,
  BoxGeometry,
  BufferAttribute,
  BufferGeometry,
  Camera,
  Geometry,
  GridHelper,
  LightShadow,
  Line,
  LineBasicMaterial,
  Mesh,
  MeshBasicMaterial,
  MeshLambertMaterial,
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
  VRControls,
  WebGLRenderer
} from "three";
import DragControls from "three-dragcontrols";
import { ForceGraphElement, ForceGraphLink, ForceGraphNode } from "./domain";
import "./styles.scss";
const TrackballControls: any = require("three-trackballcontrols");

export interface Props {
  id: string;
  width: number;
  height: number;
  nodes: ForceGraphNode[];
  links: ForceGraphLink[];
}

export interface State {
  nodes: ForceGraphNode[];
  links: ForceGraphLink[];
}

type NodePair = [ForceGraphNode, ForceGraphNode];

export default class ForceGraph extends React.PureComponent<Props, State> {
  private spotlight: SpotLight;
  private webWorker: Worker;
  private containerDiv: HTMLDivElement;
  private simulation: Simulation<
    SimulationNodeDatum,
    SimulationLinkDatum<SimulationNodeDatum>
  >;
  private scene: Scene;
  private camera: PerspectiveCamera;
  private renderer: WebGLRenderer;
  private spheres: { [id: string]: Mesh };
  private lines: { [id: string]: Line };
  private buffers: { [id: string]: BufferAttribute};
  private trackballControls: TrackballControlsType;
  private dragControls:DragControls;
  private hasEnded = false;
  private numTicks = 180;
  private count = 0;  
  private debouncedUpdateControls: () => void;

  constructor(props: Props, state: State) {
    super(props, state);
    const ref = React.createRef();
    this.buffers = {};
  }

  public componentWillMount(): void {

    const newState: State = { nodes: this.props.nodes, links: this.props.links };
    this.setState(newState);

    this.simulation = forceSimulation(newState.nodes, 3)
      .force("charge", forceManyBody())
      .force("link", forceLink(newState.links))
      .force("center", forceCenter());
    this.simulation.stop();
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
    this.debouncedUpdateControls = throttle(this.trackballControls.update, 100)

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
      const material = new MeshLambertMaterial({ color: "#433F81" });
      const geometry = new SphereBufferGeometry(10);
      const buffer = new Float32Array(3);
      const sphereBuffer = new BufferAttribute(buffer, 3);
      this.buffers[e.id] = sphereBuffer;
      geometry.addAttribute("position", sphereBuffer);
      this.spheres[e.id] = new Mesh(geometry, material);
      this.scene.add(this.spheres[e.id]);
      objects.push(this.spheres[e.id]);
    });

    const lineMaterial = new LineBasicMaterial({
      color: 0x0000ff,
      linewidth: 10
    });
    this.lines = {};
    this.state.links.forEach((e, i) => {
      const lineGeometry = new BufferGeometry();
      const sourceId = e.source.id;
      const targetId = e.target.id;
      const sourceObj = this.spheres[sourceId];
      const targetObj = this.spheres[targetId];
      const floatArray = new Float32Array(2 * 3);
      const buffer = new BufferAttribute(floatArray, 3);
      this.buffers[e.id] = buffer;
      lineGeometry.addAttribute("position", buffer);
      const line = new Line(lineGeometry, lineMaterial);      
      this.lines[e.id] = line;
      this.scene.add(this.lines[e.id]);
    });

    this.dragControls = new DragControls(objects, this.camera, this.renderer.domElement);
    this.dragControls.addEventListener("dragstart", e => this.trackballControls.enabled = false);
    this.dragControls.addEventListener("dragend", e => this.trackballControls.enabled = true);

    (window as any).scene = this.scene;
    this.animate();
    this.renderFrame();
  }

  public render(): React.ReactNode {
    return <div ref={node => (this.containerDiv = node)} />;
  }

  private animate = () => {
    
    requestAnimationFrame(this.animate);
    if(this.count++ > this.numTicks)
    {
      this.hasEnded = true;
    }
    if(!this.hasEnded) {    
    this.simulation.tick();      
      this.simulation.nodes().forEach((e, i) => {
        const x = e.x || 0;
        const y = e.y || 0;
        const z = e.z || 0;
        const buffer = this.buffers[e.id];
        (buffer.array as Float32Array)[0] = x;
        (buffer.array as Float32Array)[1] = y;
        (buffer.array as Float32Array)[2] = z;
        buffer.needsUpdate = true;
      });
    }
    
    this.state.links.forEach((e, i) => {
      const sourceBuffer = this.buffers[e.source.id];
      const targetBuffer = this.buffers[e.target.id];
      const buffer = this.buffers[e.id];
      (buffer.array as Float32Array)[0] = (sourceBuffer.array as Float32Array)[0];
      (buffer.array as Float32Array)[1] = (sourceBuffer.array as Float32Array)[1];
      (buffer.array as Float32Array)[2] = (sourceBuffer.array as Float32Array)[2];
      (buffer.array as Float32Array)[3] = (targetBuffer.array as Float32Array)[0];
      (buffer.array as Float32Array)[4] = (targetBuffer.array as Float32Array)[1];
      (buffer.array as Float32Array)[5] = (targetBuffer.array as Float32Array)[2];
      buffer.needsUpdate = true;
    });

    this.trackballControls.update();
    this.renderFrame();
  };

  private renderFrame = () => {
    this.renderer.render(this.scene, this.camera);
  };
}
