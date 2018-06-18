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
  | RemoveNodeRequest
  | NodePositionsUpdated
  | UpdateGraphDataRequest;
export interface EventData {
  type: string;
  payload?: WorkerMessage;
}

export interface NewSimulationRequest {
  nodes: ForceGraphNode[];
  links: ForceGraphLink[];
}

export interface UpdateGraphDataRequest {
  addedNodes: ForceGraphNode[];
  removedNodes: Set<string>;
  addedLinks: ForceGraphLink[];
  removedLinks: Set<string>;
}

export interface RemoveNodeRequest {
  target: string | ForceGraphNode;
}

export type NodePositionsUpdated = Map<string, ArrayLike<number>>;

export enum EVENT_TYPE {
  TICK_REQUEST = "TICK_REQUEST",
  UPDATE_GRAPH_DATA_REQUEST = "UPDATE_GRAPH_DATA_REQUEST",
  NEW_SIMULATION_REQUEST = "NEW_SIMULATION_REQUEST",
  NODE_POSITIONS_UPDATED = "NODE_POSITIONS_UPDATED",
  REMOVE_NODE_REQUEST = "REMOVE_NODE_REQUEST"
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
