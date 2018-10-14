const g = global as any;

beforeAll(() => {
    console.log = () => { };
});

test("worker responds to ping requests", () => {
    g.postMessage = jest.fn();
    g.onmessage = () => { };
    require("./home.worker");
    g.onmessage({ data: "ping" });
    expect(postMessage).toHaveBeenCalledWith("pong");
});
