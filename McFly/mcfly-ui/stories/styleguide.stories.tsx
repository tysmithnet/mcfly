import { storiesOf } from "@storybook/react";
import * as React from "react";
import {Input} from "../src/primitives";

storiesOf("Input", module)
  .add("Inputs", () => {
        return (
            <Input />
        );
  });
