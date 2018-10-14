import * as React from "react";
import { connect } from "react-redux";
import { IBaseProps, IRootState } from "../root";
import { ACTION_TYPES } from "./home.action";
import { createWorker } from "./home.worker-factory";

/**
 * Landing page of the application
 *
 * @export
 * @class Home
 * @extends {React.Component<IBaseProps>}
 */
export class Home extends React.Component<IBaseProps> {
    private ref: React.RefObject<HTMLDivElement>;
    private worker: Worker;

    /**
     * Creates an instance of Home.
     * @param {IBaseProps} props
     * @memberof Home
     */
    constructor(props: IBaseProps) {
        super(props);
        this.ref = React.createRef();
        this.worker = props.createWorker ? props.createWorker() : createWorker();
        this.worker.onmessage = message => {
            console.log(message.data);
        };
        setInterval(() => {
            this.worker.postMessage("ping");
        }, 20000);
    }

    /**
     * Hook into the mount event
     *
     * @override
     * @memberof Home
     */
    public componentDidMount() {
        this.props.dispatch({
            payload: this.ref.current,
            type: ACTION_TYPES.START_ANIMATION_REQUEST,
        });
    }

    /**
     * Render the component
     *
     * @returns
     * @memberof Home
     */
    public render() {
        return (
            <div className={"home"} ref={this.ref}>
                hi
      </div>
        );
    }
}

/**
 * Mapping function for the root state
 *
 * @param {IRootState} state
 * @returns {IBaseProps}
 */
function mapStateToProps(state: IRootState): IBaseProps {
    return {};
}

export const connectedComponent = connect(mapStateToProps)(Home);
