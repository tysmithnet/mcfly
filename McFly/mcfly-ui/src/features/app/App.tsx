import * as React from "react";
import { v4 } from "uuid";
import { ForceGraphLink, ForceGraphNode } from "../force-graph/domain";
import ForceGraph from "../force-graph/ForceGraph";

export interface Props {}

export interface State {}

export default class App extends React.Component<Props, State> {
  constructor(props: Props, state: State) {
    super(props, state);
  }

  public render(): React.ReactNode {
    const nodes = [];
    const links = [];

    const numNodes = 4000;
    const numLinks = 4000;
    for (let i = 0; i < numNodes; i++) {
      const node = {
        id: v4()
      };
      nodes.push(node);
    }

    for (let i = 0; i < numLinks; i++) {
      const lhs = Math.floor(Math.random() * numNodes);
      const rhs = Math.floor(Math.random() * numNodes);
      if (lhs === rhs) {
        continue;
      }
      links.push({
        id: v4(),
        source: nodes[lhs],
        target: nodes[rhs]
      });
    }
    return (
      <ForceGraph
        id="test"
        width={window.innerWidth}
        height={window.innerHeight}
        nodes={nodes}
        links={links}
      />
    );
  }
}
