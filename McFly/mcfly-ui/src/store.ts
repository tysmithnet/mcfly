import { Store, createStore, applyMiddleware } from "redux";
import { History } from "history";

export function configureStore(
  history: History,
  initialSate?: RootState
): Store<RootState> {}
