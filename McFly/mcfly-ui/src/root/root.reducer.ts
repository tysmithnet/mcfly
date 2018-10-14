import { combineReducers } from "redux";
import { reducer as app } from "../app";
import { reducer as auth } from "../auth";

export const reducer = combineReducers({ app, auth });

/**
 * Base interface for actions
 *
 * @export
 * @interface IAction
 */
export interface IAction {
    /**
     * Identifying type name for the action
     *
     * @type {string}
     * @memberof IAction
     */
    type: string;
}
