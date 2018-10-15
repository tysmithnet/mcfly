import * as React from "react";
import {Input} from "../primitives";
import { THEME } from "../theme";

export class SearchBar extends React.Component<{}, {}> {
    public render() {
        return (
            <div className="search-bar">
                <Input theme={THEME.DARK} />
            </div>
        );
    }
}
