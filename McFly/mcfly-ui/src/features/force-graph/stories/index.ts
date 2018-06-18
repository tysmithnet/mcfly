import { v4 } from "uuid";
import { ForceGraphLink, ForceGraphNode } from "../domain";
export * from "./add-nodes";
export * from "./empty";
export * from "./extra-large-graph";
export * from "./large-graph";
export * from "./medium-graph";
export * from "./single-link";
export * from "./single-node";
export * from "./small-graph";

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
