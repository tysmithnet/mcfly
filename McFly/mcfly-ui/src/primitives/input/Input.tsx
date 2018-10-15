import * as React from "react";

export const Input: React.SFC<{}> = (props) => {
    return (
        <div className="input">
            <input {...props} />
        </div>
    );
};
