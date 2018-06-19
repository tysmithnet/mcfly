import { Component } from "react";
import React = require("react");
import { connect, Provider } from "react-redux";
import { createStore } from "redux";
import { v4 } from "uuid";
import { ForceGraphLink, ForceGraphNode } from "../domain";
import ForceGraph from "../ForceGraph";

interface State {
  nodes: ForceGraphNode[];
  links: ForceGraphLink[];
}

function mapStateToProps(state: State): State {
  return {
    links: state.links,
    nodes: state.nodes
  };
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
const addNodesStore = createStore(addNodesReducer);

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
