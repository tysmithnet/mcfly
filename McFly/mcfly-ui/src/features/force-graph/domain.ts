import { v4 } from "uuid";

export type ForceGraphElement = ForceGraphNode | ForceGraphLink;

export interface ForceGraphNode {
  id: string;
  title?: string;
  x?: number;
  y?: number;
  z?: number;
  vx?: number;
  vy?: number;
  vz?: number;
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

export function generateRandomGraph(
  numNodes: number,
  numLinks: number
): { nodes: ForceGraphNode[]; links: ForceGraphLink[] } {
  const nodes: ForceGraphNode[] = [];
  const links: ForceGraphLink[] = [];

  for (let i = 0; i < numNodes; i++) {
    nodes.push({ id: v4() });
  }

  while (links.length < numLinks) {
    const lhs = Math.floor(Math.random() * numNodes);
    const rhs = Math.floor(Math.random() * numNodes);
    if (lhs === rhs) {
      continue;
    }
    links.push({ id: v4(), source: nodes[lhs], target: nodes[rhs] });
  }

  return { nodes, links };
}
