export interface IRootState {
    user: IUser;
}
export interface IPermission {
    id: string;
    name: string;
    description?: string;
}
export interface IUser {
    id: string;
    name: string;
    permissions: IPermission[];
}
export declare const Permissions: Map<string, IPermission>;
