import React from "react";
import ParticipantStage from "./participantstage.js";

export default class ParticipantCompetititonsView extends React.Component {
  constructor(props) {
    super(props);
    this.sendAnswer = this.sendAnswer.bind(this);
  }

  sendAnswer(taskId, answer) {
    this.props.sendAnswer(taskId, answer);
  }

  render() {
    {
      if (this.props.competition.stages.length == 0) {
        return (
          <div class="competition">
            <p class="competitiondata">
              Профессия: {this.props.competition.skill} Время проведения:{" "}
              {this.props.competition.dateOfBegin}-
              {this.props.competition.dateOfEnd}
            </p>
          </div>
        );
      } else {
        return (
          <div class="competition">
            <p class="competitiondata">
              Профессия: {this.props.competition.skill} Время проведения:{" "}
              {this.props.competition.dateOfBegin}-
              {this.props.competition.dateOfEnd}
            </p>
            {this.props.competition.stages.map((stage) => (
              <ParticipantStage stage={stage} sendAnswer={this.sendAnswer} />
            ))}
          </div>
        );
      }
    }
  }
}
