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
  source: string;
  target: string;
}

export const NODE_POSITION_CHANGED = "force-graph/NODE_POSITION_CHANGED";
