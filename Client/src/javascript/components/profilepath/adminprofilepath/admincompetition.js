import React from 'react';
import { connect } from 'react-redux';
import { getCompetitionsByAdmin, saveAnswer } from '../../../actions/actions.js';
import AdminCompetititonsChange from './change/admincompetitionchange.js'
import Error from '../../system/error.js';
import Loading from '../../system/loading.js';

export class AdminCompetititons extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
        changeCompetitionFlag: false,
        competitionToChange: {}
    };
  }

  componentDidMount() {
    this.props.getCompetitionsByAdmin(this.props.adminId);
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

  editCompetition(e){
    var target = e.target || e.srcElement;
    var index = this.CompetitionEditButtons.findIndex(target.ref);
    this.setState({
        changeCompetitionFlag: true,
        competitionToChange: this.props.items[index]
    });
  }

  createCompetition(e){
    var competition = {
        Id: -1,
        Skill: '',
        DateOfBegin: '',
        DateOfEnd: '',
        Stages: {}
    };
    this.setState({
        changeCompetitionFlag: true,
        competitionToChange: competition
    });
  }

  render() {
      if (this.props.error) {
          return <Error error={this.props.error.message} />;
      } else if (this.props.isFetching) {
          return <Loading />;
        } else if(this.state.changeCompetitionFlag){
            return <AdminCompetititonsChange competition={this.state.competitionToChange} />
        }else {
          return (
              <div>
                <button onClick={this.createCompetition.bind(this)}>Создать новое соревнование</button>
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
                                  <td>{task.Addresses}</td>
                                </tr>
                              ))}</tbody>
                            </table>
                      </div>
                    ))}
                    <button class={"competitionButton"} ref={(button) => {this.CompetitionEditButtons[this.props.items.findIndex(item)] = button }} onClick={this.editCompetition.bind(this)}>Редактировать соревнование</button>
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
      items: state.data,
      isFetching: state.isFetching,
      error: state.error
  }
}

let mapDispatch = (dispatch) => {
  return {
    getCompetitionsByAdmin: (adminId) => dispatch(getCompetitionsByAdmin(adminId)),
    saveAnswer: (data) => dispatch(saveAnswer(data))
  }
}

export default connect(mapProps, mapDispatch)(AdminCompetititons)