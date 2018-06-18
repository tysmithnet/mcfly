import { Component } from "react";
import React = require("react");
import ForceGraph from "../ForceGraph";
import { generateRandomGraph } from "./index";

export class MediumGraph extends Component<{}, {}> {
  public render() {
    const data = generateRandomGraph(150, 100);
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
