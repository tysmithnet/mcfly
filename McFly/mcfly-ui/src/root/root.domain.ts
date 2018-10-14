import { Dispatch } from "redux";
import { IRootState as IAppState } from "../app";
import { IRootState as IAuthState } from "../auth";

/**
 * Root of the state tree
 *
 * @export
 * @interface IRootState
 */
export interface IRootState {
    /**
     * State for the app domain
     *
     * @type {IAppState}
     * @memberof IRootState
     */
    app: IAppState;

    /**
     * State for the auth domain
     *
     * @type {IAuthState}
     * @memberof IRootState
     */
    auth: IAuthState;
}

/**
 * Base interface for all component props
 *
 * @export
 * @interface IBaseProps
 */
export interface IBaseProps {
    /**
     * Function to dispatch actions
     *
     * @type {Dispatch}
     * @memberof IBaseProps
     */
    dispatch?: Dispatch;

    /**
     * Injection point for worker creation. Since workers are usable by any component
     * it is defined at this level.
     *
     * @memberof IBaseProps
     */
    createWorker?: () => Worker;
}
