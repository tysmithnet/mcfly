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
    case "ADD_LINK":
      const lhs = Math.floor(Math.random() * state.nodes.length);
      const rhs = Math.floor(Math.random() * state.nodes.length);
      const link = {
        id: v4(),
        source: state.nodes[lhs],
        target: state.nodes[rhs]
      };
      const newLinks = [...state.links, link];
      return { links: newLinks, nodes: state.nodes };
  }
  return { ...state };
}
const store = createStore(addNodesReducer);

export function AddRemoveGraphElementsProvider(story: { story: any }) {
  return <Provider store={store}>{story.story}</Provider>;
}

class Implementation extends Component<{}, {}> {
  public render() {
    const state = store.getState() as State;
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
        <button onClick={this.addLink}>Add Link</button>
      </div>
    );
  }

  private addNode() {
    store.dispatch({ type: "ADD_NODE" });
  }

  private addLink() {
    store.dispatch({type: "ADD_LINK"});
  }
}

export const AddRemoveGraphElements = connect(mapStateToProps)(Implementation);
