import { createStore, applyMiddleware } from 'redux'
import thunk from 'redux-thunk'
import mainReducer from '../reducers/reducers.js'

const configureStore = initialState => {
    console.log("store created");
    return createStore(
    mainReducer,
    initialState,
    applyMiddleware(thunk)
)}

export default configureStore