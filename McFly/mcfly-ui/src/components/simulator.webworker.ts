const ctx: Worker = self as any;

// Post data to parent thread
ctx.postMessage({ foo: "foo" });

// Respond to message from parent thread
// tslint:disable-next-line:no-console
ctx.addEventListener("message", (event) => console.log(event));