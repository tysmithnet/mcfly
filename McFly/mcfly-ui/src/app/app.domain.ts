import { IPermission, IUser } from "../auth";
import { IBaseProps } from "../root";

/**
 * Props for the App component
 *
 * @export
 * @interface IProps
 * @extends {IBaseProps}
 */
export interface IProps extends IBaseProps {
    /**
     * The currently logged in user
     *
     * @type {IUser}
     * @memberof IProps
     */
    user?: IUser;

    /**
     * Currently active routes
     *
     * @type {IRoute[]}
     * @memberof IProps
     */
    routes: IRoute[];
}

/**
 * State for the App component
 *
 * @export
 * @interface IRootState
 */
export interface IRootState {
    /**
     * Currently active routes
     *
     * @type {IRoute[]}
     * @memberof IRootState
     */
    routes: IRoute[];
}

/**
 * A section of the application that can be navigated to
 *
 * @export
 * @interface IRoute
 */
export interface IRoute {
    /**
     * Component to be used when a route matches
     *
     * @type {React.ComponentClass}
     * @memberof IRoute
     */
    component: React.ComponentClass;

    /**
     * User friendly name to display for this route
     *
     * @type {string}
     * @memberof IRoute
     */
    display: string;

    /**
     * true if this route path should be strict and exact in its matching, false if the match can happen with substrings
     *
     * @type {boolean}
     * @memberof IRoute
     */
    exact: boolean;

    /**
     * Path to match against
     *
     * @type {string}
     * @memberof IRoute
     */
    path: string;

    /**
     * Permissions required to access this route
     *
     * @type {IPermission[]}
     * @memberof IRoute
     */
    permissions: IPermission[];
}
