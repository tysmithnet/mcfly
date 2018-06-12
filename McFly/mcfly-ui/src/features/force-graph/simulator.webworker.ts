import {
  forceCenter,
  forceLink,
  forceManyBody,
  forceSimulation,
  Simulation,
  SimulationLinkDatum,
  SimulationNodeDatum
} from "d3-force-3d";
import { ForceGraphLink, ForceGraphNode } from "./domain";

const ctx: Worker = self as any;
let simulator: Simulator = null;

ctx.addEventListener("message", event => {
  console.log(event);
  if (!event.data || !event.data.type) {
    console.error(`Unrecognized object format, requires a type`);
    return;
  }

  const eventData = event.data as EventData;
  switch (eventData.type) {
    case NEW_SIMULATION_REQUEST:
      console.log("New simulation requested");
      const newSimulationRequest = eventData.payload as NewSimulationRequest;
      simulator = new Simulator(
        newSimulationRequest.nodes,
        newSimulationRequest.links
      );
      break;
    case REMOVE_NODE_REQUEST:
      console.log("Remove node requested");
      const removeNodeRequest = eventData.payload as RemoveNodeRequest;
      break;
    case TICK_REQUEST:
      console.log("Tick requested");
      simulator.tick();
  }
});

export interface EventData {
  type: string;
  payload?: NewSimulationRequest | RemoveNodeRequest | NodePositionsUpdated;
}

export const TICK_REQUEST = "TICK_REQUEST";

export const NEW_SIMULATION_REQUEST = "NEW_SIMULATION_REQUEST";
export interface NewSimulationRequest {
  nodes: ForceGraphNode[];
  links: ForceGraphLink[];
}

export const REMOVE_NODE_REQUEST = "REMOVE_NODE_REQUEST";
export interface RemoveNodeRequest {
  target: string | ForceGraphNode;
}

export const NODE_POSITIONS_UPDATED = "NODE_POSITIONS_UPDATED";
export type NodePositionsUpdated = Map<string, ArrayLike<number>>;

export enum PositionsArrayIndices {
  x = 0,
  y = 1,
  z = 2,
  vx = 3,
  vy = 4,
  vz = 5
}

class Simulator {
  private simulation: Simulation<
    SimulationNodeDatum,
    SimulationLinkDatum<SimulationNodeDatum>
  >;

  constructor(nodes: ForceGraphNode[], links: ForceGraphLink[]) {
    this.simulation = forceSimulation(nodes, 3)
      .force("charge", forceManyBody())
      .force("link", forceLink(links))
      .force("center", forceCenter());
    this.simulation.stop();
  }

  public tick(): void {
    this.simulation.tick();
  }

  public stop(): void {
    this.simulation.stop();
  }
}
