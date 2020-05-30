import { createStore, applyMiddleware } from 'redux'
import thunk from 'redux-thunk'
import mainReducer from '../reducers/reducers.js'

function configureStore(initialState) {
    return createStore(
    mainReducer,
    initialState,
    applyMiddleware(thunk));
  }

export default configureStore