import { applyMiddleware, compose, createStore, Store } from "redux";
import rootReducer from "./features/force-graph/reducers";

import { ForceGraphState } from "./features/force-graph/domain";

const configureStore = () => {
  return createStore(rootReducer, new ForceGraphState());
};

export default configureStore;
