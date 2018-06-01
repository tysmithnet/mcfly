import * as React from "react";
// import Worker from "worker-loader!./simulator.webworker";

import {
  forceCenter,
  forceLink,
  forceManyBody,
  forceSimulation,
  Simulation,
  SimulationLinkDatum,
  SimulationNodeDatum
} from "d3-force-3d";

import Worker = require("worker-loader?name=dist/[name].js!./simulator.webworker");
import { ForceGraphElement, ForceGraphLink, ForceGraphNode } from "./domain";

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
  private canvasRef: React.RefObject<HTMLCanvasElement>;
  private simulation: Simulation<
    SimulationNodeDatum,
    SimulationLinkDatum<SimulationNodeDatum>
  >;
  constructor(props: Props, state: State) {
    super(props, state);
    const ref = React.createRef();
  }

  public componentWillMount(): void {
    this.setState({ nodes: [], links: [] });
    const nodes: SimulationNodeDatum[] = this.state.nodes.map(n => {
      return { id: n.id } as any;
    });
    const links: Array<
      SimulationLinkDatum<SimulationNodeDatum>
    > = this.state.links.map(l => {
      return { source: l.from, target: l.to } as any;
    });
    this.simulation = forceSimulation(nodes)
      .force("charge", forceManyBody())
      .force("link", forceLink(links))
      .force("center", forceCenter());

  }

  public componentDidMount(): void {
    ;
  }

  public render(): React.ReactNode {
    return (
      <div>
        <canvas
          ref={this.canvasRef}
          width={this.props.width}
          height={this.props.height}
        />
      </div>
    );
  }
}
