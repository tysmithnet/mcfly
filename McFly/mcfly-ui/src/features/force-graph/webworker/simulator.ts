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
    this.nodes = this.nodes.filter((e, i) => {
      return !removedNodes.has(e.id);
    });
    addedNodes.forEach((e, i) => {
      e.vx = Math.random() * 50;
      e.vy = Math.random() * 50;
      e.vz = Math.random() * 50;
    });
    this.nodes = [...this.nodes, ...addedNodes];
    this.links = this.links.filter((e, i) => {
      return !removedLinks.has(e.id);
    });
    this.links = [...this.links, ...addedLinks];
    this.simulation = forceSimulation(this.nodes, 3)
      .force("charge", forceManyBody())
      .force("link", forceLink(this.links))
      .force("center", forceCenter());
  }
}
