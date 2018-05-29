import { action } from "typesafe-actions";
import { ForceGraphNodeState, NODE_POSITION_CHANGED } from "./domain";

export const moveNode = (id: string, cx: number, cy: number) =>
  // tslint:disable-next-line:no-object-literal-type-assertion
  action(NODE_POSITION_CHANGED, { id, cx, cy } as ForceGraphNodeState);
