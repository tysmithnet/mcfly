import * as React from "react";
import ForceGraphNode from "../components/ForceGraphNode";


interface Props {
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
            <div>
                <h1>ForceGraph</h1>
                {this.props.children}
            </div>
        );
    }
}