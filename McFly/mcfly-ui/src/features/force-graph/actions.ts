import { ActionCreator } from "redux";
import { NodePositionChangedAction } from "./types";

export const nodePositionChanged: ActionCreator<NodePositionChangedAction> = (
  id: string,
  cx: number,
  cy: number
) => ({
  payload: {
    cx,
    cy,
    id
  },
  type: "force-graph/NODE_POSITION_CHANGED"
});
