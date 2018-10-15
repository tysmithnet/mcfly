import * as React from "react";
import {Input} from ".";

export default [
    {
        component: (props: any) => {
            return (
                <div>
                    Name: <Input {...props} />
                </div>
            );
        },
        name: "Basic",
        namespace: "Primitives/Input",
        props: {
            placeholder: "John Doe",
        },
    },
];
