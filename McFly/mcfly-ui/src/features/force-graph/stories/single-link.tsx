import { Component } from "react";
import React = require("react");
import ForceGraph from "../ForceGraph";

export class SingleLink extends Component<{}, {}> {
  public render() {
    const nodes = [{ id: "a" }, { id: "b" }];
    const links = [{ id: "c", source: nodes[0].id, target: nodes[1].id }];
    return (
      <ForceGraph
        id="a"
        width={window.innerWidth / 2}
        height={window.innerHeight / 2}
        nodes={nodes}
        links={links}
      />
    );
  }
}
