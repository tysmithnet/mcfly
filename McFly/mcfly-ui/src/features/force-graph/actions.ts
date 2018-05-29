import { action, createAction, createStandardAction } from "typesafe-actions";

import { ForceGraphNodeState, NODE_POSITION_CHANGED } from "./domain";

// CLASSIC API
export const moveNode = (state: ForceGraphNodeState) =>
  action(NODE_POSITION_CHANGED, state);
