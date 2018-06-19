import {
  forceCenter,
  forceLink,
  forceManyBody,
  forceSimulation,
  Simulation,
  SimulationLinkDatum,
  SimulationNodeDatum
} from "d3-force-3d";
import { ForceGraphLink, ForceGraphNode } from "../domain";
import { EVENT_TYPE, IMyWorker, NodePositionsUpdated } from "./types";

export class Simulator {
  private simulation: Simulation<
    SimulationNodeDatum,
    SimulationLinkDatum<SimulationNodeDatum>
  >;
  private worker: IMyWorker;
  private nodes: ForceGraphNode[];
  private links: ForceGraphLink[];

  constructor(
    nodes: ForceGraphNode[],
    links: ForceGraphLink[],
    worker: IMyWorker
  ) {
    this.nodes = nodes;
    this.links = links;
    this.worker = worker;
    this.simulation = forceSimulation(nodes, 3)
      .force("charge", forceManyBody())
      .force("link", forceLink(links))
      .force("center", forceCenter());
    this.simulation.stop();
  }

  public tick(): void {
    this.simulation.tick();
    const data: NodePositionsUpdated = new Map<string, ArrayLike<number>>();
    this.simulation
      .nodes()
      .forEach(e => data.set(e.id, [e.x, e.y, e.z, e.vx, e.vy, e.vz]));
    const message = { type: EVENT_TYPE.NODE_POSITIONS_UPDATED, payload: data };
    this.worker.postMessage(message);
  }

  public stop(): void {
    this.simulation.stop();
  }

  public updateGraph(
    addedNodes: ForceGraphNode[],
    removedNodes: Set<string>,
    addedLinks: ForceGraphLink[],
    removedLinks: Set<string>
  ): void {
    const removedNodesReply: ForceGraphNode[] = [];
    const remainingNodes: ForceGraphNode[] = [];
    this.nodes.forEach((e, i) => {
      if (removedNodes.has(e.id)) {
        removedNodesReply.push(e);
      } else {
        remainingNodes.push(e);
      }
    });
    addedNodes.forEach((e, i) => {
      e.vx = Math.random() * 50;
      e.vy = Math.random() * 50;
      e.vz = Math.random() * 50;
    });
    this.nodes = [...remainingNodes, ...addedNodes];
    const removedLinksReply: ForceGraphLink[] = [];
    const remainingLinks: ForceGraphLink[] = [];
    this.links.forEach((e, i) => {
      if (removedLinks.has(e.id)) {
        removedLinksReply.push(e);
      } else {
        remainingLinks.push(e);
      }
    });
    this.links = [...remainingLinks, ...addedLinks];
    this.simulation = forceSimulation(this.nodes, 3)
      .force("charge", forceManyBody())
      .force("link", forceLink(this.links))
      .force("center", forceCenter());
    this.worker.postMessage({
      payload: {
        addedLinks: [...addedLinks],
        addedNodes: [...addedNodes],
        removedLinks: [...removedLinksReply],
        removedNodes: [...removedNodesReply]
      },
      type: EVENT_TYPE.UPDATE_GRAPH_ELEMENTS_RESPONSE
    });
  }
}
