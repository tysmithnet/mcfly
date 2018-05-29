export type ForceGraphElement = ForceGraphNodeState | ForceGraphLinkState;

export interface ForceGraphState {
  id: string;
  elements: ForceGraphElement[];
}

export interface ForceGraphNodeState {
  id: string;
  cx: number;
  cy: number;
}

export interface ForceGraphLinkState {
  id: string;
  from: ForceGraphNodeState;
  to: ForceGraphNodeState;
}

export const NODE_POSITION_CHANGED = "force-graph/NODE_POSITION_CHANGED";
