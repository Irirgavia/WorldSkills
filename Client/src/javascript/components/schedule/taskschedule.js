import React from "react";

export default class TaskSchedule extends React.Component {
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
    return (
      <tr class={"task " + this.props.task.IsActual}>
        <td>{this.toDateFormat(this.props.task.TaskDateOfBegin)}</td>
        <td>{this.toDateFormat(this.props.task.TaskDateOfEnd)}</td>
        <td>{this.props.task.Addresses}</td>
      </tr>
    );
  }
}
