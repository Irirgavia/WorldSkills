import React from "react";
import AdminTask from "./admintask.js";

export default class AdminStage extends React.Component {
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
                <th>Адреса</th>
              </tr>
            </thead>
            <tbody>
              {this.props.stage.Tasks.map((task) => (
                <AdminTask task={task} />
              ))}
            </tbody>
          </table>
        </div>
      );
    }
  }
}
