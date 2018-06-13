import MyWorkerImport = require("worker-loader!./worker");
import { MyWorker } from "./my-worker";

export * from "./types";
export default (MyWorkerImport as any) as MyWorker;
