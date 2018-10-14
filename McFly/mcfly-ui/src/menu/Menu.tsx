import * as React from "react";
import { loginRequestFactory } from "../auth";
import {SearchBar} from "../search/SearchBar";
import { Logo } from "./Logo";
import { IProps, IState } from "./menu.domain";

/**
 * Menu to display on most pages for navigation/login
 *
 * @export
 * @class Menu
 * @extends {React.Component<IProps, IState>}
 */
export class Menu extends React.Component<IProps, IState> {
    private rootRef: React.RefObject<HTMLDivElement>;

    /**
     * Creates an instance of Menu.
     * @param {IProps} props
     * @param {IState} state
     * @memberof Menu
     */
    constructor(props: IProps, state: IState) {
        super(props, state);
        this.state = {
            id: "",
            password: "",
        };
        this.rootRef = React.createRef();
        this.handleIdChanged = this.handleIdChanged.bind(this);
        this.handlePasswordChanged = this.handlePasswordChanged.bind(this);
        this.handleFormSubmitted = this.handleFormSubmitted.bind(this);
    }

    /**
     * Render the component
     *
     * @returns
     * @memberof Menu
     */
    public render() {
        return (
            <div className="menu-container">
                <div className="logo-container">
                    <Logo />
                </div>
                <div className="search-container">
                    <SearchBar />
                </div>
                <nav>
                    <ul>
                        {this.props.links.map(l => (
                           <li>{l}</li>
                        ))}
                    </ul>
                </nav>
            </div>
        )
    }

    /**
     * Handle a login form submission
     * @param event Form submit event
     */
    private handleFormSubmitted(event: React.FormEvent) {
        this.props.dispatch(
            loginRequestFactory(this.state.id, this.state.password),
        );
        event.preventDefault();
        event.stopPropagation();
    }

    /**
     * Handle the user id input changed
     * @param event Input changed event
     */
    private handleIdChanged(event: React.ChangeEvent<HTMLInputElement>) {
        this.setState({ ...this.state, id: event.target.value });
    }

    /**
     * Handle the user password input changed
     * @param event Input changed event
     */
    private handlePasswordChanged(event: React.ChangeEvent<HTMLInputElement>) {
        this.setState({ ...this.state, password: event.target.value });
    }
}
