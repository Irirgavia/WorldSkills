import React from 'react';
import { connect } from 'react-redux';
import { saveCompetition } from '../../../actions/actions.js';
import { AdminCompetititons } from '../admincompetition.js'
import { AdminStageChange } from './adminstagechange.js'
import * as systemComponents from '../../system'

export class AdminCompetititonsChange extends React.Component {
  constructor(props) {
    super(props);
    this.skillInput = React.createRef();
    this.dateOfBeginInput = React.createRef();
    this.dateOfEndInput = React.createRef();
    this.state = {
      finishEditingFlag: false,
      changeCompetitionFlag: false,
      competitionToChange: {}
    };
  }

  sendCompetition(){
    var data = {
        competitionId: this.props.competition.Id,
        skillInput: this.skillInput.value,
        dateOfBeginInput: this.dateOfBeginInput.value,
        dateOfEndInput: this.dateOfEndInput.value
    };
    this.props.saveCompetition(data);
  }

  finishEditing(){
    this.setState({finishEditingFlag: true});
  }

  editStage(e){
    var target = e.target || e.srcElement;
    var index = this.StageEditButtons.findIndex(target.ref);
    this.setState({
      changeStageFlag: true,
      stageToChange: this.props.competition.Stages[index]
    });
  }

  createStage(e){
    var stage = {
        Id: -1,
        Type: '',
        Tasks: {}
    };
    this.setState({
        changeStageFlag: true,
        stageToChange: stage
    });
  }

  render() {
      if (this.props.error) {
          return <systemComponents.Error error={this.props.error.message} />;
      } else if (this.props.isFetching) {
          return <systemComponents.Loading />;
      } else if(this.state.finishEditingFlag){
        return <div>
            Сохранено.
            <AdminCompetititons />
        </div>;
      } else if ( this.state.changeCompetitionFlag ) {
        return <AdminStageChange stage={this.state.stageToChange} competitionId={this.props.competition.Id} />;
      } else {
          return (
          <div class="competition">
            <form action={this.sendCompetition.bind(this)}>
              <p>
                <label class = "questionField" for="skill">Профессия:</label>
                <input type = "text" class = "answerField" id="skill" name="skill" ref={this.skillInput} maxLength="50" required>{this.props.competition.Skill}</input>
              </p>
              <p>
                <label class = "questionField" for="dateOfBegin">Фамилия:</label>
                <input type = "date" class = "answerField" id="dateOfBegin" name="dateOfBegin" ref={this.dateOfBeginInput} maxLength="50" required>{this.props.competition.DateOfBegin}</input>
              </p>
              <p>
                <label class = "questionField" for="dateOfEnd">Фамилия:</label>
                <input type = "date" class = "answerField" id="dateOfEnd" name="dateOfEnd" ref={this.dateOfEndInput} maxLength="50" required>{this.props.competition.DateOfEnd}</input>
              </p>
              <button type="submit">Сохранить</button>
              <button onClick={this.finishEditing.bind(this)}>Вернуться</button>
            </form>
            <button onClick={this.createStage.bind(this)}>Создать новый этап</button>
            {this.props.competition.Stages.map((stage) =>
                    (
                      <div class="stage">
                        <p class="stagetype">Этап: {stage.Type}</p>
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
                            {stage.Tasks.map((task) =>
                            (
                              <tr class={"task " + task.IsActual}>
                                <td>{task.TaskDateOfBegin}</td>
                                <td>{task.TaskDateOfEnd}</td>
                                <td><a href={task.Description}>Задание</a></td>
                                <td>{task.Addresses}</td>
                              </tr>
                            ))}</tbody>
                          </table>
                          <button class={"stageButton"} ref={(button) => {this.StageEditButtons[this.props.competition.Stages.findIndex(stage)] = button }} onClick={this.editStage.bind(this)}>Редактировать этап</button>
                      </div>
                    ))}
                    </div>
          );
      }
    }
  }


let mapProps = (state) => {
  return {
    adminId: state.user.id,
      isFetching: state.isFetching,
      error: state.error
  }
}

let mapDispatch = (dispatch) => {
  return {
    saveCompetition: (data) => dispatch(saveCompetition(data))
  }
}

export default connect(mapProps, mapDispatch)(AdminCompetititonsChange)