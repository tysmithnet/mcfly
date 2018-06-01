import { ActionType, getType } from "typesafe-actions";

import { v4 } from "uuid";

import * as ForceGraphActions from "./actions";
import { NODE_POSITION_CHANGED } from "./domain";

import { State as ForceGraphState } from "./ForceGraph";

export type ForceGraphAction = ActionType<typeof ForceGraphActions>;

export default (
  state: ForceGraphState,
  action: ForceGraphAction
): ForceGraphState => {
  switch (action.type) {
  }

  return { ...state };
};
