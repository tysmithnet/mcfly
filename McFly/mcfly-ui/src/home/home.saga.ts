import { TweenLite } from "gsap";
import { delay } from "redux-saga";
import { all, put, takeLatest } from "redux-saga/effects";
import { ACTION_TYPES, IAnimationStartRequest } from "./home.action";

/**
 * Duration in ms of the intro
 */
const INTRO_TIME_MS = 3000.0;

/**
 * Animate the Home component
 * @param homeComponent
 */
function* animateIntro(homeComponent: HTMLElement) {
    TweenLite.fromTo(
        homeComponent,
        INTRO_TIME_MS / 1000,
        { backgroundColor: "black" },
        { backgroundColor: "white" },
    );
    yield delay(INTRO_TIME_MS);
    yield put({
        payload: {},
        type: ACTION_TYPES.START_ANIMATION_SUCCESS,
    });
}

/**
 * Repsond to to animation requests
 *
 * @export
 */
export function* animationSaga() {
    yield takeLatest(
        ACTION_TYPES.START_ANIMATION_REQUEST,
        (action: IAnimationStartRequest) => {
            return animateIntro(action.payload);
        },
    );
}

// todo: make default export
export function* rootSaga() {
    yield all([animationSaga()]);
}
