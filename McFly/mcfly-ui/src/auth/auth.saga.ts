import axios from "axios";
import { all, put, takeLatest } from "redux-saga/effects";
import { ACTION_TYPES, ILoginRequest } from "./auth.action";
import { Permissions } from "./auth.domain";

/**
 * Attempt to login using the provided credentials
 * @param id Who to log in as
 * @param password Password for id
 */
function* loginUser(id: string, password: string) {
    try {
        const res = yield axios.post("/api/auth", {
            id,
            password,
        });
        const result = yield res.data;
        const permissions = [];
        for (const p of result.permissions) {
            const lookup = Permissions.get(p);
            if (lookup) {
                permissions.push(lookup);
            }
        }
        yield put({
            type: ACTION_TYPES.LOGIN_SUCCESS,
            user: {
                id: result.id,
                name: result.name,
                permissions,
            },
        });
    } catch (error) {
        yield put({
            error,
            type: ACTION_TYPES.LOGIN_FAILURE,
        });
    }
}

/**
 * Respond to login requests
 *
 * @export
 */
export function* loginSaga() {
    yield takeLatest(ACTION_TYPES.LOGIN_REQUEST, (action: ILoginRequest) => {
        return loginUser(action.id, action.password);
    });
}

/**
 * Root saga for the auth domain
 *
 * @export
 */
export function* rootSaga() {
    yield all([loginSaga()]);
}
