import { ConnectedRouter } from "connected-react-router";
import * as React from "react";
import { hot } from "react-hot-loader";
import { connect } from "react-redux";
import { Route, Switch } from "react-router";
import { Link } from "react-router-dom";
import { Menu } from "../menu/Menu";
import { getHistory, IRootState } from "../root";
import { IProps } from "./app.domain";
import "./app.styles";
import { routes } from "./routes";
import { observe } from "react-performance-observer";
import { isTest } from "../globals";

// register a metric tracking routine
if (!isTest) {
    observe(measurements => {
        for (const measurement of measurements) {
            if (measurement.entryType != "measure") {
                continue;
            }
            console.log(`${measurement.componentName} - ${measurement.duration}`);
            // todo: batch this
            // axios.post("/metrics", {
            //   data: `${measurement.componentName} - ${measurement.duration}`,
            // });
        }
    });
}


/**
 * 404 Page
 */
function fourOhFour() {
    return <h1 className="not-found">Not found!</h1>;
}

/**
 * The root of the application. It's primary responsibility is providing
 * an environment in which more focused components can provide value.
 */
export class App extends React.Component<IProps> {
    /**
     * Render the root of the application
     *
     * @returns {React.ReactNode}
     * @memberof App
     */
    public render(): React.ReactNode {
        const toAdd = routes
            .filter(
                r =>
                    r.permissions.length === 0 ||
                    r.permissions.every(
                        p =>
                            this.props.user &&
                            this.props.user.permissions.some(up => {
                                return p.id === up.id;
                            }),
                    ),
            )
            .map(r => {
                return {
                    link: (
                        <Link key={r.path} to={r.path}>
                            {r.display}
                        </Link>
                    ),
                    route: (
                        <Route
                            key={r.path}
                            path={r.path}
                            component={r.component}
                            exact={r.exact}
                        />
                    ),
                };
            });
        return (
            <div>
                <ConnectedRouter history={getHistory()}>
                    <div>
                        <Menu
                            links={toAdd.map(x => x.link as any)}
                            user={this.props.user}
                            dispatch={this.props.dispatch}
                        />
                        <Switch>
                            {toAdd.map(x => x.route)}
                            <Route render={fourOhFour} />
                        </Switch>
                    </div>
                </ConnectedRouter>
            </div>
        );
    }
}

/**
 * Hook into changes in the state
 * @param state Current state of the application
 */
function mapStateToProps(state: IRootState): IProps {
    return {
        routes: state.app.routes,
        user: state.auth.user,
    };
}

// Setup hot module reloading for the app
// This enables changes to files under development to be instantly reflected
// in the browser
const hotModule = hot(module)(App);
const connectedComponent = connect(mapStateToProps)(hotModule);
export default connectedComponent;
