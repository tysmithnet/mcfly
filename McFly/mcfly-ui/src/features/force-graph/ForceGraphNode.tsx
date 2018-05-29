import * as React from "react";

export interface Props {
  id: string;
}

export interface State {}

export default class ForceGraphNode extends React.PureComponent<Props, State> {
  public render(): React.ReactNode {
    return <circle id={this.props.id} r="10" fill="black" cx="50" cy="50" />;
  }
}
