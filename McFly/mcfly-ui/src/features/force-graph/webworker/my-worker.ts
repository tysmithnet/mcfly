import { EventData, IMyWorker, MyMessageEvent } from "./types";

export class MyWorker extends Worker implements IMyWorker {
  public onmessage: (this: MyWorker, ev: MyMessageEvent) => any;
  constructor() {
    super(null);
  }
  public postMessage(
    this: MyWorker,
    msg: EventData,
    transferList?: ArrayBuffer[]
  ): any {
    return null;
  }

  public addEventListener(
    type: "message",
    listener: (this: MyWorker, ev: MyMessageEvent) => any,
    useCapture?: boolean
  ): void {
    return null;
  }
}
