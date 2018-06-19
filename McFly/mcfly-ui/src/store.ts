import { applyMiddleware, compose, createStore, Store } from "redux";

const configureStore = () => {
  return createStore((state, props) => state, { nodes: [], links: [] });
};

export default configureStore;
