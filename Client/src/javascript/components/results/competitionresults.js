import React from "react";
import StageResults from "./stageresults.js";

export default class CompetitionResults extends React.Component {
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
            <StageResults stage={stage} />
          ))}
        </div>
      );
    }
  }
}
