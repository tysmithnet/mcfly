import { IAction } from "../root";
import { IUser } from "./auth.domain";
export interface ILoginRequest extends IAction {
    id: string;
    password: string;
}
export interface ILoginSuccess extends IAction {
    user: IUser;
}
export interface ILoginFailure extends IAction {
    error: any;
}
export declare const ACTION_TYPES: {
    LOGIN_FAILURE: string;
    LOGIN_REQUEST: string;
    LOGIN_SUCCESS: string;
};
export declare function loginRequestFactory(id: string, password: string): ILoginRequest;
