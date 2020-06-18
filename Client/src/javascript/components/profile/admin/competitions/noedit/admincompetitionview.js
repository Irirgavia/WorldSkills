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
    //return sourceString;
  }

  render() {
    console.log("here");
    console.log(this.props.competition);
    if (this.props.competition.Stages.length == 0) {
      return (
        <div class="competition">
          <p class="competitiondata">
            Профессия: {this.props.competition.Skill} Время проведения:{" "}
            {this.toDateFormat(this.props.competition.DateOfBegin)}-
            {this.toDateFormat(this.props.competition.DateOfEnd)}
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
            {this.toDateFormat(this.props.competition.DateOfBegin)}-
            {this.toDateFormat(this.props.competition.DateOfEnd)}
          </p>
          {this.props.competition.Stages.map((stage) => (
            <AdminStage stage={stage} />
          ))}
          <button class={"competitionButton"} onClick={this.editCompetition}>
            Редактировать соревнование
          </button>
        </div>
      );
    }
  }
}
