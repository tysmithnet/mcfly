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

export type WorkerMessage =
  | NewSimulationRequest
  | NewSimulationResponse
  | NodePositionsUpdated
  | UpdateGraphDataRequest
  | UpdateGraphDataResponse;
export interface EventData {
  type: string;
  payload?: WorkerMessage;
}

export interface NewSimulationRequest {
  nodes: ForceGraphNode[];
  links: ForceGraphLink[];
}

export interface NewSimulationResponse {
  addedNodes: Map<string, ForceGraphNode>;
  addedLinks: Map<string, ForceGraphLink>;
}

export interface UpdateGraphDataRequest {
  addNodes: ForceGraphNode[];
  removeNodes: Set<string>;
  addLinks: ForceGraphLink[];
  removeLinks: Set<string>;
}

export interface UpdateGraphDataResponse {
  addedNodes: Set<string>;
  removedNodes: Set<string>;
  addedLinks: Set<string>;
  removedLinks: Set<string>;
}

export type NodePositionsUpdated = Map<string, ArrayLike<number>>;

export enum EVENT_TYPE {
  TICK_REQUEST = "TICK_REQUEST",
  UPDATE_GRAPH_ELEMENTS_REQUEST = "UPDATE_GRAPH_DATA_REQUEST",
  UPDATE_GRAPH_ELEMENTS_RESPONSE = "UPDATE_GRAPH_DATA_RESPONSE",
  NEW_SIMULATION_REQUEST = "NEW_SIMULATION_REQUEST",
  NEW_SIMULATION_RESPONSE = "NEW_SIMULATION_RESPONSE",
  // todo: other request/response pairs
  NODE_POSITIONS_UPDATED = "NODE_POSITIONS_UPDATED"
}

export enum POSITIONS_ARRAY_INDICES {
  X = 0,
  Y = 1,
  Z = 2,
  VX = 3,
  VY = 4,
  VZ = 5
}

export interface MyMessageEvent extends MessageEvent {
  data: EventData;
}

// tslint:disable-next-line:interface-name
export interface IMyWorker {
  onmessage: (this: IMyWorker, ev: MyMessageEvent) => any;
  postMessage(
    this: IMyWorker,
    msg: EventData,
    transferList?: ArrayBuffer[]
  ): any;
  addEventListener(
    type: "message",
    listener: (this: IMyWorker, ev: MyMessageEvent) => any,
    useCapture?: boolean
  ): void;
}
