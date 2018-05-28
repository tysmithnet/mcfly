import { createBrowserHistory } from "history";
import * as React from "react";
import * as ReactDOM from "react-dom";
import { Provider } from "react-redux";
import { Route } from "react-router-dom";
import { ConnectedRouter } from "react-router-redux";
import App from "./components/App";
import { configureStore } from "./renameme";

const history = createBrowserHistory();
const store = configureStore(history);

ReactDOM.render(
  <Provider store={store}>
    <ConnectedRouter history={history}>
      <Route exact={true} path="/" render={() => <App />} />
    </ConnectedRouter>
  </Provider>,
  document.getElementById("root")
);
