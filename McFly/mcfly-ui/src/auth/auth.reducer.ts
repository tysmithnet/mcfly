import { IAction } from "../root";
import { ACTION_TYPES, ILoginSuccess } from "./auth.action";
import { IRootState } from "./auth.domain";

/**
 * Apply the changes resulting from a successful login
 * @param state Current state
 * @param loginSuccess Login success message
 */
function handleLoginSuccess(
    state: IRootState,
    loginSuccess: ILoginSuccess,
): IRootState {
    return {
        ...state,
        user: loginSuccess.user,
    };
}

/**
 * Reducer for the Auth domain
 * @param state Current state
 * @param action Action to apply
 */
export function reducer(state: IRootState, action: IAction): IRootState {
    switch (action.type) {
        case ACTION_TYPES.LOGIN_SUCCESS:
            return handleLoginSuccess(state, action as ILoginSuccess);
    }
    return { ...state };
}
