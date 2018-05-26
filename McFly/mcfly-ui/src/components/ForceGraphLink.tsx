import * as React from "react";


interface Props {
}

interface State {

}

export default class ForceGraphLink extends React.PureComponent<Props, State>
{

    constructor(props:Props, state:State) {
        super(props, state);
    }

    render() : React.ReactNode {
        return (
            <h3>ForceGraphLink</h3>
        );
    }
}