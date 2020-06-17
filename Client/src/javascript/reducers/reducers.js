import * as constants from "../constants/constants.js";

const initialState = {
  data: [],
  user: { id: 0, login: "", role: "" },
  isSignedIn: false,
  unreadNotificationAmount: 0,
  isFetching: false,
  error: "",
  stageTypes: [],
  skillNames: [],
};

export default function mainReducer(state = initialState, action) {
  switch (action.type) {
    case constants.DATA_REQUEST:
      return { ...state, data: [], isFetching: true, error: "" };

    case constants.DATA_SUCCESS:
      return { ...state, data: action.data, isFetching: false, error: "" };

    case constants.DATA_SAVE_SUCCESS:
      return { ...state, data: action.data, isFetching: false, error: "" };

    case constants.DATA_ERROR:
      return { ...state, isFetching: false, error: action.error };

    case constants.USER_REQUEST:
      return {
        ...state,
        data: [],
        isFetching: true,
        isSignedIn: false,
        user: { id: 0, login: "", role: "" },
        error: "",
      };

    case constants.USER_WRONG_PASSWORD:
      return {
        ...state,
        isFetching: false,
        error: "Password is wrong.",
        isSignedIn: false,
        user: { id: 0, login: "", role: "" },
      };

    case constants.USER_NOT_FOUND:
      return {
        ...state,
        isFetching: false,
        error: "User is not found.",
        isSignedIn: false,
        user: { id: 0, login: "", role: "" },
      };

    case constants.USER_SUCCESS:
      return {
        ...state,
        isFetching: false,
        error: "",
        isSignedIn: true,
        user: {
          id: action.user.Id,
          login: action.user.Login,
          role: action.user.Role,
        },
        unreadNotificationAmount: action.user.UnreadNotificationAmount,
      };

    case constants.USER_ERROR:
      return {
        ...state,
        isFetching: false,
        error: action.error,
        isSignedIn: false,
        user: { id: 0, login: "", role: "" },
      };

    case constants.USER_LOGOUT:
      return {
        ...state,
        isFetching: false,
        error: "",
        isSignedIn: false,
        user: { id: 0, login: "", role: "" },
      };

    case constants.UNREAD_NOTIFICATION_AMOUNT_REQUEST:
      return {
        ...state,
        unreadNotificationAmount: 0,
        isFetching: true,
        error: "",
      };

    case constants.UNREAD_NOTIFICATION_AMOUNT_SUCCESS:
      return {
        ...state,
        unreadNotificationAmount: action.amount,
        isFetching: false,
        error: "",
      };

    case constants.UNREAD_NOTIFICATION_AMOUNT_ERROR:
      return { ...state, isFetching: false, error: action.error };

    case constants.READ_NOTIFICATION:
      return {
        ...state,
        unreadNotificationAmount: unreadNotificationAmount - 1,
        isFetching: false,
        error: "",
      };

    case constants.SKILL_NAMES_REQUEST:
      return { ...state, isFetching: true, error: "", skillNames: [] };

    case constants.SKILL_NAMES_SUCCESS:
      return {
        ...state,
        skillNames: action.skillNames,
        isFetching: false,
        error: "",
      };

    case constants.SKILL_NAMES_ERROR:
      return { ...state, isFetching: false, error: action.error };

    case constants.STAGE_TYPES_REQUEST:
      return { ...state, isFetching: true, error: "", skillNames: [] };

    case constants.STAGE_TYPES_SUCCESS:
      return {
        ...state,
        stageTypes: action.stageTypes,
        isFetching: false,
        error: "",
      };

    case constants.STAGE_TYPES_ERROR:
      return { ...state, isFetching: false, error: action.error };

    default:
      return state;
  }
}
