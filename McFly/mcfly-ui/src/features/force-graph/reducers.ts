import { Reducer } from "redux";
import {
    ForceGraphActions,
  ForceGraphLinkState,
  ForceGraphNodeState,
  ForceGraphState,
} from "./types";
import ForceGraph from "./ForceGraph";

// Type-safe initialState!
export const initialState: ForceGraphState = {
    elements: []
};

// Unfortunately, typing of the `action` parameter seems to be broken at the moment.
// This should be fixed in Redux 4.x, but for now, just augment your types.

const reducer: Reducer<ForceGraphState> = (
  state: ForceGraphState = initialState,
  action
) => {
  // We'll augment the action type on the switch case to make sure we have
  // all the cases handled.
  switch ((action as ForceGraphActions).type) {
    case "force-graph/NODE_POSITION_CHANGED":
        const clone = { ...state };
        const element = clone.elements.find((x) => x.id === action.payload.id) as ForceGraphNodeState;
        
      return { ...state, username: action.payload.username };
    default:
      return state;
  }
};

export default reducer;
