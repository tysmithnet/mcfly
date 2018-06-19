import { Component } from "react";
import React = require("react");
import { connect, Provider } from "react-redux";
import { createStore } from "redux";
import { v4 } from "uuid";
import { ForceGraphLink, ForceGraphNode, generateRandomGraph } from "../domain";
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
function addLinksReducer(
  state: State = { nodes: [], links: [] },
  action: Action
): State {
  switch (action.type) {
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
const addLinksStore = createStore(addLinksReducer, generateRandomGraph(30, 0));

export function AddLinksProvider(story: { story: any }) {
  return <Provider store={addLinksStore}>{story.story}</Provider>;
}

class AddLinksImpl extends Component<{}, {}> {
  public render() {
    const state = addLinksStore.getState() as State;
    return (
      <div>
        <ForceGraph
          id="a"
          width={window.innerWidth / 2}
          height={window.innerHeight / 2}
          nodes={state.nodes}
          links={state.links}
        />
        <button onClick={this.addLink}>Add Link</button>
      </div>
    );
  }

  private addLink() {
    addLinksStore.dispatch({ type: "ADD_LINK" });
  }
}

export const AddLinks = connect(mapStateToProps)(AddLinksImpl);
