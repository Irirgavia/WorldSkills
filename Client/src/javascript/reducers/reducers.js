import * as constants from '../constants/constants.js'

const initialState = {
    data: [],
    user: {id: 0, login: "", role: ""},
    isSignedIn: false,
    isFetching: false,
    error: ''
}

export default function mainReducer(state = initialState, action) {
    switch (action.type) {
        case constants.RESULTS_BY_YEAR_REQUEST:
            return {...state, data: [], isFetching: true}

        case constants.RESULTS_BY_YEAR_SUCCESS:
            return { ...state, data: action.competitionResults, isFetching: false, error: '' }

        case constants.RESULTS_BY_YEAR_ERROR:
            return { ...state, isFetching: false, error: action.error }
            

        case constants.ACTUAL_SCHEDULE_REQUEST:
            return {...state, data: [], isFetching: true}
        
        case constants.ACTUAL_SCHEDULE_SUCCESS:
            return { ...state, data: action.schedule, isFetching: false, error: '' }

        case constants.ACTUAL_SCHEDULE_ERROR:
            return { ...state, isFetching: false, error: action.error }
            
            
        case constants.USER_REQUEST:
            return {...state, data: [], isFetching: true, isSignedIn: false, user: {id: 0, login: "", role: ""} }
        
        case constants.USER_WRONG_PASSWORD:
            return { ...state, isFetching: false, error: 'Password is wrong.', isSignedIn: false, user: {id: 0, login: "", role: ""} }
        
        case constants.USER_NOT_FOUND:
            return { ...state, isFetching: false, error: 'User is not found.', isSignedIn: false, user: {id: 0, login: "", role: ""} }
        
        case constants.USER_SUCCESS:
            return { ...state, isFetching: false, error: '', isSignedIn: true, user: {id: action.user.Id, login: action.user.Login, role: action.user.Role} }

        case constants.USER_ERROR:
            return { ...state, isFetching: false, error: action.error, isSignedIn: false, user: {id: 0, login: "", role: ""} }

        case constants.USER_LOGOUT:
            return { ...state, isFetching: false, error: '', isSignedIn: false, user: {id: 0, login: "", role: ""} }
                
        default:
            return state;
    }
}