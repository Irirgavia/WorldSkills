import React from "react";
import { connect } from "react-redux";
import {
  getCompetitionsByAdmin,
  saveCompetition,
  saveStage,
  saveTask,
} from "../../../actions/actions.js";
import AdminCompetititonsEditView from "../../../components/profile/admin/competitions/editcompetition/admincompetitioneditsview.js";
import AdminCompetititonView from "../../../components/profile/admin/competitions/noedit/admincompetitionview.js";
import Error from "../../../components/system/error.js";
import Loading from "../../../components/system/loading.js";
import NoResults from "../../../components/system/noresults.js";

export class AdminCompetititons extends React.Component {
  constructor(props) {
    super(props);
    this.createCompetition = this.createCompetition.bind(this);
    this.editCompetition = this.editCompetition.bind(this);
    this.finishEditCompetition = this.finishEditCompetition.bind(this);
    this.saveCompetition = this.saveCompetition.bind(this);
    this.state = {
      changeCompetitionFlag: false,
      saveDataFlag: false,
      competitionToChange: {},
    };
  }

  componentDidMount() {
    this.props.getCompetitionsByAdmin(this.props.adminId);
  }

  editCompetition(competition) {
    this.setState({
      changeCompetitionFlag: true,
      competitionToChange: competition,
    });
  }

  finishEditCompetition() {
    this.setState({
      changeCompetitionFlag: false,
      competitionToChange: {},
    });
    this.props.getCompetitionsByAdmin(this.props.adminId);
  }

  createCompetition() {
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

  saveCompetition(competitionId, skill, dateOfBegin, dateOfEnd) {
    var data = {
      competitionId: competitionId,
      skill: skill,
      dateOfBegin: dateOfBegin,
      dateOfEnd: dateOfEnd,
    };
    this.props.saveCompetition(data);
    this.setState({ saveDataFlag: true });
  }

  saveStage(stageId, stageType) {
    var data = {
      competitionId: competitionId,
      stageId: stageId,
      stageType: stageType,
    };
    this.props.saveStage(data);
    this.setState({ saveDataFlag: true });
  }

  saveTask(taskId, taskDateOfBegin, taskDateOfEnd, description, addresses) {
    var data = {
      taskId: taskId,
      taskDateOfBegin: taskDateOfBegin,
      taskDateOfEnd: taskDateOfEnd,
      description: description,
      addresses: addresses,
    };
    this.props.saveTask(data);
    this.setState({ saveDataFlag: true });
  }

  update() {
    this.props.getCompetitionsByAdmin(this.props.adminId);
    this.setState({ saveDataFlag: false });
  }

  render() {
    if (!this.props.isSignedIn || this.props.role != "administrator") {
      return <Redirect to="/singin" />;
    } else if (this.props.error) {
      return <Error error={this.props.error.message} />;
    } else if (this.props.isFetching) {
      return <Loading />;
    } else if (this.state.saveDataFlag) {
      this.update();
      return null;
    } else if (this.state.changeCompetitionFlag) {
      return (
        <AdminCompetititonsEditView
          competition={this.state.competitionToChange}
          finishEditCompetition={this.finishEditCompetition}
          saveCompetition={this.saveCompetition}
          saveStage={this.saveStage}
          saveTask={this.saveTask}
        />
      );
    } else if (this.props.items.length == 0) {
      return (
        <div>
          <NoResults mes={"Нет созданных соревнований"} />
          <button onClick={this.createCompetition}>
            Создать новое соревнование
          </button>
        </div>
      );
    } else {
      return (
        <div>
          <button onClick={this.createCompetition}>
            Создать новое соревнование
          </button>
          {this.props.items.map((item) => (
            <AdminCompetititonView
              competition={item}
              editCompetition={this.editCompetition}
            />
          ))}
        </div>
      );
    }
  }
}

let mapProps = (state) => {
  return {
    items: state.data,
    isFetching: state.isFetching,
    error: state.error,
  };
};

let mapDispatch = (dispatch) => {
  return {
    getCompetitionsByAdmin: (adminId) =>
      dispatch(getCompetitionsByAdmin(adminId)),
    saveCompetition: (data) => dispatch(saveCompetition(data)),
    saveStage: (data) => dispatch(saveStage(data)),
    saveTask: (data) => dispatch(saveTask(data)),
  };
};

export default connect(mapProps, mapDispatch)(AdminCompetititons);
