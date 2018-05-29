import * as React from "react";

export interface Props {
  
}

export interface State {
  x1: number;
  y1: number;
  x2: number;
  y2: number;
}

export default class ForceGraphLink extends React.PureComponent<Props, State> {
  constructor(props: Props, state: State) {
    super(props, state);
  }

  public render(): React.ReactNode {
    return (
      <line
        x1={this.state.x1}
        y1={this.state.y1}
        x2={this.state.x2}
        y2={this.state.y2}
      />
    );
  }
}
