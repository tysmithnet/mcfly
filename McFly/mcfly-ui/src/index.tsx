import { createBrowserHistory } from "history";
import * as React from "react";
import * as ReactDOM from "react-dom";
import { Provider } from "react-redux";
import { Route } from "react-router-dom";
import { ConnectedRouter } from "react-router-redux";
import * as THREE from "three";
import App from "./features/app/App";
import ForceGraph from "./features/force-graph/ForceGraph";
import configureStore from "./store";

// this is for Three.js Inspector extension for chrome
(window as any).THREE = THREE;

const store = configureStore();

ReactDOM.render(
  <Provider store={store}>
    <App />
  </Provider>,
  document.getElementById("root")
);
