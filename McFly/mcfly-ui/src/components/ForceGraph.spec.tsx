import initStoryshots from "@storybook/addon-storyshots";
import { shallow } from "enzyme";
import * as React from "react";
import { v4 } from "uuid";
import ForceGraph from "./ForceGraph";
import ForceGraphNode from "./ForceGraphNode";

it("renders the heading", () => {
  const result = shallow(
    <ForceGraph width={100} height={100}>
      <ForceGraphNode id="a" />
    </ForceGraph>
  ).contains("ForceGraph");
  expect(result).toBeTruthy();
});
