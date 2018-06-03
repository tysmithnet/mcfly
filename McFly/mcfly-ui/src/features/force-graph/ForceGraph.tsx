import {
  forceCenter,
  forceLink,
  forceManyBody,
  forceSimulation,
  Simulation,
  SimulationLinkDatum,
  SimulationNodeDatum
} from "d3-force-3d";
import * as React from "react";
import {
  AmbientLight,
  BoxGeometry,
  Camera,
  Mesh,
  MeshBasicMaterial,
  MeshPhongMaterial,
  PerspectiveCamera,
  Renderer,
  Scene,
  Sphere,
  SphereGeometry,
  TrackballControls,
  WebGLRenderer
} from "three";
import { ForceGraphElement, ForceGraphLink, ForceGraphNode } from "./domain";
import "./styles.scss";

export interface Props {
  id: string;
  width: number;
  height: number;
}

export interface State {
  nodes: ForceGraphNode[];
  links: ForceGraphLink[];
}

export default class ForceGraph extends React.PureComponent<Props, State> {
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
  private trackballControls: TrackballControls;
  constructor(props: Props, state: State) {
    super(props, state);
    const ref = React.createRef();
  }

  public componentWillMount(): void {
    const nodesData: ForceGraphNode[] = [
      {
        id: "a",
        title: "The letter a"
      },
      {
        id: "b",
        title: "The letter b"
      },
      {
        id: "c",
        title: "The letter c"
      },
      {
        id: "d",
        title: "The letter d"
      },
      {
        id: "e",
        title: "The letter e"
      },
      {
        id: "f",
        title: "The letter f"
      }
    ];
    const linksData: ForceGraphLink[] = [];
    const newState: State = { nodes: nodesData, links: linksData };
    this.setState(newState);
    const nodes: SimulationNodeDatum[] = newState.nodes.map(n => {
      return { id: n.id } as any;
    });
    const links: Array<
      SimulationLinkDatum<SimulationNodeDatum>
    > = newState.links.map(l => {
      return { source: l.from, target: l.to } as any;
    });
    this.simulation = forceSimulation(nodes)
      .force("charge", forceManyBody())
      .force("link", forceLink(links))
      .force("center", forceCenter());
  }

  public componentDidMount(): void {
    this.scene = new Scene();
    this.camera = new PerspectiveCamera(
      45,
      this.props.width / this.props.height,
      0.1,
      10000
    );
    this.camera.updateProjectionMatrix();
    this.camera.position.z = -300;
    this.renderer = new WebGLRenderer({
      antialias: true
    });
    this.renderer.setClearColor("#000000");
    this.renderer.setSize(this.props.width, this.props.height);
    this.containerDiv.appendChild(this.renderer.domElement);
    const geometry = new SphereGeometry(10);
    const material = new MeshPhongMaterial({ color: "#433F81" });
    this.scene.add(new AmbientLight(0xbbbbbb));
    this.spheres = {};
    this.state.nodes.forEach((e, i) => {
      this.spheres[e.id] = new Mesh(geometry, material);
      this.scene.add(this.spheres[e.id]);
    });
    (window as any).scene = this.scene;
    this.renderFrame();
  }

  public render(): React.ReactNode {
    return <div ref={node => (this.containerDiv = node)} />;
  }

  private renderFrame = () => {
    requestAnimationFrame(this.renderFrame);
    this.simulation.nodes().forEach((e, i) => {
      this.spheres[e.id].position.set(e.x, e.y, e.z);
    });
    this.renderer.render(this.scene, this.camera);
  };
}
