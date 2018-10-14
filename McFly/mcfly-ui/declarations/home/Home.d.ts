import * as React from "react";
import { IBaseProps } from "../root";
export declare class Home extends React.Component<IBaseProps> {
    private ref;
    private worker;
    constructor(props: IBaseProps);
    componentDidMount(): void;
    render(): JSX.Element;
}
export declare const connectedComponent: React.ComponentClass<Pick<IBaseProps, never>, any> & {
    WrappedComponent: React.ComponentType<IBaseProps>;
};
