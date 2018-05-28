import { History } from "history";
import {
  routerMiddleware,
  routerReducer,
  RouterState
} from "react-router-redux";
import {
  applyMiddleware,
  combineReducers,
  createStore,
  Reducer,
  Store
} from "redux";
import { composeWithDevTools } from "redux-devtools-extension";
import logger from "redux-logger";

export interface RootState {
  router: RouterState;
}

export const rootReducer: Reducer<RootState> = combineReducers<RootState>({
  router: routerReducer as any
});

export function configureStore(
  history: History,
  initialSate?: RootState
): Store<RootState> {
  const routerMw = routerMiddleware(history);
  const middleware = applyMiddleware(logger, routerMw);
  const store = createStore(
    rootReducer as any,
    initialSate as any,
    middleware
  ) as Store<RootState>;
  return store;
}
