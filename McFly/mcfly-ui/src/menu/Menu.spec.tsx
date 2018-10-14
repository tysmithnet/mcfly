import { connectRouter, routerMiddleware } from "connected-react-router";
import { configure, render } from "enzyme";
import * as Adapter from "enzyme-adapter-react-16";
import { createMemoryHistory } from "history";
import * as React from "react";
import { Provider } from "react-redux";
import { applyMiddleware, compose, createStore } from "redux";
import { IUser, Permissions } from "../auth";
import { reducer } from "../root";
import { Menu } from "./Menu";

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

test("Should show username and password box if no user is logged in", () => {
    const menu = render(<Menu links={[]} user={null} />);
    expect(menu).toMatchSnapshot();
});