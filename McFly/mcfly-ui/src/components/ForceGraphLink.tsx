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
            <rect width="10" height="20" />
        );
    }
}