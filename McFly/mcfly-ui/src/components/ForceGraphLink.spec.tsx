import initStoryshots from "@storybook/addon-storyshots";
import { shallow } from "enzyme";
import * as React from "react";
import ForceGraphLink from "./ForceGraphLink";

it("renders the heading", () => {
  const result = shallow(
    <ForceGraphLink x1={0} y1={0} x2={10} y2={10} />
  ).contains("ForceGraphLink");
  expect(result).toBeTruthy();
});
