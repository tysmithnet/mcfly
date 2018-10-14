import { IAction } from "../root";
import { IUser } from "./auth.domain";

/**
 * A request to log a user into the system
 *
 * @export
 * @interface ILoginRequest
 * @extends {IAction}
 */
export interface ILoginRequest extends IAction {
    /**
     * The user id to use in the login attempt
     *
     * @type {string}
     * @memberof ILoginRequest
     */
    id: string;

    /**
     * The password to use in the login attempt
     *
     * @type {string}
     * @memberof ILoginRequest
     */
    password: string;
}

/**
 * A login request was successful
 *
 * @export
 * @interface ILoginSuccess
 * @extends {IAction}
 */
export interface ILoginSuccess extends IAction {
    /**
     * User account that has been logged in
     *
     * @type {IUser}
     * @memberof ILoginSuccess
     */
    user: IUser;
}

/**
 * A login request failed
 *
 * @export
 * @interface ILoginFailure
 * @extends {IAction}
 */
export interface ILoginFailure extends IAction {
    /**
     * Any error associated with the failure
     *
     * @type {*}
     * @memberof ILoginFailure
     */
    error: any;
}

/**
 * The types of actions possible
 */
export const ACTION_TYPES = {
    LOGIN_FAILURE: "@auth/LoginFailure",
    LOGIN_REQUEST: "@auth/LoginRequest",
    LOGIN_SUCCESS: "@auth/LoginSuccess",
};

/**
 * Creates a login request
 * @param id User id to login
 * @param password Password to login
 */
export function loginRequestFactory(
    id: string,
    password: string,
): ILoginRequest {
    return {
        id,
        password,
        type: ACTION_TYPES.LOGIN_REQUEST,
    };
}
