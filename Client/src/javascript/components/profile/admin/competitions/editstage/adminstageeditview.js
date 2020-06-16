import React from "react";
import AdminTask from "./admintask.js";
import AdminTaskEditView from "../edittask/admintaskeditview.js";

export default class AdminStageEditView extends React.Component {
  constructor(props) {
    super(props);
    this.sendStage = this.sendStage.bind(this);
    this.finishEditStage = this.finishEditStage.bind(this);
    this.createTask = this.createTask.bind(this);
    this.editTask = this.editTask.bind(this);
    this.saveTask = this.saveTask.bind(this);
    this.finishEditTask = this.finishEditTask.bind(this);
    this.state = {
      stagetype: this.props.stage.Type,
      changeTaskFlag: false,
      taskToChange: {},
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
    this.props.saveStage(this.props.stage.Id, this.state.stagetype);
  }

  finishEditStage() {
    this.props.finishEditStage();
  }

  editTask(task) {
    this.setState({
      changeTaskFlag: true,
      taskToChange: task,
    });
  }

  createTask() {
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

  finishEditTask() {
    this.setState({
      changeTaskFlag: false,
      taskToChange: {},
    });
  }

  saveTask(taskId, taskDateOfBegin, taskDateOfEnd, description, addresses) {
    this.props.saveTask(
      taskId,
      taskDateOfBegin,
      taskDateOfEnd,
      description,
      addresses
    );
  }

  render() {
    if (this.state.changeTaskFlag) {
      return (
        <AdminTaskEditView
          task={this.state.taskToChange}
          finishEditTask={this.finishEditTask}
          saveTask={this.saveTask}
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
            <button onClick={this.finishEditStage}>Вернуться</button>
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
            <button onClick={this.finishEditStage}>Вернуться</button>
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
                <AdminTask task={task} editTask={this.editTask} />
              ))}
            </tbody>
          </table>
        </div>
      );
    }
  }
}
