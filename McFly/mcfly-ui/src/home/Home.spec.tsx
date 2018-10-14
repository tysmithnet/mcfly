import { configure, render } from "enzyme";
import * as Adapter from "enzyme-adapter-react-16";
import * as React from "react";
import { Provider } from "react-redux";
import configureStore from "redux-mock-store";
import { Home } from "./Home";

configure({ adapter: new (Adapter as any)() });

function createHome(createWorker?: () => Worker): React.ReactElement<any> {
    const mockStore = configureStore([]);
    const store = mockStore({});
    return (
        <Provider store={store}>
            <Home createWorker={createWorker} />
        </Provider>
    );
}

beforeAll(() => {
    (global as any).Worker = function(args: any) {
        this.onmessage = () => { };

        this.postMessage = (msg: any) => { };
    };
});

test("Sanity", () => {
    // todo: extract to factory method
    const worker: Worker = {
        addEventListener: jest.fn(),
        dispatchEvent: jest.fn(),
        onerror: jest.fn(),
        onmessage: jest.fn(),
        postMessage: jest.fn(),
        removeEventListener: jest.fn(),
        terminate: jest.fn(),
    };
    expect(render(createHome(() => worker)).find(".root")).toBeTruthy();
});
