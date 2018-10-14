export declare function getHistory(): import("history").History;
export declare const sagaMiddleware: import("redux-saga").SagaMiddleware<{}>;
export declare const store: import("redux").Store<{
    app: import("src/app/app.domain").IRootState;
    auth: import("src/auth/auth.domain").IRootState;
}, import("redux").AnyAction> & {
    dispatch: {};
};
