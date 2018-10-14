import { IAction } from "../root";
export declare const ACTION_TYPES: {
    START_ANIMATION_REQUEST: string;
    START_ANIMATION_SUCCESS: string;
};
export interface IAnimationStartRequest extends IAction {
    payload: HTMLElement;
}
export declare function animationStartRequestFactory(homeContainer: HTMLElement): IAnimationStartRequest;
