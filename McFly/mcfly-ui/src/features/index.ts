import { routerReducer } from "react-router-redux";
import { combineReducers, Dispatch, Reducer } from "redux";

// Import your state types and reducers here.
import { ChatState } from "store/chat/types";
import { LayoutState } from "store/layout/types";
import chatReducer from "store/chat/reducer";
import layoutReducer from "store/layout/reducer";

import { ForceGraphState } from "./force-graph/types";

// The top-level state object
export interface ApplicationState {
  forceGraph: ForceGraphState;
}

// Whenever an action is dispatched, Redux will update each top-level application state property
// using the reducer with the matching name. It's important that the names match exactly, and that
// the reducer acts on the corresponding ApplicationState property type.
export const reducers: Reducer<ApplicationState> = combineReducers<
  ApplicationState
>({
  router: routerReducer,
  chat: chatReducer,
  layout: layoutReducer
});
