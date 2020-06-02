import React from "react";
import { connect } from "react-redux";
import { saveStage } from "../../../../actions/actions.js";
import AdminCompetititonsChange from "./admincompetitionchange.js";
import Error from "../../../system/error.js";
import Loading from "../../../system/loading.js";

export class AdminStageChange extends React.Component {
  constructor(props) {
    super(props);
    this.sendStage = this.sendStage.bind(this);
    this.finishEditing = this.finishEditing.bind(this);
    this.createTask = this.createTask.bind(this);
    this.editTask = this.editTask.bind(this);
    this.state = {
      finishEditingFlag: false,
      changeStageFlag: false,
      stagetype: this.props.stage.Type,
      stageToChange: {},
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

  sendStage(event) {
    event.preventDefault();
    var data = {
      competitionId: this.props.competitionId,
      id: this.props.stage.Id,
      stagetype: this.state.stagetype,
    };
    this.props.saveStage(data);
  }

  finishEditing() {
    this.setState({ finishEditingFlag: true });
  }

  editTask(e) {
    var target = e.target || e.srcElement;
    var id = target.key;
    var task = this.props.stage.Tasks.find(this.findElementInArrayById, id);
    this.setState({
      changeTaskFlag: true,
      taskToChange: task,
    });
  }

  findElementInArrayById(element, index, array) {
    return element.Id == this;
  }

  createTask(e) {
    var task = {
      Id: -1,
      TaskDateOfBegin: "",
      TaskDateOfEnd: "",
      Description: "",
      Addresses: "",
    };
    this.setState({
      changeTaskFlag: true,
      taskToChange: task,
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
          <AdminCompetititonsChange />
        </div>
      );
    } else if (this.state.changeTaskFlag) {
      return (
        <AdminTaskChange
          task={this.state.taskToChange}
          competitionId={this.props.competitionId}
          stageId={this.props.stage.Id}
        />
      );
    } else if (this.props.stage.Tasks.length == 0) {
      return (
        <div class="stage">
          <form onSubmit={this.sendStage}>
            <p>
              <label class="questionField" for="stagetype">
                Этап:
              </label>
              <input
                type="text"
                class="answerField"
                id="stagetype"
                name="stagetype"
                onChange={this.handleInputChange}
                maxLength="50"
                value={this.state.stagetype}
                required
              />
            </p>
            <button type="submit">Сохранить</button>
            <button onClick={this.finishEditing}>Вернуться</button>
          </form>
          <button onClick={this.createTask}>Создать новое задание</button>
        </div>
      );
    } else {
      return (
        <div class="stage">
          <form onSubmit={this.sendStage}>
            <p>
              <label class="questionField" for="stagetype">
                Этап:
              </label>
              <input
                type="text"
                class="answerField"
                id="stagetype"
                name="stagetype"
                onChange={this.handleInputChange}
                maxLength="50"
                value={this.state.stagetype}
                required
              />
            </p>
            <button type="submit">Сохранить</button>
            <button onClick={this.finishEditing}>Вернуться</button>
          </form>
          <button onClick={this.createTask}>Создать новое задание</button>
          <table class="tasks" border="1">
            <thead>
              <tr>
                <th>Дата начала</th>
                <th>Дата конца</th>
                <th>Задание</th>
                <th>Адрес</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {stage.Tasks.map((task) => (
                <Task task={task} editTask={this.editTask} />
              ))}
            </tbody>
          </table>
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
    saveStage: (data) => dispatch(saveStage(data)),
  };
};

export default connect(mapProps, mapDispatch)(AdminStageChange);

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
        <td>
          <button
            class={"taskButton"}
            key={this.props.task.Id}
            onClick={this.props.editTask}
          >
            Редактировать задачу
          </button>
        </td>
      </tr>
    );
  }
}
