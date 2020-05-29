import React from 'react';
import { connect } from 'react-redux';
import { getAnswersToRate, saveMark } from '../../../actions/actions.js';
import { Error } from '../../system/error.js';
import { Loading } from '../../system/loading.js';

export class JudgeAnswers extends React.Component {
  constructor(props) {
    super(props);
  }

  componentDidMount() {
    this.props.getAnswersToRate(this.props.judgeId);
  }
      
  send(e){
    var target = e.target || e.srcElement;
    var index = this.MarkSendButtons.findIndex(target.ref);
    var data = {
      answerId: index,
      mark: this.MarkInputs[index].value
    };
    this.props.saveMark(data);
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
                        {stage.Tasks.map((task) =>
                        (
                          <div class="task judge">
                            <p class="taskdescription judge"><a href={task.Description}>Задание</a></p>
                            <table class="tasks" border="1">
                              <thead>
                                <tr>
                                  <th>Ответ</th>
                                  <th>Баллы</th>
                                  <th></th>
                                </tr>
                              </thead>
                              <tbody>
                                {task.Answers.map((answer) => {
                                  <tr class="answer judge">
                                    <td><a href={answer.Link}>Ответ</a></td>
                                    <td><input type="number" class="mark" min="0" ref={(input) => {this.MarkInputs[answer.Id] = input }}></input></td>
                                    <td><button class={"markButton"} ref={(button) => {this.MarkSendButtons[answer.Id] = button }} onClick={this.send.bind(this)}>Отправить</button></td>
                                  </tr>
                                })}
                                </tbody>
                            </table>
                          </div>
                        ))}
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
    judgeId: state.user.id,
      items: state.data,
      isFetching: state.isFetching,
      error: state.error
  }
}

let mapDispatch = (dispatch) => {
  return {
    getAnswersToRate: (judgeId) => dispatch(getAnswersToRate(judgeId)),
    saveMark: (data) => dispatch(saveMark(data))
  }
}

export default connect(mapProps, mapDispatch)(JudgeAnswers)