import React from "react";
import { connect } from "react-redux";
import {
  getCompetitionsByAdmin,
  saveAnswer,
} from "../../../actions/actions.js";
import AdminCompetititonsChange from "./change/admincompetitionchange.js";
import Error from "../../system/error.js";
import Loading from "../../system/loading.js";
import NoResults from "../../system/noresults.js";

export class AdminCompetititons extends React.Component {
  constructor(props) {
    super(props);
    this.createCompetition = this.createCompetition.bind(this);
    this.editCompetition = this.editCompetition.bind(this);
    this.state = {
      changeCompetitionFlag: false,
      competitionToChange: {},
    };
  }

  componentDidMount() {
    this.props.getCompetitionsByAdmin(this.props.adminId);
    this.timerId = setInterval(() => this.tick(), 1000);
  }

  componentWillUnmount() {
    clearInterval(this.timerId);
  }

  tick() {
    var date = new Date();
    this.props.items.forEach((item) => {
      item.Stages.forEach((stage) => {
        stage.Tasks.forEach((task) => {
          if (task.DateOfBegin < date && task.DateOfEnd > date) {
            task.IsActual = true;
          } else {
            task.IsActual = false;
          }
        });
      });
    });
  }

  editCompetition(e) {
    var target = e.target || e.srcElement;
    var id = target.key;
    var competition = this.props.items.find(this.findElementInArrayById, id);
    this.setState({
      changeCompetitionFlag: true,
      competitionToChange: competition,
    });
  }

  findElementInArrayById(element, index, array) {
    return element.Id == this;
  }

  createCompetition(e) {
    var competition = {
      Id: -1,
      Skill: "",
      DateOfBegin: "",
      DateOfEnd: "",
      Stages: {},
    };
    this.setState({
      changeCompetitionFlag: true,
      competitionToChange: competition,
    });
  }

  render() {
    if (!this.props.isSignedIn || this.props.role != "administrator") {
      return <Redirect to="/singin" />;
    } else if (this.props.error) {
      return <Error error={this.props.error.message} />;
    } else if (this.props.isFetching) {
      return <Loading />;
    } else if (this.props.items.length == 0) {
      return <NoResults mes={"Нет созданных соревнований"} />;
    } else if (this.state.changeCompetitionFlag) {
      return (
        <AdminCompetititonsChange
          competition={this.state.competitionToChange}
        />
      );
    } else {
      return (
        <div>
          <button onClick={this.createCompetition}>
            Создать новое соревнование
          </button>
          {this.props.items.map((item) => (
            <div class="competition">
              <p class="competitiondata">
                Профессия: {item.Skill} Время проведения: {item.DateOfBegin}-
                {item.DateOfEnd}
              </p>
              {item.Stages.map((stage) => (
                <div class="stage">
                  <p class="stagetype">Этап: {stage.Type}</p>
                  <table class="tasks" border="1">
                    <thead>
                      <tr>
                        <th>Дата начала</th>
                        <th>Дата конца</th>
                        <th>Задание</th>
                        <th>Адреса</th>
                      </tr>
                    </thead>
                    <tbody>
                      {stage.Tasks.map((task) => (
                        <tr class={"task " + task.IsActual}>
                          <td>{task.TaskDateOfBegin}</td>
                          <td>{task.TaskDateOfEnd}</td>
                          <td>
                            <a href={task.Description}>Задание</a>
                          </td>
                          <td>{task.Addresses}</td>
                        </tr>
                      ))}
                    </tbody>
                  </table>
                </div>
              ))}
              <button
                class={"competitionButton"}
                key={item.Id}
                onClick={this.editCompetition}
              >
                Редактировать соревнование
              </button>
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
    role: state.user.role,
    isSignedIn: state.isSignedIn,
    items: state.data,
    isFetching: state.isFetching,
    error: state.error,
  };
};

let mapDispatch = (dispatch) => {
  return {
    getCompetitionsByAdmin: (adminId) =>
      dispatch(getCompetitionsByAdmin(adminId)),
    saveAnswer: (data) => dispatch(saveAnswer(data)),
  };
};

export default connect(mapProps, mapDispatch)(AdminCompetititons);
/*                    <button class={"competitionButton"} key={index} ref={(button) => {this.CompetitionEditButtons[this.props.items.findIndex(item)] = button }} onClick={this.editCompetition.bind(this)}>Редактировать соревнование</button>
 */
