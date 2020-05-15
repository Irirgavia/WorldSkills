import '../sass/styles.scss';
import ReactDOM from 'react-dom';
import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import App from './app.js'
//import NotFound from './components/notfound.js';
import { createStore, applyMiddleware } from 'redux'
import { Provider } from 'react-redux'
import thunk from 'redux-thunk'
import mainReducer from './reducers/reducers.js'

function configureStore(initialState) {
    return createStore(mainReducer, initialState, applyMiddleware(thunk))
}

const store = configureStore()

render(
    <Provider store={store}>
        <App />
    </Provider>,
    document.getElementById('content')
)