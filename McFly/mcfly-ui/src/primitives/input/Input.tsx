import * as React from "react";
import "./input.styles";

export const Input: React.SFC<{}> = (props) => {
    return (
        <div className="input">
            <input {...props} />
        </div>
    );
};
