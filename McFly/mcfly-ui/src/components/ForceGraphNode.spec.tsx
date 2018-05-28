import { shallow } from "enzyme";
import * as React from "react";
import ForceGraphNode from "./ForceGraphNode";

import initStoryshots from "@storybook/addon-storyshots";

it("ForceGraphNode", () => {
  const result = shallow(<ForceGraphNode id="a" />).contains("ForceGraphNode");
  expect(result).toBeTruthy();
});
