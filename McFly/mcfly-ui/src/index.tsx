import * as React from "react";
import * as ReactDOM from "react-dom";
import { Provider } from "react-redux";
import { ConnectedRouter } from "react-router-redux";
import { createBrowserHistory } from "history";
import App from "./components/App";

const history = createBrowserHistory();

ReactDOM.render(
  <Provider>
    <ConnectedRouter>
      <App />
    </ConnectedRouter>
  </Provider>,
  document.getElementById("root")
);
