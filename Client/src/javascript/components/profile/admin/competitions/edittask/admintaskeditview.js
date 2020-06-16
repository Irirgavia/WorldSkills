import React from "react";

export default class AdminTaskEditView extends React.Component {
  constructor(props) {
    super(props);
    this.sendTask = this.sendTask.bind(this);
    this.finishEditTask = this.finishEditTask.bind(this);
    this.state = {
      taskDateOfBegin: this.props.task.TaskDateOfBegin,
      taskDateOfEnd: this.props.task.TaskDateOfEnd,
      description: this.props.task.Description,
      addresses: this.props.task.Addresses,
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

  sendTask(event) {
    event.preventDefault();
    this.props.saveTask(
      this.props.task.Id,
      this.state.taskDateOfBegin,
      this.state.taskDateOfEnd,
      this.state.description,
      this.state.addresses
    );
  }

  finishEditTask() {
    this.props.finishEditTask();
  }

  render() {
    <div class="tasks">
      <form onSubmit={this.sendTask}>
        <p>
          <label class="questionField" for="taskDateOfBegin">
            Дата начала:
          </label>
          <input
            type="datetime-local"
            class="answerField"
            id="taskDateOfBegin"
            name="taskDateOfBegin"
            onChange={this.handleInputChange}
            maxLength="50"
            value={this.state.taskDateOfBegin}
            required
          />
        </p>
        <p>
          <label class="questionField" for="taskDateOfEnd">
            Дата конца:
          </label>
          <input
            type="datetime-local"
            class="answerField"
            id="taskDateOfEnd"
            name="taskDateOfEnd"
            onChange={this.handleInputChange}
            maxLength="50"
            value={this.state.taskDateOfEnd}
            required
          />
        </p>
        <p>
          <label class="questionField" for="description">
            Описание:
          </label>
          <input
            type="text"
            class="answerField"
            id="description"
            name="description"
            onChange={this.handleInputChange}
            maxLength="50"
            value={this.state.description}
            required
          />
        </p>
        <p>
          <label class="questionField" for="addresses">
            Адрес:
          </label>
          <input
            type="text"
            class="answerField"
            id="addresses"
            name="addresses"
            onChange={this.handleInputChange}
            maxLength="50"
            value={this.state.addresses}
            required
          />
        </p>
        <button type="submit">Сохранить</button>
        <button onClick={this.finishEditTask}>Вернуться</button>
      </form>
    </div>;
  }
}
