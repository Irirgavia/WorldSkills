import React from "react";
import JudgeStage from "./judgestage.js";

export default class JudgeCompetititonsView extends React.Component {
  constructor(props) {
    super(props);
    this.sendMark = this.sendMark.bind(this);
  }

  sendMark(answerId, mark) {
    this.props.sendMark(answerId, mark);
  }

  render() {
    if (this.props.competition.Stages.length == 0) {
      return (
        <div class="competition">
          <p class="competitiondata">
            Профессия: {this.props.competition.Skill} Время проведения:{" "}
            {this.props.competition.DateOfBegin}-
            {this.props.competition.DateOfEnd}
          </p>
        </div>
      );
    } else {
      return (
        <div class="competition">
          <p class="competitiondata">
            Профессия: {this.props.competition.Skill} Время проведения:{" "}
            {this.props.competition.DateOfBegin}-
            {this.props.competition.DateOfEnd}
          </p>
          {this.props.competition.Stages.map((stage) => (
            <JudgeStage stage={stage} sendMark={this.sendMark} />
          ))}
        </div>
      );
    }
  }
}
