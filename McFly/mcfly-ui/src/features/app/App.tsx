import * as React from "react";
import ForceGraph from "../force-graph/ForceGraph";

export interface Props {}

export interface State {}

export default class App extends React.Component<Props, State> {
  constructor(props: Props, state: State) {
    super(props, state);
  }

  public render(): React.ReactNode {
    return <ForceGraph width={300} height={300} />;
  }
}
