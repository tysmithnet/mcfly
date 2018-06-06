import * as React from "react";
import { ForceGraphLink, ForceGraphNode } from "../force-graph/domain";
import ForceGraph from "../force-graph/ForceGraph";

export interface Props {}

export interface State {}

export default class App extends React.Component<Props, State> {
  constructor(props: Props, state: State) {
    super(props, state);
  }

  public render(): React.ReactNode {
    return (
      <ForceGraph
        id="test"
        width={window.innerWidth}
        height={window.innerHeight}
        nodes={[]}
        links={[]}
      />
    );
  }
}
