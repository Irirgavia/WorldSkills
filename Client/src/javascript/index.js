import "../sass/styles.scss";
import ReactDOM from "react-dom";
import React from "react";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import App from "./app.js";
import { Provider } from "react-redux";
import configureStore from "./store/store.js";
import { CookiesProvider } from "react-cookie";

/*var store = createStore(mainReducer, applyMiddleware(thunk));
function configureStore(initialState) {
    return createStore(mainReducer, initialState, applyMiddleware(thunk))
}*/

const store = configureStore();

ReactDOM.render(
  <CookiesProvider>
    <BrowserRouter>
      <Provider store={store}>
        <App />
      </Provider>
    </BrowserRouter>
  </CookiesProvider>,
  document.getElementById("main")
);
