import * as React from "react";
import { shallow } from "enzyme";
import ForceGraphLink from "./ForceGraphLink";
import initStoryshots from "@storybook/addon-storyshots";

it("renders the heading", () => {
  const result = shallow(
    <ForceGraphLink x1={0} y1={0} x2={10} y2={10} />
  ).contains("ForceGraphLink");
  expect(result).toBeTruthy();
});
