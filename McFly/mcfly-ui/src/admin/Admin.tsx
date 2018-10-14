import * as React from "react";

/**
 * Route demonstrating permission based access to parts of the application
 *
 * SECURITY NOTE:
 * It shouldn't have to be said, but it does. Do NOT rely on this for anything
 * that is the least bit important. Your APIs should control the security, but
 * this makes for a convenient paradigm for limiting access to certain areas
 * of the application.
 *
 * @export
 * @class Admin
 * @extends {React.Component<{}>}
 */
export class Admin extends React.Component<{}> {
    /**
     * Render the component
     *
     * @returns
     * @memberof Admin
     */
    public render() {
        return <h1 className="secret">SECRET!!!</h1>;
    }
}
