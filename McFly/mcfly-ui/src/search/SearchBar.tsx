import * as React from "react";

export class SearchBar extends React.Component<{}, {}> {
    public render() {
        return (
            <div className="search-bar">
                <input type="text"/>
                <button>go</button>
            </div>
        );
    }
}
