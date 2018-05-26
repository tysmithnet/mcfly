import * as React from "react";
import {shallow} from "enzyme";
import ForceGraph from "./ForceGraph";
import ForceGraphNode from "./ForceGraphNode";
import initStoryshots from '@storybook/addon-storyshots';

it("renders the heading", () => {
    const result = shallow(
        <ForceGraph>
            <ForceGraphNode />
        </ForceGraph>
    ).contains("ForceGraph");
    expect(result).toBeTruthy();
});