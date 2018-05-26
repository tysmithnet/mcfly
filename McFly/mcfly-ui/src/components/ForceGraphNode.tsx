import * as React from "react";

interface Props {

}

interface State {

}

export default class ForceGraphNode extends React.PureComponent<Props, State>
{
    render() : React.ReactNode {
        return (
            <circle r="10" fill="black" cx="50" cy="50"/>
        );
    }
}