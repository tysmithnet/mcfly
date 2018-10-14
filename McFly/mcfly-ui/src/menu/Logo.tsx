import * as React from "react";
import "./logo.styles";

export class Logo extends React.Component<{}, {}> {
    public render() {
        return (
            <svg
                className="logo"
                version="1.1"
                xmlns="http://www.w3.org/2000/svg"
                x="0px"
                y="0px"
                viewBox="0 0 410.7 214.7"
            >
                <g className="wings">
                    <path
                        d="M137.2,70.2v23.5H15.4c-4.6,0-8.4-5.3-8.4-11.7c0-6.5,3.8-11.7,8.4-11.7H137.2z"
                    />
                    <path
                        d="M137.2,95.4v23.5H51.3c-3.3,0-5.9-5.3-5.9-11.7c0-6.5,2.7-11.7,5.9-11.7H137.2z"
                    />
                    <path
                        d="M137.2,121v23.5H76.3c-2.3,0-4.2-5.3-4.2-11.7c0-6.5,1.9-11.7,4.2-11.7H137.2z"
                    />
                </g>
                <g className="wings">
                    <path
                        d="M273.6,70.2v23.5h121.7c4.6,0,8.4-5.3,8.4-11.7c0-6.5-3.8-11.7-8.4-11.7H273.6z"
                    />
                    <path
                        d="M273.6,95.4l0,23.5h85.9c3.3,0,5.9-5.3,5.9-11.7c0-6.5-2.7-11.7-5.9-11.7H273.6z"
                    />
                    <path
                        d="M273.6,121v23.5h60.9c2.3,0,4.2-5.3,4.2-11.7c0-6.5-1.9-11.7-4.2-11.7H273.6z"
                    />
                </g>
                <g className="circle">
                    <circle cx="203.4" cy="107.4" r="100.4" />
                </g>
                <g className="arms">
                    <path
                        d="M200.7,106.6v6H251c1.9,0,3.5-1.3,3.5-3c0-1.6-1.6-3-3.5-3H200.7z"
                    />
                    <path
                        d="M199.8,112.6l4.8-3.5l-46.1-63.5c-1.8-2.4-4.3-3.6-5.6-2.6c-1.3,1-1,3.7,0.8,6.1L199.8,112.6z"
                    />
                </g>
            </svg>
        );
    }
}
