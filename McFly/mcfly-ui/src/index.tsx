import { createBrowserHistory } from "history";
import * as React from "react";
import * as ReactDOM from "react-dom";
import { Provider } from "react-redux";
import { Route } from "react-router-dom";
import { ConnectedRouter } from "react-router-redux";
import ForceGraph from "./features/force-graph/ForceGraph";

import { applyMiddleware, compose, createStore } from "redux";

import rootReducer from "./features/force-graph/reducers";

import { ForceGraphState } from "./features/force-graph/domain";

const store = createStore(rootReducer);

ReactDOM.render(
  <Provider store={store}>
    <ForceGraph width={300} height={300} />
  </Provider>,
  document.getElementById("root")
);
