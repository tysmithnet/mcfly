import * as React from "react";
import { shallow } from "enzyme";

import {Hello} from "./Hello";

import initStoryshots from '@storybook/addon-storyshots';
initStoryshots({
    
});

it("renders the heading", () => {
    const result = shallow(<Hello name="world"/>).contains("world");
    expect(result).toBeTruthy();
});