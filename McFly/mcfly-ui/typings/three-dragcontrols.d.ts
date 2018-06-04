declare module "three-dragcontrols" {
    import {Camera, Mesh} from "three";

    export default class DragControls {
        constructor(objects:Mesh[], camera:Camera, element:HTMLElement);
        addEventListener(eventName: string, handler:(e:DragEvent) => void): void;
    }
}