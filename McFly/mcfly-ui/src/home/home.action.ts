import { IAction } from "../root";

/**
 * Actions for the Home domain
 */
export const ACTION_TYPES = {
    START_ANIMATION_REQUEST: "@home/StartAnimationRequest",
    START_ANIMATION_SUCCESS: "@home/StartAnimationSuccess",
};

/**
 * Represents a request to play the starting animation for the
 * home route.
 *
 * @export
 * @interface IAnimationStartRequest
 * @extends {IAction}
 */
export interface IAnimationStartRequest extends IAction {
    /**
     * Reference to the DOM element that should be animated
     *
     * @type {HTMLElement}
     * @memberof IAnimationStartRequest
     */
    payload: HTMLElement;
}


/**
 * Factory method for animation start requests.
 *
 * @export
 * @param {HTMLElement} homeContainer
 * @returns {IAnimationStartRequest}
 */
export function animationStartRequestFactory(homeContainer: HTMLElement): IAnimationStartRequest {
    return {
        type: ACTION_TYPES.START_ANIMATION_REQUEST,
        payload: homeContainer
    }
}
