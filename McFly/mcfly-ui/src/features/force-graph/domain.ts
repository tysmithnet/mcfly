export type ForceGraphElement = ForceGraphNode | ForceGraphLink;

export class ForceGraphNode {
  public id: string;
  public title: string;
}

export class ForceGraphLink {
  public from: string;
  public to: string;
}

export const NODE_POSITION_CHANGED = "force-graph/NODE_POSITION_CHANGED";
