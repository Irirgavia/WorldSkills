import React from "react";
import AdminStage from "./adminstage.js";

export default class AdminCompetititonView extends React.Component {
  constructor(props) {
    super(props);
    this.editCompetition = this.editCompetition.bind(this);
  }

  editCompetition() {
    this.props.editCompetition(this.props.competition);
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
          <button class={"competitionButton"} onClick={this.editCompetition}>
            Редактировать соревнование
          </button>
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
            <Stage stage={stage} />
          ))}
          <button class={"competitionButton"} onClick={this.editCompetition}>
            Редактировать соревнование
          </button>
        </div>
      );
    }
  }
}
