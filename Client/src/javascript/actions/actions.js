//import { CALL_API, Schemas } from '../middleware/api'
/*import {USER_REQUEST, USER_SUCCESS, USER_FAILURE} from '../constants/constants.js'

const fetchUser = login => ({
    types: [ USER_REQUEST, USER_SUCCESS, USER_FAILURE ],
    login
})

export const loadUser = (login, requiredFields = []) => (dispatch, getState) => {
  const user = getState().entities.users[login]
  if (user && requiredFields.every(key => user.hasOwnProperty(key))) {
    return null
  }

  return dispatch(fetchUser(login))
}*/

import * as constants from "../constants/constants.js";

const ApiUrl = "http://localhost:49263/api";

export function requestData() {
  return {
    type: constants.DATA_REQUEST,
  };
}

export function receiveData(data) {
  return {
    type: constants.DATA_SUCCESS,
    data: data,
  };
}

export function errorReceiveData(err) {
  return {
    type: constants.DATA_ERROR,
    error: err,
  };
}

export function readNotificationAction() {
  return {
    type: constants.READ_NOTIFICATION,
  };
}

//fetch("https://localhost:49263/api/results?skill=skill&stage=stage&year=year")
export function getResultsByYear(skill, stage, year) {
  return (dispatch) => {
    dispatch(requestData());
    let queryTrailer =
      "/results?skill=" + skill + "&stage=" + stage + "&year=" + year;
    return fetch(
      ApiUrl +
        queryTrailer /*"http://localhost:49263/api/results?skill=" + skill + '&stage=' + stage + '&year=' + year*/
    )
      .then((response) => response.json())
      .then((data) => {
        dispatch(receiveData(data));
      })
      .catch((ex) => {
        dispatch(errorReceiveData(ex));
      });
  };
}

//fetch("https://localhost:49263/api/schedule")
export function getSchedule() {
  return (dispatch) => {
    dispatch(requestData());
    let queryTrailer = "/schedule";
    return fetch(
      ApiUrl + queryTrailer /*"http://localhost:49263/api/schedule"*/
    )
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        console.log(data);
        dispatch(receiveData(data));
      })
      .catch((ex) => {
        console.log(ex);
        dispatch(errorReceiveData(ex));
      });
  };
}

export function requestUser() {
  return {
    type: constants.USER_REQUEST,
  };
}

export function receiveUser(data) {
  return {
    type: constants.USER_SUCCESS,
    user: data,
  };
}

export function receiveUserWrongPassword() {
  return {
    type: constants.USER_WRONG_PASSWORD,
  };
}

export function receiveUserNotFound() {
  return {
    type: constants.USER_NOT_FOUND,
  };
}

export function errorReceiveUser(err) {
  return {
    type: constants.USER_ERROR,
    error: err,
  };
}

//fetch("https://localhost:49263/api/user")
export function getUser(login, password) {
  return (dispatch) => {
    dispatch(requestUser());
    let queryTrailer = "/user";
    return fetch(ApiUrl + queryTrailer, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        login: login,
        password: password,
      }),
    })
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        if (data.Status == "NotFound") {
          console.log(data.Status + "NotFound");
          dispatch(receiveUserNotFound());
        } else if (data.Status == "WrongPassword") {
          console.log(data.Status + "WrongPassword");
          dispatch(receiveUserWrongPassword());
        } else if (data.Status == "Success") {
          console.log(data.Status + "Success");
          dispatch(receiveUser(data));
        }
      })
      .catch((ex) => {
        dispatch(errorReceiveUser(ex));
      });
  };
}

export function logoutUserAction() {
  return {
    type: constants.USER_LOGOUT,
  };
}

export function logOutUser() {
  return (dispatch) => {
    dispatch(logoutUserAction());
  };
}

export function getPersonalData(userId) {
  return (dispatch) => {
    dispatch(requestData());
    let queryTrailer = "/personaldata";
    return fetch(ApiUrl + queryTrailer, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ userId: userId }),
    })
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        dispatch(receiveData(data));
      })
      .catch((ex) => {
        dispatch(errorReceiveData(ex));
      });
  };
}

function saveDataPOSTRequest(queryTrailer, data) {
  return (dispatch) => {
    dispatch(requestData());
    return fetch(ApiUrl + queryTrailer, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(data),
    })
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        dispatch(receiveData(data));
      })
      .catch((ex) => {
        dispatch(errorReceiveData(ex));
      });
  };
}

export function savePersonalData(data) {
  let queryTrailer = "/personaldata/update";
  return saveDataPOSTRequest(queryTrailer, data);
}

export function saveMark(data) {
  let queryTrailer = "/mark/save";
  return saveDataPOSTRequest(queryTrailer, data);
}

export function saveAnswer(data) {
  let queryTrailer = "/answer/save";
  return saveDataPOSTRequest(queryTrailer, data);
}

export function saveCompetition(data) {
  let queryTrailer = "/competition/save";
  return saveDataPOSTRequest(queryTrailer, data);
}

export function saveStage(data) {
  let queryTrailer = "/stage/save";
  return saveDataPOSTRequest(queryTrailer, data);
}

export function saveTask(data) {
  let queryTrailer = "/task/save";
  return saveDataPOSTRequest(queryTrailer, data);
}

/*export function savePersonalData(data) {
  return (dispatch) => {
    dispatch(requestData())
      let queryTrailer = '/personaldata/update';
    return fetch(ApiUrl + queryTrailer, {
      method: 'POST',
      headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(data)
    })
    .then((response) => {
      return response.json()
    }).then((data) => {
      dispatch(receiveData(data))
    }).catch((ex) => {
      dispatch(errorReceiveData(ex))
    });
  }
}

export function saveMark(data) {
  return (dispatch) => {
    dispatch(requestData())
      let queryTrailer = '/mark/save';
    return fetch(ApiUrl + queryTrailer, {
      method: 'POST',
      headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(data)
    })
    .then((response) => {
      return response.json()
    }).then((data) => {
      dispatch(receiveData(data))
    }).catch((ex) => {
      dispatch(errorReceiveData(ex))
    });
  }
}

export function saveAnswer(data) {
  return (dispatch) => {
    dispatch(requestData())
      let queryTrailer = '/answer/save';
    return fetch(ApiUrl + queryTrailer, {
      method: 'POST',
      headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(data)
    })
    .then((response) => {
      return response.json()
    }).then((data) => {
      dispatch(receiveData(data))
    }).catch((ex) => {
      dispatch(errorReceiveData(ex))
    });
  }
}*/

export function getAnswersToRate(judgeId) {
  return (dispatch) => {
    dispatch(requestData());
    let queryTrailer = "/answer";
    return fetch(ApiUrl + queryTrailer, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ judgeId: judgeId }),
    })
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        dispatch(receiveData(data));
      })
      .catch((ex) => {
        dispatch(errorReceiveData(ex));
      });
  };
}

export function getCompetitionsByAdmin(adminId) {
  return (dispatch) => {
    dispatch(requestData());
    let queryTrailer = "/competitions/admin";
    return fetch(ApiUrl + queryTrailer, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ adminId: adminId }),
    })
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        dispatch(receiveData(data));
      })
      .catch((ex) => {
        dispatch(errorReceiveData(ex));
      });
  };
}

export function getCompetitionsByParticipant(participantId) {
  return (dispatch) => {
    dispatch(requestData());
    let queryTrailer = "/competitions/participant";
    return fetch(ApiUrl + queryTrailer, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ participantId: participantId }),
    })
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        dispatch(receiveData(data));
      })
      .catch((ex) => {
        dispatch(errorReceiveData(ex));
      });
  };
}

export function getResultsByParticipant(participantId) {
  return (dispatch) => {
    dispatch(requestData());
    let queryTrailer = "/results/participant";
    return fetch(ApiUrl + queryTrailer, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ participantId: participantId }),
    })
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        dispatch(receiveData(data));
      })
      .catch((ex) => {
        dispatch(errorReceiveData(ex));
      });
  };
}

export function getResultsByTrainer(trainerId) {
  return (dispatch) => {
    dispatch(requestData());
    let queryTrailer = "/results/trainer";
    return fetch(ApiUrl + queryTrailer, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ trainerId: trainerId }),
    })
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        dispatch(receiveData(data));
      })
      .catch((ex) => {
        dispatch(errorReceiveData(ex));
      });
  };
}

export function requestUnreadNotificationAmount() {
  return {
    type: constants.UNREAD_NOTIFICATION_AMOUNT_REQUEST,
  };
}

export function receiveUnreadNotificationAmount(count) {
  return {
    type: constants.UNREAD_NOTIFICATION_AMOUNT_SUCCESS,
    amount: count,
  };
}

export function errorReceiveUnreadNotificationAmount(err) {
  return {
    type: constants.UNREAD_NOTIFICATION_AMOUNT_ERROR,
    error: err,
  };
}

//fetch("https://localhost:49263/api/results?skill=skill&stage=stage&year=year")
export function getUnreadNotificationAmount(userId) {
  return (dispatch) => {
    dispatch(requestData());
    let queryTrailer = "/notifications/amount";
    return fetch(ApiUrl + queryTrailer, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ userId: userId }),
    })
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        dispatch(receiveData(data));
      })
      .catch((ex) => {
        dispatch(errorReceiveData(ex));
      });
  };
}

export function readNotification(notificationId, userId) {
  return (dispatch) => {
    dispatch(requestData());
    let queryTrailer =
      "/notifications/read?notificationId" +
      notificationId +
      "&userId" +
      userId;
    return fetch(ApiUrl + queryTrailer)
      .then((response) => {
        dispatch(readNotificationAction());
      })
      .catch((ex) => {
        dispatch(errorReceiveData(ex));
      });
  };
}

export function getNotifications(userId) {
  return (dispatch) => {
    dispatch(requestData());
    let queryTrailer = "/notifications";
    return fetch(ApiUrl + queryTrailer, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ userId: userId }),
    })
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        dispatch(receiveData(data));
      })
      .catch((ex) => {
        dispatch(errorReceiveData(ex));
      });
  };
}

/*
export function getPosts(pageIndex = 0, tag) {
  return (dispatch) => {
      let queryTrailer = '?pageIndex=' + pageIndex;
      if (tag) {
          queryTrailer += '&tag=' + tag;
      }
      fetch(constants.getPage + queryTrailer)
          .then((response) => {
              return response.json()
          }).then((data) => {
              dispatch(receivePosts(data))
          }).catch((ex) => {
              dispatch(errorReceive(err))
          });
  }




export const REPO_REQUEST = 'REPO_REQUEST'
export const REPO_SUCCESS = 'REPO_SUCCESS'
export const REPO_FAILURE = 'REPO_FAILURE'

// Fetches a single repository from Github API.
// Relies on the custom API middleware defined in ../middleware/api.js.
const fetchRepo = fullName => ({
  [CALL_API]: {
    types: [ REPO_REQUEST, REPO_SUCCESS, REPO_FAILURE ],
    endpoint: `repos/${fullName}`,
    schema: Schemas.REPO
  }
})

// Fetches a single repository from Github API unless it is cached.
// Relies on Redux Thunk middleware.
export const loadRepo = (fullName, requiredFields = []) => (dispatch, getState) => {
  const repo = getState().entities.repos[fullName]
  if (repo && requiredFields.every(key => repo.hasOwnProperty(key))) {
    return null
  }

  return dispatch(fetchRepo(fullName))
}

export const STARRED_REQUEST = 'STARRED_REQUEST'
export const STARRED_SUCCESS = 'STARRED_SUCCESS'
export const STARRED_FAILURE = 'STARRED_FAILURE'

// Fetches a page of starred repos by a particular user.
// Relies on the custom API middleware defined in ../middleware/api.js.
const fetchStarred = (login, nextPageUrl) => ({
  login,
  [CALL_API]: {
    types: [ STARRED_REQUEST, STARRED_SUCCESS, STARRED_FAILURE ],
    endpoint: nextPageUrl,
    schema: Schemas.REPO_ARRAY
  }
})

// Fetches a page of starred repos by a particular user.
// Bails out if page is cached and user didn't specifically request next page.
// Relies on Redux Thunk middleware.
export const loadStarred = (login, nextPage) => (dispatch, getState) => {
  const {
    nextPageUrl = `users/${login}/starred`,
    pageCount = 0
  } = getState().pagination.starredByUser[login] || {}

  if (pageCount > 0 && !nextPage) {
    return null
  }

  return dispatch(fetchStarred(login, nextPageUrl))
}

export const STARGAZERS_REQUEST = 'STARGAZERS_REQUEST'
export const STARGAZERS_SUCCESS = 'STARGAZERS_SUCCESS'
export const STARGAZERS_FAILURE = 'STARGAZERS_FAILURE'

// Fetches a page of stargazers for a particular repo.
// Relies on the custom API middleware defined in ../middleware/api.js.
const fetchStargazers = (fullName, nextPageUrl) => ({
  fullName,
  [CALL_API]: {
    types: [ STARGAZERS_REQUEST, STARGAZERS_SUCCESS, STARGAZERS_FAILURE ],
    endpoint: nextPageUrl,
    schema: Schemas.USER_ARRAY
  }
})

// Fetches a page of stargazers for a particular repo.
// Bails out if page is cached and user didn't specifically request next page.
// Relies on Redux Thunk middleware.
export const loadStargazers = (fullName, nextPage) => (dispatch, getState) => {
  const {
    nextPageUrl = `repos/${fullName}/stargazers`,
    pageCount = 0
  } = getState().pagination.stargazersByRepo[fullName] || {}

  if (pageCount > 0 && !nextPage) {
    return null
  }

  return dispatch(fetchStargazers(fullName, nextPageUrl))
}

export const RESET_ERROR_MESSAGE = 'RESET_ERROR_MESSAGE'

// Resets the currently visible error message.
export const resetErrorMessage = () => ({
    type: RESET_ERROR_MESSAGE
})
*/
