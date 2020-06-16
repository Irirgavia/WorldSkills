import React from "react";
import AdminStage from "./adminstage.js";
import AdminStageEditView from "../editstage/adminstageeditview.js";

export default class AdminCompetititonsEditView extends React.Component {
  constructor(props) {
    super(props);
    this.finishEditCompetition = this.finishEditCompetition.bind(this);
    this.saveCompetition = this.saveCompetition.bind(this);
    this.createStage = this.createStage.bind(this);
    this.editStage = this.editStage.bind(this);
    this.finishEditStage = this.finishEditStage.bind(this);
    this.saveStage = this.saveStage.bind(this);
    this.saveTask = this.saveTask.bind(this);
    this.state = {
      changeStageFlag: false,
      skill: this.props.competition.Skill,
      dateOfBegin: this.props.competition.DateOfBegin,
      dateOfEnd: this.props.competition.DateOfEnd,
      stageToChange: {},
    };

    this.handleInputChange = this.handleInputChange.bind(this);
  }

  handleInputChange(event) {
    const target = event.target;
    const value = target.value;
    const name = target.name;

    this.setState({
      [name]: value,
    });
  }

  finishEditCompetition() {
    this.props.finishEditCompetition();
  }

  saveCompetition(event) {
    event.preventDefault();
    this.props.saveCompetition(
      this.props.competition.Id,
      this.state.skill,
      this.state.dateOfBegin,
      this.state.dateOfEnd
    );
  }

  editStage(stage) {
    this.setState({
      changeStageFlag: true,
      stageToChange: stage,
    });
  }

  createStage() {
    let stage = {
      Id: -1,
      Type: "",
      Tasks: {},
    };
    this.setState({
      changeStageFlag: true,
      stageToChange: stage,
    });
  }

  finishEditStage() {
    this.setState({
      changeStageFlag: false,
      stageToChange: {},
    });
  }

  saveStage(stageId, stageType) {
    this.props.saveStage(this.props.competition.Id, stageId, stageType);
  }

  saveTask(taskId, taskDateOfBegin, taskDateOfEnd, description, addresses) {
    this.props.saveTask(
      taskId,
      taskDateOfBegin,
      taskDateOfEnd,
      description,
      addresses
    );
  }

  render() {
    if (this.state.changeStageFlag) {
      return (
        <AdminStageEditView
          stage={this.state.stageToChange}
          saveStage={this.saveStage}
          finishEditStage={this.finishEditStage}
          saveTask={this.saveTask}
        />
      );
    }
    if (this.props.competition.Stages.length == 0) {
      return (
        <div class="competition">
          <form onSubmit={this.saveCompetition}>
            <p>
              <label class="questionField" for="skill">
                Профессия:
              </label>
              <input
                type="text"
                class="answerField"
                id="skill"
                name="skill"
                maxLength="50"
                onChange={this.handleInputChange}
                value={this.state.skill}
                required
              />
            </p>
            <p>
              <label class="questionField" for="dateOfBegin">
                Дата начала:
              </label>
              <input
                type="datetime-local"
                class="answerField"
                id="dateOfBegin"
                name="dateOfBegin"
                maxLength="50"
                onChange={this.handleInputChange}
                value={this.state.dateOfBegin}
                required
              />
            </p>
            <p>
              <label class="questionField" for="dateOfEnd">
                Дата окончания:
              </label>
              <input
                type="datetime-local"
                class="answerField"
                id="dateOfEnd"
                name="dateOfEnd"
                maxLength="50"
                onChange={this.handleInputChange}
                value={this.state.dateOfEnd}
                required
              />
            </p>
            <button type="submit">Сохранить</button>
            <button onClick={this.finishEditCompetition}>Вернуться</button>
          </form>
          <button onClick={this.createStage}>Создать новый этап</button>
        </div>
      );
    } else {
      return (
        <div class="competition">
          <form onSubmit={this.saveCompetition}>
            <p>
              <label class="questionField" for="skill">
                Профессия:
              </label>
              <input
                type="text"
                class="answerField"
                id="skill"
                name="skill"
                maxLength="50"
                onChange={this.handleInputChange}
                value={this.state.skill}
                required
              />
            </p>
            <p>
              <label class="questionField" for="dateOfBegin">
                Дата начала:
              </label>
              <input
                type="datetime-local"
                class="answerField"
                id="dateOfBegin"
                name="dateOfBegin"
                maxLength="50"
                onChange={this.handleInputChange}
                value={this.state.dateOfBegin}
                required
              />
            </p>
            <p>
              <label class="questionField" for="dateOfEnd">
                Дата окончания:
              </label>
              <input
                type="datetime-local"
                class="answerField"
                id="dateOfEnd"
                name="dateOfEnd"
                maxLength="50"
                onChange={this.handleInputChange}
                value={this.state.dateOfEnd}
                required
              />
            </p>
            <button type="submit">Сохранить</button>
            <button onClick={this.finishEditCompetition}>Вернуться</button>
          </form>
          <button onClick={this.createStage}>Создать новый этап</button>
          {this.props.competition.Stages.map((stage) => (
            <AdminStage stage={stage} editStage={this.editStage} />
          ))}
        </div>
      );
    }
  }
}
