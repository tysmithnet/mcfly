import { map, Map as D3Map } from "d3-collection";
import {
  forceCenter,
  forceLink,
  forceManyBody,
  forceSimulation,
  Simulation,
  SimulationLinkDatum,
  SimulationNodeDatum
} from "d3-force-3d";
import { reduceRight, values } from "lodash";
import { ForceGraphLink, ForceGraphNode } from "../domain";
import {
  EVENT_TYPE,
  IMyWorker,
  NodePositionsUpdated,
  UpdateGraphDataResponse
} from "./types";

type NodeMap = Map<string, ForceGraphNode>;
type LinkMap = Map<string, ForceGraphLink>;

export class Simulator {
  private simulation: Simulation<
    SimulationNodeDatum,
    SimulationLinkDatum<SimulationNodeDatum>
  >;
  private worker: IMyWorker;
  private nodes: D3Map<ForceGraphNode>;
  private links: D3Map<ForceGraphLink>;
  private nodeToLinkMapping = new Map<string, Set<string>>();

  constructor(
    nodes: ForceGraphNode[],
    links: ForceGraphLink[],
    worker: IMyWorker
  ) {
    const addedNodes = new Map<string, ForceGraphNode>();
    const addedLinks = new Map<string, ForceGraphLink>();
    this.nodes = reduceRight(
      nodes,
      (agg, itr) => {
        // 1. Set the node in the aggregate collection
        agg.set(itr.id, itr);
        addedNodes.set(itr.id, itr);
        return agg;
      },
      map<ForceGraphNode>()
    );
    this.links = reduceRight(
      links,
      (agg, itr) => {
        // 1. Set the link in the aggregate collection
        agg.set(itr.id, itr);
        addedLinks.set(itr.id, itr);

        // 2. Add the link to both of the endpoints' link collection
        // this will be used for fast lookup when modifying the graph
        if (!this.nodeToLinkMapping.has(itr.id)) {
          this.nodeToLinkMapping.set(itr.id, new Set<string>());
        }
        const cur = this.nodeToLinkMapping.get(itr.id);
        cur.add(itr.source);
        cur.add(itr.target);
        return agg;
      },
      map<ForceGraphLink>()
    );

    this.worker = worker;
    this.simulation = forceSimulation(this.nodes, 3)
      .force("charge", forceManyBody())
      .force("link", forceLink(links))
      .force("center", forceCenter());
    this.simulation.stop();
    console.log("[ws] NEW_SIMULATION_RESPONSE");
    this.worker.postMessage({
      payload: {
        addedLinks,
        addedNodes
      },
      type: EVENT_TYPE.NEW_SIMULATION_RESPONSE
    });
  }

  public tick(): void {
    this.simulation.tick();
    const data: NodePositionsUpdated = new Map<string, ArrayLike<number>>();
    this.nodes.each((e, i) => data.set(i, [e.x, e.y, e.z, e.vx, e.vy, e.vz]));
    const message = { type: EVENT_TYPE.NODE_POSITIONS_UPDATED, payload: data };
    console.log("[ws] NODE_POSITIONS_UPDATED");
    this.worker.postMessage(message);
  }

  public stop(): void {
    this.simulation.stop();
  }

  /*
  Update the nodes and links in the the simulation is to run
  If the same element appears in both the list to remove and to add
  then the removal is performed first and then addition. This means
  that it is possible for the response to list that a single node has been
  removed and added, which is accurate.
  You should react to the properties in this order:
  1. removedNodes
  2. removedLinks
  3. addedNodes
  4. addedLinks
  */
  public updateGraph(
    nodesToBeAdded: ForceGraphNode[],
    nodesToBeRemoved: Set<string>,
    linksToBeAdded: ForceGraphLink[],
    linksToBeRemoved: Set<string>
  ): void {
    const addedNodes = new Set<string>();
    const addedLinks = new Set<string>();
    const removedNodes = new Set<string>();
    const removedLinks = new Set<string>();

    nodesToBeRemoved.forEach(e => {
      const node = this.nodes.get(e);
      if (node) {
        if (this.removeNode(e)) {
          removedNodes.add(e);
        }
      }
    });

    linksToBeRemoved.forEach(e => {
      const link = this.links.get(e);
      if (link) {
        if (this.removeLink(e)) {
          removedLinks.add(e);
        }
      }
    });

    nodesToBeAdded.forEach(e => {
      if (this.addNode(e)) {
        addedNodes.add(e.id);
      }
    });

    linksToBeAdded.forEach(e => {
      if (this.addLink(e)) {
        addedLinks.add(e.id);
      }
    });

    const allNodes = Array.from(this.nodes.values());
    const allLinks = Array.from(this.links.values());
    this.simulation = forceSimulation(allNodes, 3)
      .force("charge", forceManyBody())
      .force("link", forceLink(allLinks))
      .force("center", forceCenter());

    const payload = {
      addedLinks,
      addedNodes,
      removedLinks,
      removedNodes
    };
    console.log("[ws] UPDATE_GRAPH_ELEMENTS_RESPONSE");
    this.worker.postMessage({
      payload,
      type: EVENT_TYPE.UPDATE_GRAPH_ELEMENTS_RESPONSE
    });
  }

  private addNode(node: ForceGraphNode): boolean {
    const exists = this.nodes.has(node.id);
    if (exists) {
      return false;
    }
    this.nodes.set(node.id, node);
    this.nodeToLinkMapping.set(node.id, new Set<string>());
  }

  private addLink(link: ForceGraphLink): boolean {
    const exists = this.links.has(link.id);
    if (exists) {
      return false;
    }
    this.links.set(link.id, link);

    const sourceSet = this.nodeToLinkMapping.get(link.source);
    if (sourceSet) {
      sourceSet.add(link.id);
    }

    const targetSet = this.nodeToLinkMapping.get(link.target);
    if (targetSet) {
      targetSet.add(link.id);
    }
  }

  private removeNode(id: string): boolean {
    const node = this.nodes.get(id);
    if (!node) {
      return false;
    }
    const links = this.nodeToLinkMapping.get(id);
    links.forEach(e => this.removeLink(e));
    this.nodes.remove(id);
    return true;
  }

  private removeLink(id: string): boolean {
    const link = this.links.get(id);
    if (!link) {
      return false;
    }

    if (link.source) {
      const set = this.nodeToLinkMapping.get(link.source);
      set.delete(link.id);
    }

    if (link.target) {
      const set = this.nodeToLinkMapping.get(link.target);
      set.delete(link.id);
    }

    this.links.remove(id);
    return true;
  }
}
