import React from "react";
import ParticipantTask from "./participanttask.js";

export default class ParticipantStage extends React.Component {
  constructor(props) {
    super(props);
    this.sendAnswer = this.sendAnswer.bind(this);
  }

  sendAnswer(taskId, answer) {
    this.props.sendAnswer(taskId, answer);
  }

  render() {
    if (this.props.stage.tasks.length == 0) {
      return (
        <div class="stage">
          <p class="stagetype">Этап: {this.props.stage.type}</p>
        </div>
      );
    } else {
      return (
        <div class="stage">
          <p class="stagetype">Этап: {this.props.stage.type}</p>
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
              {this.props.stage.tasks.map((task) => (
                <ParticipantTask task={task} sendAnswer={this.sendAnswer} />
              ))}
            </tbody>
          </table>
        </div>
      );
    }
  }
}
