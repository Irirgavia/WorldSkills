import React from "react";

export default class AdminTask extends React.Component {
  render() {
    <tr class="task">
      <td>{this.props.task.TaskDateOfBegin}</td>
      <td>{this.props.task.TaskDateOfEnd}</td>
      <td>
        <a href={this.props.task.Description}>Задание</a>
      </td>
      <td>{this.props.task.Addresses}</td>
    </tr>;
  }
}
