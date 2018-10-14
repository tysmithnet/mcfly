import { all } from "redux-saga/effects";
import { rootSaga as auth } from "../auth/auth.saga";
import { rootSaga as home } from "../home/home.saga";

/**
 * Root of the saga tree
 */
export function* rootSaga() {
    yield all([auth(), home()]);
}
