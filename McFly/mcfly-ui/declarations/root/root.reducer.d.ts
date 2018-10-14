export declare const reducer: import("redux").Reducer<{
    app: import("src/app/app.domain").IRootState;
    auth: import("src/auth/auth.domain").IRootState;
}, import("redux").AnyAction>;
export interface IAction {
    type: string;
}
