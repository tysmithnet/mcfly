import * as React from "react";
// import Worker from "worker-loader!./simulator.webworker";
import ForceGraphLink from "./ForceGraphLink";
import ForceGraphNode from "./ForceGraphNode";

import {Simulation} from "d3-force-3d";

import Worker = require("worker-loader?name=dist/[name].js!./simulator.webworker");

export interface Props {
  width: number;
  height: number;
}

export interface State {
  nodes?: ForceGraphNode[];
  links?: ForceGraphLink[];
}

export default class ForceGraph extends React.PureComponent<Props, State> {
  private webWorker: Worker;

  constructor(props: Props, state: State) {
    super(props, state);
  }

  public componentWillMount(): void {
    this.setState({ links: [], nodes: [] });
    this.webWorker = new Worker();
    this.webWorker.onmessage = event => {
      // tslint:disable-next-line:no-console
      console.log("this.webWorker.onmessage = (event) =>");
    };
    this.webWorker.addEventListener("message", event => {
      // tslint:disable-next-line:no-console
      console.log('this.webWorker.addEventListener("message", (event) =>');
    });
    this.webWorker.postMessage({ a: 1 });
  }

  public componentDidMount(): void {
    this.webWorker.postMessage({
      links: this.state.links,
      nodes: this.state.nodes
    });
  }
  public render(): React.ReactNode {
    return (
      <svg width={this.props.width} height={this.props.height}>
        {this.props.children}
      </svg>
    );
  }
}
