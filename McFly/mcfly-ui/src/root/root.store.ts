import { connectRouter, routerMiddleware } from "connected-react-router";
import { createBrowserHistory, createMemoryHistory } from "history";
import { applyMiddleware, compose, createStore } from "redux";
import loggerMiddleware from "redux-logger";
import createSagaMiddleware from "redux-saga";
import { reducer } from "./root.reducer";

// You cannot use browser history in jest tests or in storybook
const dynamic = global as any;
const history = dynamic.jasmine || dynamic.STORYBOOK_ENV
    ? createMemoryHistory()
    : createBrowserHistory();

/**
 * Get the history for routing purposes
 *
 * @export
 * @returns
 */
export function getHistory() {
    return history;
}
const connectedReducer = connectRouter(history)(reducer);

/**
 * The saga middleware
 */
export const sagaMiddleware = createSagaMiddleware();

/**
 * The root store
 */
export const store = createStore(
    connectedReducer,
    {},
    compose(
        applyMiddleware(routerMiddleware(history), loggerMiddleware, sagaMiddleware),
    ),
);
