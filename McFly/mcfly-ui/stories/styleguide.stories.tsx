import { storiesOf } from "@storybook/react";
import * as React from "react";
import {Input} from "../src/primitives";

storiesOf("Forms", module)
  .add("Inputs", () => {
        return (
            <Input />
        );
  });
