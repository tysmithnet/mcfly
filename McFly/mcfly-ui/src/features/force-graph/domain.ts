export type ForceGraphElement = ForceGraphNode | ForceGraphLink;

export interface ForceGraphNode {
  id: string;
  title: string;
  x?: number;
  y?: number;
  z?: number;
  fx?: number;
  fy?: number;
  fz?: number;
}

export interface ForceGraphLink {
  id: string;
  source: ForceGraphNode;
  target: ForceGraphNode;
}

export const NODE_POSITION_CHANGED = "force-graph/NODE_POSITION_CHANGED";
