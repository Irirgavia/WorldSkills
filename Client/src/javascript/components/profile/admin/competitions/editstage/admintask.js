import React from "react";

export default class AdminTask extends React.Component {
  constructor(props) {
    super(props);
    this.editTask = this.editTask.bind(this);
  }

  editTask() {
    this.props.editTask(this.props.task);
  }

  render() {
    <tr class="task">
      <td>{this.props.task.TaskDateOfBegin}</td>
      <td>{this.props.task.TaskDateOfEnd}</td>
      <td>
        <a href={this.props.task.Description}>Задание</a>
      </td>
      <td>{this.props.task.Addresses}</td>
      <td>
        <button class={"taskButton"} onClick={this.editTask}>
          Редактировать задачу
        </button>
      </td>
    </tr>;
  }
}
