import React from "react";
import { connect } from "react-redux";
import { saveCompetition } from "../../../../actions/actions.js";
import AdminCompetititons from "../admincompetition.js";
import AdminStageChange from "./adminstagechange.js";
import Error from "../../../system/error.js";
import Loading from "../../../system/loading.js";

export class AdminCompetititonsChange extends React.Component {
  constructor(props) {
    super(props);
    this.finishEditing = this.finishEditing.bind(this);
    this.createStage = this.createStage.bind(this);
    this.editStage = this.editStage.bind(this);
    this.sendCompetition = this.sendCompetition.bind(this);
    this.state = {
      finishEditingFlag: false,
      changeCompetitionFlag: false,
      skill: this.props.competition.Skill,
      dateOfBegin: this.props.competition.DateOfBegin,
      dateOfEnd: this.props.competition.DateOfEnd,
      competitionToChange: {},
    };

    this.handleInputChange = this.handleInputChange.bind(this);
  }

  handleInputChange(event) {
    const target = event.target;
    const value = target.value;
    const name = target.name;

    this.setState({
      [name]: value,
    });
  }

  sendCompetition(event) {
    event.preventDefault();
    var data = {
      competitionId: this.props.competition.Id,
      skill: this.state.skill,
      dateOfBegin: this.state.dateOfBegin,
      dateOfEnd: this.state.dateOfEnd,
    };
    this.props.saveCompetition(data);
  }

  finishEditing() {
    this.setState({ finishEditingFlag: true });
  }

  editStage(e) {
    var target = e.target || e.srcElement;
    var id = target.key;
    var stage = this.props.competition.Stages.find(
      this.findElementInArrayById,
      id
    );
    this.setState({
      changeStageFlag: true,
      stageToChange: stage,
    });
  }

  findElementInArrayById(element, index, array) {
    return element.Id == this;
  }

  createStage(e) {
    var stage = {
      Id: -1,
      Type: "",
      Tasks: {},
    };
    this.setState({
      changeStageFlag: true,
      stageToChange: stage,
    });
  }

  render() {
    if (!this.props.isSignedIn || this.props.role != "administrator") {
      return <Redirect to="/singin" />;
    } else if (this.props.error) {
      return <Error error={this.props.error.message} />;
    } else if (this.props.isFetching) {
      return <Loading />;
    } else if (this.state.finishEditingFlag) {
      return (
        <div>
          <AdminCompetititons />
        </div>
      );
    } else if (this.state.changeCompetitionFlag) {
      return (
        <AdminStageChange
          stage={this.state.stageToChange}
          competitionId={this.props.competition.Id}
        />
      );
    } else {
      return (
        <div class="competition">
          <form onSubmit={this.sendCompetition}>
            <p>
              <label class="questionField" for="skill">
                Профессия:
              </label>
              <input
                type="text"
                class="answerField"
                id="skill"
                name="skill"
                maxLength="50"
                onChange={this.handleInputChange}
                value={this.state.skill}
                required
              />
            </p>
            <p>
              <label class="questionField" for="dateOfBegin">
                Дата начала:
              </label>
              <input
                type="date"
                class="answerField"
                id="dateOfBegin"
                name="dateOfBegin"
                maxLength="50"
                onChange={this.handleInputChange}
                value={this.state.dateOfBegin}
                required
              />
            </p>
            <p>
              <label class="questionField" for="dateOfEnd">
                Дата окончания:
              </label>
              <input
                type="date"
                class="answerField"
                id="dateOfEnd"
                name="dateOfEnd"
                maxLength="50"
                onChange={this.handleInputChange}
                value={this.state.dateOfEnd}
                required
              />
            </p>
            <button type="submit">Сохранить</button>
            <button onClick={this.finishEditing}>Вернуться</button>
          </form>
          <button onClick={this.createStage}>Создать новый этап</button>
          {this.props.competition.Stages.map((stage) => (
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
                  {stage.Tasks.map((task) => (
                    <tr class={"task " + task.IsActual}>
                      <td>{task.TaskDateOfBegin}</td>
                      <td>{task.TaskDateOfEnd}</td>
                      <td>
                        <a href={task.Description}>Задание</a>
                      </td>
                      <td>{task.Addresses}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
              <button
                class={"stageButton"}
                key={stage.Id}
                onClick={this.editStage}
              >
                Редактировать этап
              </button>
            </div>
          ))}
        </div>
      );
    }
  }
}

let mapProps = (state) => {
  return {
    adminId: state.user.id,
    role: state.user.role,
    isSignedIn: state.isSignedIn,
    isFetching: state.isFetching,
    error: state.error,
  };
};

let mapDispatch = (dispatch) => {
  return {
    saveCompetition: (data) => dispatch(saveCompetition(data)),
  };
};

export default connect(mapProps, mapDispatch)(AdminCompetititonsChange);
