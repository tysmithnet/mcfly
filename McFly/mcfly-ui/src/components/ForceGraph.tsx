import * as React from "react";
import ForceGraphNode from "../components/ForceGraphNode";
import ForceGraphLink from "./ForceGraphLink";

import * as workerPath from "file-loader?name=[name].js!./simulator.webworker";

export interface Props {
  width: number;
  height: number;
}

export interface State {
  nodes?: ForceGraphNode[],
  links?: ForceGraphLink[];
}

export default class ForceGraph extends React.PureComponent<Props, State> {
  private webWorker: Worker;

  constructor(props: Props, state: State) {
    super(props, state);
  }

  public componentWillMount(): void {
    this.setState({links: [], nodes:[]});
    this.webWorker = new Worker(workerPath);
    

    // todo: this should be typed
    this.webWorker.onmessage = (event:any):void => { 
      // tslint:disable-next-line:no-console
      console.log(event);
    };
  }

  public componentDidMount():void {
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
