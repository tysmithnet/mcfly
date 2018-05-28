import * as React from "react";

interface Props {
  x1: number;
  y1: number;
  x2: number;
  y2: number;
}

interface State {}

export default class ForceGraphLink extends React.PureComponent<Props, State> {
  constructor(props: Props, state: State) {
    super(props, state);
  }

  render(): React.ReactNode {
    return (
      <line
        x1={this.props.x1}
        y1={this.props.y1}
        x2={this.props.x2}
        y2={this.props.y2}
      />
    );
  }
}
