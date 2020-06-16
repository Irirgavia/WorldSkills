import React from "react";
import AdminTask from "../noedit/admintask.js";

export default class AdminStage extends React.Component {
  constructor(props) {
    super(props);
    this.editStage = this.editStage.bind(this);
  }

  editStage() {
    this.props.editStage(this.props.stage);
  }

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
                <th>Ответ</th>
              </tr>
            </thead>
            <tbody>
              {this.props.stage.Tasks.map((task) => (
                <AdminTask task={task} />
              ))}
            </tbody>
          </table>
          <button class={"stageButton"} onClick={this.editStage}>
            Редактировать этап
          </button>
        </div>
      );
    }
  }
}
