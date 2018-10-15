import cx from "classnames";
import * as React from "react";
import { THEME } from "../../theme";
import "./input.styles";
export interface IProps {
    theme?: THEME;
}

export const Input: React.SFC<IProps> = (props) => {
    return (
        <div className={cx("input", props.theme)}>
            <input type="text"/>
            <div className={cx("border", "bot")} />
        </div>
    );
};
