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
      return (
        <div>
          <NoResults mes={"Нет созданных соревнований"} />
          <button onClick={this.createCompetition}>
            Создать новое соревнование
          </button>
        </div>
      );
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
            <Competition competition={item} />
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

class Competition extends React.Component {
  render() {
    if (this.props.competition.Stages.length == 0) {
      return (
        <div class="competition">
          <p class="competitiondata">
            Профессия: {this.props.competition.Skill} Время проведения:{" "}
            {this.props.competition.DateOfBegin}-
            {this.props.competition.DateOfEnd}
          </p>
          <button
            class={"competitionButton"}
            key={this.props.competition.Id}
            onClick={this.editCompetition}
          >
            Редактировать соревнование
          </button>
        </div>
      );
    } else {
      return (
        <div class="competition">
          <p class="competitiondata">
            Профессия: {this.props.competition.Skill} Время проведения:{" "}
            {this.props.competition.DateOfBegin}-
            {this.props.competition.DateOfEnd}
          </p>
          {this.props.competition.Stages.map((stage) => (
            <Stage stage={stage} />
          ))}
          <button
            class={"competitionButton"}
            key={this.props.competition.Id}
            onClick={this.editCompetition}
          >
            Редактировать соревнование
          </button>
        </div>
      );
    }
  }
}

class Stage extends React.Component {
  render() {
    if (this.props.stage.Tasks.length == 0) {
      return (
        <div class="stage">
          <p class="stagetype">Этап: {this.props.stage.Type}</p>
        </div>
      );
    } else {
      return (
        <div class="stage">
          <p class="stagetype">Этап: {this.props.stage.Type}</p>
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
              {this.props.stage.Tasks.map((task) => (
                <Task task={task} />
              ))}
            </tbody>
          </table>
        </div>
      );
    }
  }
}

class Task extends React.Component {
  render() {
    return (
      <tr class={"task " + this.props.task.IsActual}>
        <td>{this.props.task.TaskDateOfBegin}</td>
        <td>{this.props.task.TaskDateOfEnd}</td>
        <td>
          <a href={this.props.task.Description}>Задание</a>
        </td>
        <td>{this.props.task.Addresses}</td>
      </tr>
    );
  }
}
