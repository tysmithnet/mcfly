import React, { PureComponent, ReactNode } from "react";
import { ForceGraphElement } from 'Components/force-graph-element';

interface Props
{  
    height: number;
    width: number;
    children: ForceGraphElement[]
}

interface State
{
    height: number;
    width: number;
}

interface Simulation {
    width: number;
    height: number;
}

export default class ForceGraph extends PureComponent<Props, State> {

    private simulation: Simulation;

    constructor(props: Props, state: State) {
        super(props, state);

    }

    render() : ReactNode {
        const {
            width,
            height
        } = this.simulation;
        return (
            <svg width={width} height={height}>
            </svg>
        )   
    }
}