import * as React from "react";
import { shallow } from "enzyme";

import {Hello} from "./Hello";

it("renders the heading", () => {
    const result = shallow(<Hello name="world"/>).contains("world");
    expect(result).toBeTruthy();
});