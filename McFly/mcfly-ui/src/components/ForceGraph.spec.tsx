import * as React from "react";
import { shallow } from "enzyme";
import ForceGraph from "./ForceGraph";
import ForceGraphNode from "./ForceGraphNode";
import initStoryshots from "@storybook/addon-storyshots";
import { v4 } from "uuid";

it("renders the heading", () => {
  const result = shallow(
    <ForceGraph width={100} height={100}>
      <ForceGraphNode id="a" />
    </ForceGraph>
  ).contains("ForceGraph");
  expect(result).toBeTruthy();
});
