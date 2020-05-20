import { RESULTS_SUCCESS, RESULTS_ERROR, SCHEDULE_SUCCESS } from '../constants/constants.js'

const initialState = {
    data: { currentPage: 0, totalPages: 0, pageSize: 0, records: [] },
    error: ''
}

export default function mainReducer(state = initialState, action) {
    switch (action.type) {
        case RESULTS_SUCCESS:
            return { ...state, data: action.competitionResults, error: '' }

        case RESULTS_ERROR:
            return { ...state, error: action.error }
        
        case SCHEDULE_SUCCESS:
            return { ...state, data: action.competitionResults, error: '' }

        case SCHEDULE_ERROR:
            return { ...state, error: action.error }
            
        default:
            return state;
    }
}