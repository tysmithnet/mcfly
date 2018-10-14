import { connectRouter, routerMiddleware } from "connected-react-router";
import { configure, render } from "enzyme";
import * as Adapter from "enzyme-adapter-react-16";
import { createMemoryHistory } from "history";
import * as React from "react";
import { Provider } from "react-redux";
import { applyMiddleware, compose, createStore } from "redux";
import { IUser, Permissions } from "../auth";
import { reducer } from "../root";
import { App } from "./App";
import { routes } from "./routes";

configure({ adapter: new (Adapter as any)() });

// todo: move to setup file
beforeAll(() => {
    (global as any).Worker = function(args: any) {
        this.onmessage = () => { };

        this.postMessage = (msg: any) => { };
    };
});

function createTestStore() {
    const history = createMemoryHistory();
    const store = createStore(
        connectRouter(history)(reducer), // new root reducer with router state
        {},
        compose(applyMiddleware(routerMiddleware(history))),
    );
    return store;
}

function createApp(user: IUser): React.ReactElement<any> {
    const store = createTestStore();
    return (
        <Provider store={store}>
            <App user={user} routes={routes} />
        </Provider>
    );
}

test("Shows admin only if the user has permissions", () => {
    const user: IUser = {
        id: "admin",
        name: "Admin",
        permissions: [Permissions.get("ADMIN")],
    };
    expect(render(createApp(user)).find(".secret")).toBeTruthy();
    expect(render(createApp(null)).find(".not-found")).toBeTruthy();
});
