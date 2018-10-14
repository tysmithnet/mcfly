import * as React from "react";
import { IProps } from "./app.domain";
import "./app.styles";
export declare class App extends React.Component<IProps> {
    render(): React.ReactNode;
}
declare const connectedComponent: React.ComponentClass<Pick<IProps, never>, any> & {
    WrappedComponent: React.ComponentType<IProps>;
};
export default connectedComponent;
