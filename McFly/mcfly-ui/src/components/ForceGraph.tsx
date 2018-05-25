import * as React from "react";
import ForceGraphNode from "../components/ForceGraphNode";


interface Props {
    children: any;
}

interface State {

}

export default class ForceGraph extends React.PureComponent<Props, State>
{
    private children: any;

    constructor(props:Props, state:State) {
        super(props, state);
        this.children = props.children;
    }

    render() : React.ReactNode {
        return (
            <div>
                <h1>ForceGraph</h1>
                {this.children}
            </div>
        );
    }
}