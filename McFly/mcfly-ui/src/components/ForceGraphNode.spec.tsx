import * as React from "react";
import { shallow } from "enzyme";
import ForceGraphNode from "./ForceGraphNode";

import initStoryshots from '@storybook/addon-storyshots';

it("ForceGraphNode", () => {
    const result = shallow(<ForceGraphNode />).contains("ForceGraphNode");
    expect(result).toBeTruthy();
});