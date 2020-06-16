import React from "react";
import JudgeTask from "./judgetask.js";

export default class JudgeStage extends React.Component {
  constructor(props) {
    super(props);
    this.sendMark = this.sendMark.bind(this);
  }

  sendMark(answerId, mark) {
    this.props.sendMark(answerId, mark);
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
                <JudgeTask task={task} sendMark={this.sendMark} />
              ))}
            </tbody>
          </table>
        </div>
      );
    }
  }
}
