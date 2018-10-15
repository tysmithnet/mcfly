import { storiesOf } from "@storybook/react";
import * as React from "react";
import { Provider } from "react-redux";
import App from "../src/app/App";
import { Home } from "../src/home/Home";
import "../src/root";
import store from "../src/root.store";

/**
 * Provide the store to components
 * @param story Storybook factory method
 */
const ProviderDecorator = (story: any) => (
  <Provider store={store}>{story()}</Provider>
);

storiesOf("App", module)
  .addDecorator(ProviderDecorator)
  .add("Ask you to log in", () => <App />);

storiesOf("Home", module)
  .addDecorator(ProviderDecorator)
  .add("Animate", () => <Home dispatch={store.dispatch} />)
