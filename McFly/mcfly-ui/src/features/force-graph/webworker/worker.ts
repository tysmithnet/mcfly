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
import { Simulator } from "./simulator";
import {
  EVENT_TYPE,
  EventData,
  IMyWorker,
  NewSimulationRequest,
  RemoveNodeRequest
} from "./types";

const ctx: IMyWorker = self as any;

let simulator: Simulator = null;

ctx.onmessage = event => {
  const eventData = event.data;
  switch (eventData.type) {
    case EVENT_TYPE.NEW_SIMULATION_REQUEST:
      console.log("New simulation requested");
      const newSimulationRequest = eventData.payload as NewSimulationRequest;
      simulator = new Simulator(
        newSimulationRequest.nodes,
        newSimulationRequest.links,
        ctx
      );
      break;
    case EVENT_TYPE.REMOVE_NODE_REQUEST:
      console.log("Remove node requested");
      const removeNodeRequest = eventData.payload as RemoveNodeRequest;
      break;
    case EVENT_TYPE.TICK_REQUEST:
      console.log("Tick requested");
      simulator.tick();
  }
};
