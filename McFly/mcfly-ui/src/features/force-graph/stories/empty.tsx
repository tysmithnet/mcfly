import { Component } from "react";
import React = require("react");
import ForceGraph from "../ForceGraph";

export class Empty extends Component<{}, {}> {
  public render() {
    return (
      <ForceGraph
        id="a"
        width={window.innerWidth / 2}
        height={window.innerHeight / 2}
        nodes={[]}
        links={[]}
      />
    );
  }
}
