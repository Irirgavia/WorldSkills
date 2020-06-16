import React from "react";
import TaskSchedule from "./taskschedule.js";

export default class StageSchedule extends React.Component {
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
                <th>Начало выполнения задания</th>
                <th>Конец выполнения задания</th>
                <th>Адреса</th>
              </tr>
            </thead>
            <tbody>
              {this.props.stage.Tasks.map((task) => (
                <TaskSchedule task={task} />
              ))}
            </tbody>
          </table>
        </div>
      );
    }
  }
}
