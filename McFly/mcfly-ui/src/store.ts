import { applyMiddleware, compose, createStore, Store } from "redux";
import rootReducer from "./features/force-graph/reducers";

import { State as ForceGraphState } from "./features/force-graph/ForceGraph";

const configureStore = () => {
  return createStore(rootReducer, { nodes: [], links: [] });
};

export default configureStore;
