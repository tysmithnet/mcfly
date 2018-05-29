import { ActionType, getType } from "typesafe-actions";

import { v4 } from "uuid";

import * as ForceGraphActions from "./actions";
import {
  ForceGraphLinkState,
  ForceGraphNodeState,
  ForceGraphState,
  NODE_POSITION_CHANGED
} from "./domain";
import ForceGraphNode from "./ForceGraphNode";

export type ForceGraphAction = ActionType<typeof ForceGraphActions>;

export default (
  state: ForceGraphState,
  action: ForceGraphAction
): ForceGraphState => {
  switch (action.type) {
    case NODE_POSITION_CHANGED:
      const clone = { ...state, elements: [...state.elements] };
      const idx = clone.elements.findIndex(e => e.id === action.payload.id);
      if (idx > -1 && clone.elements[idx] instanceof ForceGraphNodeState) {
        const node = {...clone.elements[idx]} as ForceGraphNodeState;
        node.cx = action.payload.cx;
        node.cy = action.payload.cy;
        clone.elements[idx] = node;
      }
      break;
  }

  return { ...state };
};
