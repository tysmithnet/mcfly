import * as React from "react";
import ForceGraphNode from "../components/ForceGraphNode";

interface Props {
    width: number;
    height: number;
}

interface State {
}

export default class ForceGraph extends React.PureComponent<Props, State>
{

    constructor(props:Props, state:State) {
        super(props, state);
    }

    render() : React.ReactNode {
        return (
            <svg width={this.props.width} height={this.props.height}>
                {this.props.children}
            </svg>
        );
    }
}