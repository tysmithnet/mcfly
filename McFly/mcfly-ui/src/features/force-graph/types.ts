import { Action } from "redux";

export interface ForceGraphState {
  elements: ForceGraphElement[];
}

export interface ForceGraphElement {
  id: string;
}

export interface ForceGraphNodeState extends ForceGraphElement {
  cx: number;
  cy: number;
}

export interface ForceGraphLinkState extends ForceGraphElement {
  from: ForceGraphNodeState;
  to: ForceGraphNodeState;
}

export interface NodePositionChangedAction extends Action {
  type: "force-graph/NODE_POSITION_CHANGED";
  payload: {
    id: string;
    cx: number;
    cy: number;
  };
}

export type ForceGraphActions = NodePositionChangedAction;
