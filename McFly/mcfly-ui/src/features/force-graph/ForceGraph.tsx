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
  BoxGeometry,
  Camera,
  Mesh,
  MeshBasicMaterial,
  PerspectiveCamera,
  Renderer,
  Scene,
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
  private camera: Camera;
  private renderer: WebGLRenderer;
  private cube: Mesh;
  constructor(props: Props, state: State) {
    super(props, state);
    const ref = React.createRef();
  }

  public componentWillMount(): void {
    const newState: State = { nodes: [], links: [] };
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
      75,
      this.props.width / this.props.height,
      0.1,
      1000
    );
    this.camera.position.z = 4;
    this.renderer = new WebGLRenderer({
      antialias: true
    });
    this.renderer.setClearColor("#000000");
    this.renderer.setSize(this.props.width, this.props.height);
    this.containerDiv.appendChild(this.renderer.domElement);
    const geometry = new BoxGeometry(1,1,1);
    const material = new MeshBasicMaterial({ color: "#433F81"});
    this.cube = new Mesh(geometry, material);
    this.scene.add(this.cube);
    this.renderFrame();
  }

  public render(): React.ReactNode {
    return <div ref={node => (this.containerDiv = node)} />;
  }

  private renderFrame = () => {
    requestAnimationFrame(this.renderFrame);
    this.cube.rotateX(.15);
    this.cube.rotateY(.15);
    this.cube.rotateZ(.15);
    this.renderer.render(this.scene, this.camera);
  }
}
