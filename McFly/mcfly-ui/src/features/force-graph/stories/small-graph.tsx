import { Component } from "react";
import React = require("react");
import { generateRandomGraph } from "../domain";
import ForceGraph from "../ForceGraph";

export class SmallGraph extends Component<{}, {}> {
  public render() {
    const data = generateRandomGraph(15, 10);
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
