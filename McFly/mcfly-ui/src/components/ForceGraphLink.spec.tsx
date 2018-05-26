import * as React from "react";
import {shallow} from "enzyme";
import ForceGraphLink from "./ForceGraphLink";
import initStoryshots from '@storybook/addon-storyshots';

it("renders the heading", () => {
    const result = shallow(
        <ForceGraphLink />
    ).contains("ForceGraphLink");
    expect(result).toBeTruthy();
});