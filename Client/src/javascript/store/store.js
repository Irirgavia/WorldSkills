import { createStore, applyMiddleware } from "redux";
import thunk from "redux-thunk";
import { createLogger } from "redux-logger";
import mainReducer from "../reducers/reducers.js";

const loggerMiddleware = createLogger();

function configureStore(initialState) {
  return createStore(
    mainReducer,
    initialState,
    applyMiddleware(thunk, loggerMiddleware)
  );
}

export default configureStore;
