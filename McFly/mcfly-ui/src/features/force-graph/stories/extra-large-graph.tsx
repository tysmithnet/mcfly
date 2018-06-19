import { Component } from "react";
import React = require("react");
import { generateRandomGraph } from "../domain";
import ForceGraph from "../ForceGraph";

export class ExtraLargeGraph extends Component<{}, {}> {
  public render() {
    const data = generateRandomGraph(4000, 1500);
    return (
      <ForceGraph
        id="a"
        width={window.innerWidth / 2}
        height={window.innerHeight / 2}
        nodes={data.nodes}
        links={data.links}
      />
    );
  }
}
