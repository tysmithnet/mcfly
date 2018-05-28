import * as React from "react";
import {Provider} from "react-redux";
import {ConnectedRouter} from "react-router-redux";
import ForceGraph from "../components/ForceGraph";


interface Props {
}

interface State {
}

export default class App extends React.PureComponent<Props, State>
{
    constructor(props:Props, state:State) {
        super(props, state);
    }

    render() : React.ReactNode {
        return (
            <ForceGraph width={300} height={300}/>
        );
    }
}