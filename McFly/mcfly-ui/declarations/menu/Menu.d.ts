import * as React from "react";
import { IProps, IState } from "./menu.domain";
export declare class Menu extends React.Component<IProps, IState> {
    private rootRef;
    constructor(props: IProps, state: IState);
    render(): JSX.Element;
    private handleFormSubmitted;
    private handleIdChanged;
    private handlePasswordChanged;
}
