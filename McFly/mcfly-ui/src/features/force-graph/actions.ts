import { action } from "typesafe-actions";
import { ForceGraphNodeState, NODE_POSITION_CHANGED } from "./domain";

// tslint:disable-next-line:no-object-literal-type-assertion
export const moveNode = (id: string, cx: number, cy: number) =>
  action(NODE_POSITION_CHANGED, { id, cx, cy } as ForceGraphNodeState);
