import { Story } from "@storybook/react";
import { Component } from "react";
import React = require("react");
import ForceGraph from "../ForceGraph";

export class SingleNode extends Component<{}, {}> {
  public render() {
    return (
      <ForceGraph
        id="a"
        width={window.innerWidth / 2}
        height={window.innerHeight / 2}
        nodes={[{ id: "a" }]}
        links={[]}
      />
    );
  }
}
