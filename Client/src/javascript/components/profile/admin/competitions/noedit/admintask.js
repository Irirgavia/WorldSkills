import React from "react";

export default class AdminTask extends React.Component {
  toDateFormat(sourceString) {
    var stringDate =
      sourceString.slice(8, 10) +
      "." +
      sourceString.slice(5, 7) +
      "." +
      sourceString.slice(0, 4) +
      " " +
      sourceString.slice(11);
    return stringDate;
  }

  render() {
    <tr class="task">
      <td>{this.toDateFormat(this.props.task.TaskDateOfBegin)}</td>
      <td>{this.toDateFormat(this.props.task.TaskDateOfEnd)}</td>
      <td>
        <a href={this.props.task.Description}>Задание</a>
      </td>
      <td>{this.props.task.Addresses}</td>
    </tr>;
  }
}
