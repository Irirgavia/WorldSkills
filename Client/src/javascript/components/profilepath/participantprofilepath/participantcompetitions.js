import React from 'react';
import { connect } from 'react-redux';
import { getCompetitionsByParticipant, saveAnswer } from '../../../actions/actions.js';
import { Error } from '../../system/error.js';
import { Loading } from '../../system/loading.js';

export class ParticipantCompetititons extends React.Component {
  constructor(props) {
    super(props);
  }

  componentDidMount() {
    this.props.getCompetitionsByParticipant(this.props.participantId);
    this.timerId = setInterval(
      ()=> this.tick(),
      1000
    );
  }

  componentWillUnmount() {
    clearInterval(this.timerId);
  }

  tick() {
    var date = new Date();
    this.props.items.forEach((item) => {
      item.Stages.forEach((stage) =>
      {
        stage.Tasks.forEach((task) => {
          if (task.DateOfBegin < date && task.DateOfEnd > date) {
            task.IsActual = true
          } else {
            task.IsActual = false
          }
        })
      })
    });
  }
      
  send(e){
    var target = e.target || e.srcElement;
    var index = this.AnswerSendButtons.findIndex(target.ref);
    var data = {
      taskId: index,
      participantId: this.participantId,
      projectLink: this.AnswerInputs[index].value
    };
    this.props.saveAnswer(data);
  }

  render() {
      if (this.props.error) {
          return <Error error={this.props.error.message} />;
      } else if (this.props.isFetching) {
          return <Loading />;
      } else {
          return (
              <div>
                {this.props.items.map((item) =>
                (
                  <div class="competition">
                    <p class="competitiondata">{item.Skill} {item.DateOfBegin}-{item.DateOfEnd}</p>
                    {item.Stages.map((stage) =>
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
                                  <td><input type="url" class={"answer"} ref={(input) => {this.AnswerInputs[task.Id] = input }}></input></td>
                                  <td><button class={"answerButton"} ref={(button) => {this.AnswerSendButtons[task.Id] = button }} onClick={this.send.bind(this)}>Отправить</button></td>
                                </tr>
                              ))}</tbody>
                            </table>
                      </div>
                    ))}
                  </div>
                ))}
              </div>
          );
      }
    }
  }

let mapProps = (state) => {
  return {
    participantId: state.user.id,
      items: state.data,
      isFetching: state.isFetching,
      error: state.error
  }
}

let mapDispatch = (dispatch) => {
  return {
    getCompetitionsByParticipant: (participantId) => dispatch(getCompetitionsByParticipant(participantId)),
    saveAnswer: (data) => dispatch(saveAnswer(data))
  }
}

export default connect(mapProps, mapDispatch)(ParticipantCompetititons)