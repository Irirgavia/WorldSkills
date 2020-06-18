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

  toDateFormat(sourceString) {
    var stringDate =
      sourceString.slice(8, 10) +
      "." +
      sourceString.slice(5, 7) +
      "." +
      sourceString.slice(0, 4) +
      " " +
      sourceString.slice(11);
    return stringDate;
  }

  render() {
    return (
      <div class="competition">
        <p class="competitiondata">
          Профессия: {this.props.competition.Skill} Время проведения:{" "}
          {this.toDateFormat(this.props.competition.DateOfBegin)}-
          {this.toDateFormat(this.props.competition.DateOfEnd)}
        </p>
        {this.props.competition.Stages.length == 0
          ? null
          : this.props.competition.Stages.map((stage) => (
              <Stage stage={stage} />
            ))}
        <button class={"competitionButton"} onClick={this.editCompetition}>
          Редактировать соревнование
        </button>
      </div>
    );
  }
}
