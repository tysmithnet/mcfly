import { ActionType, getType } from "typesafe-actions";

import { v4 } from "uuid";

import * as ForceGraphActions from "./actions";
import {
  ForceGraphLinkState,
  ForceGraphNodeState,
  ForceGraphState,
  NODE_POSITION_CHANGED
} from "./domain";

export type ForceGraphAction = ActionType<typeof ForceGraphActions>;

export default (
  state: ForceGraphState,
  action: ForceGraphAction
): ForceGraphState => {
  switch (action.type) {
    case getType(ForceGraphActions.moveNode):
      break;
  }

  return { ...state };
};
