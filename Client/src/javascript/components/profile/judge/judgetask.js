import React from "react";
import JudgeAnswer from "./judgeanswer";

export default class JudgeTask extends React.Component {
  constructor(props) {
    super(props);
    this.sendMark = this.sendMark.bind(this);
  }

  sendMark(answerId, mark) {
    this.props.sendMark(answerId, mark);
  }

  render() {
    if (this.props.task.Answers.length == 0) {
      return (
        <div class="task judge">
          <p class="taskdescription judge">
            <a href={this.props.task.Description}>Задание</a>
          </p>
          <p>Ответов нет.</p>
        </div>
      );
    } else {
      return (
        <div class="task judge">
          <p class="taskdescription judge">
            <a href={this.props.task.Description}>Задание</a>
          </p>
          <table class="tasks" border="1">
            <thead>
              <tr>
                <th>Ответ</th>
                <th>Баллы</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {this.props.task.Answers.map((answer) => {
                <JudgeAnswer answer={answer} sendMark={this.sendMark} />;
              })}
            </tbody>
          </table>
        </div>
      );
    }
  }
}
