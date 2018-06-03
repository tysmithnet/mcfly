export type ForceGraphElement = ForceGraphNode | ForceGraphLink;

export interface ForceGraphNode {
  id: string;
  title: string;
}

export interface ForceGraphLink {
  from: string;
  to: string;
}

export const NODE_POSITION_CHANGED = "force-graph/NODE_POSITION_CHANGED";
