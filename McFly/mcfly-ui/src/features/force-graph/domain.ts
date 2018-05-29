export type ForceGraphElement = ForceGraphNodeState | ForceGraphLinkState;

export class ForceGraphState {
  public id: string;
  public elements: ForceGraphElement[];
}

export class ForceGraphNodeState {
  public id: string;
  public cx: number;
  public cy: number;
}

export class ForceGraphLinkState {
  public id: string;
  public from: ForceGraphNodeState;
  public to: ForceGraphNodeState;
}

export const NODE_POSITION_CHANGED = "force-graph/NODE_POSITION_CHANGED";
