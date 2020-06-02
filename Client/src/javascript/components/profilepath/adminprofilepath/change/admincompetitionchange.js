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
    }
    if (this.props.competition.Stages.length == 0) {
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
                type="datetime-local"
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
                type="datetime-local"
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
        </div>
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
                type="datetime-local"
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
                type="datetime-local"
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
            <Stage stage={stage} editStage={this.editStage} />
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

class Stage extends React.Component {
  render() {
    if (this.props.stage.Tasks.length == 0) {
      return (
        <div class="stage">
          <p class="stagetype">Этап: {this.props.stage.Type}</p>
        </div>
      );
    } else {
      return (
        <div class="stage">
          <p class="stagetype">Этап: {this.props.stage.Type}</p>
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
              {this.props.stage.Tasks.map((task) => (
                <Task task={task} />
              ))}
            </tbody>
          </table>
          <button
            class={"stageButton"}
            key={this.props.stage.Id}
            onClick={this.props.editStage}
          >
            Редактировать этап
          </button>
        </div>
      );
    }
  }
}

class Task extends React.Component {
  render() {
    return (
      <tr class={"task " + this.props.task.IsActual}>
        <td>{this.props.task.TaskDateOfBegin}</td>
        <td>{this.props.task.TaskDateOfEnd}</td>
        <td>
          <a href={this.props.task.Description}>Задание</a>
        </td>
        <td>{this.props.task.Addresses}</td>
      </tr>
    );
  }
}
