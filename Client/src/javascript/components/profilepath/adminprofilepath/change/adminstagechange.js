import React from 'react';
import { connect } from 'react-redux';
import { saveStage } from '../../../actions/actions.js';
import { AdminCompetititonsChange } from './admincompetitionchange.js'
import Error from '../../system/error.js';
import Loading from '../../system/loading.js';

export class AdminStageChange extends React.Component {
  constructor(props) {
    super(props);
    this.stagetypeInput = React.createRef();
    this.state = {
      finishEditingFlag: false,
      changeStageFlag: false,
      stageToChange: {}
    };
  }

  sendStage(event){
    event.preventDefault();
    var data = {
        competitionId: this.props.competitionId,
        Id: this.props.stage.Id,
        stagetype: this.stagetypeInput.value
    };
    this.props.saveStage(data);
  }

  finishEditing(){
    this.setState({finishEditingFlag: true});
  }

  editTask(e){
    var target = e.target || e.srcElement;
    var index = this.TaskEditButtons.findIndex(target.ref);
    this.setState({
      changeTaskFlag: true,
      taskToChange: this.props.stage.Tasks[index]
    });
  }

  createTask(e){
    var task = {
        Id: -1,
        TaskDateOfBegin: '',
        TaskDateOfEnd: '',
        Description: '',
        Addresses: '',
    };
    this.setState({
        changeTaskFlag: true,
        taskToChange: task
    });
  }

  render() {
      if (this.props.error) {
          return <Error error={this.props.error.message} />;
      } else if (this.props.isFetching) {
          return <Loading />;
      } else if(this.state.finishEditingFlag){
        return <div>
            Сохранено.
            <AdminCompetititonsChange />
        </div>;
      } else if ( this.state.changeTaskFlag ) {
        return <AdminTaskChange task={this.state.taskToChange} competitionId={this.props.competitionId} stageId={this.props.stage.Id}/>;
      } else {
          return (
          <div class="stage">
            <form onSubmit={this.sendStage.bind(this)}>
              <p>
                <label class = "questionField" for="stagetype">Этап:</label>
                <input type = "text" class = "answerField" id="stagetype" name="stagetype" ref={this.stagetypeInput} maxLength="50" required>{this.props.stage.Type}</input>
              </p>
              <button type="submit">Сохранить</button>
              <button onClick={this.finishEditing.bind(this)}>Вернуться</button>
            </form>
            <button onClick={this.createTask.bind(this)}>Создать новое задание</button>
                        <table class="tasks" border="1">
                          <thead>
                            <tr>
                              <th>Дата начала</th>
                              <th>Дата конца</th>
                              <th>Задание</th>
                              <th>Адрес</th>
                              <th></th>
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
                                <td><button class={"taskButton"} ref={(button) => {this.TaskEditButtons[this.props.stage.Tasks.findIndex(task)] = button }} onClick={this.editTask.bind(this)}>Редактировать задачу</button></td>
                              </tr>
                            ))}</tbody>
                          </table>
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
    saveStage: (data) => dispatch(saveStage(data))
  }
}

export default connect(mapProps, mapDispatch)(AdminStageChange)