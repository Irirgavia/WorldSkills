import React from "react";

export default class TaskSchedule extends React.Component {
  render() {
    return (
      <tr class={"task " + this.props.task.IsActual}>
        <td>{this.props.task.TaskDateOfBegin}</td>
        <td>{this.props.task.TaskDateOfEnd}</td>
        <td>{this.props.task.Addresses}</td>
      </tr>
    );
  }
}
