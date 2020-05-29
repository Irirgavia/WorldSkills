import React from 'react';
import { connect } from 'react-redux';
import { saveTask } from '../../../actions/actions.js';
import { AdminStageCompetititons } from './admincompetitionchange.js'
import * as systemComponents from '../../system'

export class AdminTaskChange extends React.Component {
  constructor(props) {
    super(props);
    this.taskDateOfBeginInput = React.createRef();
    this.taskDateOfEndInput = React.createRef();
    this.descriptionInput = React.createRef();
    this.addressesInput = React.createRef();
    this.state = {
      finishEditingFlag: false
    };
  }

  sendTask(){
    var data = {
        competitionId: this.props.competitionId,
        stageId: this.props.stageId,
        Id: this.props.task.Id,
        taskDateOfBegin: this.taskDateOfBeginInput.value,
        taskDateOfEnd: this.taskDateOfEndInput.value,
        description: this.descriptionInput.value,
        addresses: this.addressesInput.value,
    };
    this.props.saveTask(data);
  }

  finishEditing(){
    this.setState({finishEditingFlag: true});
  }

  render() {
      if (this.props.error) {
          return <systemComponents.Error error={this.props.error.message} />;
      } else if (this.props.isFetching) {
          return <systemComponents.Loading />;
      } else if(this.state.finishEditingFlag){
        return <div>
            Сохранено.
            <AdminStageCompetititons />
        </div>;
      } else {
          return (
          <div class="tasks">
            <form action={this.sendTask.bind(this)}>
              <p>
                <label class = "questionField" for="taskDateOfBegin">Дата начала:</label>
                <input type = "date" class = "answerField" id="taskDateOfBegin" name="taskDateOfBegin" ref={this.taskDateOfBeginInput} maxLength="50" required>{this.props.task.TaskDateOfBegin}</input>
              </p>
              <p>
                <label class = "questionField" for="taskDateOfEnd">Дата начала:</label>
                <input type = "date" class = "answerField" id="taskDateOfEnd" name="taskDateOfEnd" ref={this.taskDateOfEndInput} maxLength="50" required>{this.props.task.TaskDateOfEnd}</input>
              </p>
              <p>
                <label class = "questionField" for="description">Дата начала:</label>
                <input type = "text" class = "answerField" id="description" name="description" ref={this.descriptionInput} maxLength="50" required>{this.props.task.Description}</input>
              </p>
              <p>
                <label class = "questionField" for="addresses">Дата начала:</label>
                <input type = "text" class = "answerField" id="addresses" name="addresses" ref={this.addressesInput} maxLength="50" required>{this.props.task.Addresses}</input>
              </p>
              <button type="submit">Сохранить</button>
              <button onClick={this.finishEditing.bind(this)}>Вернуться</button>
            </form>
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
    saveTask: (data) => dispatch(saveTask(data))
  }
}

export default connect(mapProps, mapDispatch)(AdminStageChange)