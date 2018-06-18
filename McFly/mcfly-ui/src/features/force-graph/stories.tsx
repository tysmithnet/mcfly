import { Story } from "@storybook/react";
import { Component } from "react";
import React = require("react");
import { connect, Provider } from "react-redux";
import { createStore } from "redux";
import { v4 } from "uuid";
import { ForceGraphLink, ForceGraphNode } from "./domain";
import ForceGraph from "./ForceGraph";

interface State {
  nodes: ForceGraphNode[];
  links: ForceGraphLink[];
}

export function generateRandomGraph(
  numNodes: number,
  numLinks: number
): { nodes: ForceGraphNode[]; links: ForceGraphLink[] } {
  const nodes: ForceGraphNode[] = [];
  const links: ForceGraphLink[] = [];

  for (let i = 0; i < numNodes; i++) {
    nodes.push({ id: v4() });
  }

  while (links.length < numLinks) {
    const lhs = Math.floor(Math.random() * numNodes);
    const rhs = Math.floor(Math.random() * numNodes);
    if (lhs === rhs) {
      continue;
    }
    links.push({ id: v4(), source: nodes[lhs], target: nodes[rhs] });
  }

  return { nodes, links };
}

export function mapStateToProps(state: State): State {
  return {
    links: state.links,
    nodes: state.nodes
  };
}

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

export class SingleLink extends Component<{}, {}> {
  public render() {
    const nodes = [{ id: "a" }, { id: "b" }];
    const links = [{ id: "c", source: nodes[0], target: nodes[1] }];
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

export class LargeGraph extends Component<{}, {}> {
  public render() {
    const data = generateRandomGraph(1500, 1000);
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

interface Action {
  type: string;
}
function addNodesReducer(
  state: State = { nodes: [], links: [] },
  action: Action
): State {
  switch (action.type) {
    case "ADD_NODE":
      const node = { id: v4() };
      const newNodes = [...state.nodes, node];
      return { links: state.links, nodes: newNodes };
  }
  return { ...state };
}
export const addNodesStore = createStore(addNodesReducer);

export function AddNodesProvider(story: { story: any }) {
  return <Provider store={addNodesStore}>{story.story}</Provider>;
}

class AddNodesImpl extends Component<{}, {}> {
  public render() {
    const state = addNodesStore.getState() as State;
    return (
      <div>
        <ForceGraph
          id="a"
          width={window.innerWidth / 2}
          height={window.innerHeight / 2}
          nodes={state.nodes}
          links={state.links}
        />
        <button onClick={this.addNode}>Add Node</button>
      </div>
    );
  }

  private addNode() {
    addNodesStore.dispatch({ type: "ADD_NODE" });
  }
}

export const AddNodes = connect(mapStateToProps)(AddNodesImpl);
