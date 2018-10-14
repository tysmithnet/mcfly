import { Link } from "react-router-dom";
import { IUser } from "../auth";
import { IBaseProps } from "../root";

/**
 * Props for Menu
 */
export interface IProps extends IBaseProps {
    /**
     * Links to display
     */
    links: Link[];

    /**
     * Currently logged in user
     */
    user: IUser;
}

/**
 * State for Menu
 */
export interface IState {
    /**
     * Currently entered id
     */
    id: string;

    /**
     * Currently entered password
     */
    password: string;
}
