import React from "react";
import { connect } from "react-redux";
import {
  getCompetitionsByParticipant,
  saveAnswer,
} from "../../../actions/actions.js";
import Error from "../../system/error.js";
import Loading from "../../system/loading.js";
import NoResults from "../../system/noresults.js";

export class ParticipantCompetititons extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      answers: [],
    };
  }

  componentDidMount() {
    this.props.getCompetitionsByParticipant(this.props.participantId);
    this.timerId = setInterval(() => this.tick(), 1000);
  }

  componentWillUnmount() {
    clearInterval(this.timerId);
  }

  tick() {
    var date = new Date();
    this.props.items.forEach((item) => {
      item.Stages.forEach((stage) => {
        stage.Tasks.forEach((task) => {
          if (task.DateOfBegin < date && task.DateOfEnd > date) {
            task.IsActual = true;
          } else {
            task.IsActual = false;
          }
        });
      });
    });
  }

  handleInputChange(event) {
    const target = event.target;
    const value = target.value;
    const key = target.key;
    var arr = [];
    arr[key] = value;
    this.setState({ answers: answers.concat(arr) });
  }

  send(e) {
    var target = e.target || e.srcElement;
    var key = target.key;
    var value = this.state.answers[key];
    var data = {
      taskId: key,
      participantId: this.participantId,
      projectLink: value,
    };
    this.props.saveAnswer(data);
  }

  render() {
    if (!this.props.isSignedIn || this.props.role != "participant") {
      return <Redirect to="/singin" />;
    } else if (this.props.error) {
      return <Error error={this.props.error.message} />;
    } else if (this.props.isFetching) {
      return <Loading />;
    } else if (this.props.items.length == 0) {
      return <NoResults mes={"Нет актуальных событий"} />;
    } else {
      return (
        <div>
          {this.props.items.map((item) => (
            <div class="competition">
              <p class="competitiondata">
                Профессия: {item.Skill} Время проведения: {item.DateOfBegin}-
                {item.DateOfEnd}
              </p>
              {item.Stages.map((stage) => (
                <div class="stage">
                  <p class="stagetype">Этап: {stage.Type}</p>
                  <table class="tasks" border="1">
                    <thead>
                      <tr>
                        <th>Дата начала</th>
                        <th>Дата конца</th>
                        <th>Задание</th>
                        <th>Ответ</th>
                      </tr>
                    </thead>
                    <tbody>
                      {stage.Tasks.map((task, index) => (
                        <tr class={"task " + task.IsActual}>
                          <td>{task.TaskDateOfBegin}</td>
                          <td>{task.TaskDateOfEnd}</td>
                          <td>
                            <a href={task.Description}>Задание</a>
                          </td>
                          <td>
                            <input
                              type="url"
                              class={"answer"}
                              onChange={this.handleInputChange}
                              key={task.Id}
                            />
                          </td>
                          <td>
                            <button
                              class={"answerButton"}
                              key={task.Id}
                              onClick={this.send.bind(this)}
                            >
                              Отправить
                            </button>
                          </td>
                        </tr>
                      ))}
                    </tbody>
                  </table>
                </div>
              ))}
            </div>
          ))}
        </div>
      );
    }
  }
}

let mapProps = (state) => {
  return {
    participantId: state.user.id,
    role: state.user.role,
    isSignedIn: state.isSignedIn,
    items: state.data,
    isFetching: state.isFetching,
    error: state.error,
  };
};

let mapDispatch = (dispatch) => {
  return {
    getCompetitionsByParticipant: (participantId) =>
      dispatch(getCompetitionsByParticipant(participantId)),
    saveAnswer: (data) => dispatch(saveAnswer(data)),
  };
};

export default connect(mapProps, mapDispatch)(ParticipantCompetititons);

/*<td><input type="url" class={"answer"} ref={(input) => {this.AnswerInputs[task.Id] = input }}></input></td>
                                  <td><button class={"answerButton"} ref={(button) => {this.AnswerSendButtons[task.Id] = button }} onClick={this.send.bind(this)}>Отправить</button></td>
                                */
