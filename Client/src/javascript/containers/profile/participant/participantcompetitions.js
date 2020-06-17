import React from "react";
import { connect } from "react-redux";
import {
  getCompetitionsByParticipant,
  saveAnswer,
} from "../../../actions/actions.js";
import Error from "../../../components/system/error.js";
import Loading from "../../../components/system/loading.js";
import NoResults from "../../../components/system/noresults.js";
import ParticipantCompetititonsView from "../../../components/profile/participant/participantcompetitionsview.js";

export class ParticipantCompetititons extends React.Component {
  constructor(props) {
    super(props);
    this.sendAnswer = this.sendAnswer.bind(this);
    this.state = {
      competitions: [],
      answers: [],
    };
  }

  componentDidMount() {
    this.props.getCompetitionsByParticipant(this.props.participantId);
    this.timerId = setInterval(() => this.tick(), 1000);
  }

  componentWillUnmount() {
    clearInterval(this.timerId);
  }

  tick() {
    let competitionsNew = this.state.competitions.slice();
    if (competitionsNew.length != 0) {
      competitionsNew.forEach((competition) => {
        if (competition.stages.length != 0) {
          competition.stages.forEach((stage) => {
            if (stage.tasks.length != 0) {
              stage.tasks.forEach((task) => {
                task.IsActual = this.checkDateIsActual(
                  task.taskDateOfBegin,
                  task.taskDateOfEnd
                );
              });
            }
          });
        }
      });
    }
    this.setState({ competitions: competitionsNew });
  }

  copyToState() {
    let competitions = [];
    this.props.items.forEach((item) => {
      competitions.push(this.copyCompetition(item));
    });
    this.setState({ competitions: competitions });
  }

  copyCompetition(item) {
    let competitionState = {
      skill: item.Skill,
      dateOfBegin: item.DateOfBegin,
      dateOfEnd: item.DateOfEnd,
      stages: [],
    };
    if (item.Stages.length != 0) {
      item.Stages.forEach((stage) => {
        competitionState.stages.push(this.copyStage(stage));
      });
    }
    return competitionState;
  }

  copyStage(stage) {
    let stageState = {
      type: stage.Type,
      tasks: [],
    };
    if (stage.Tasks.length != 0) {
      this.stage.Tasks.forEach((task) => {
        stageState.tasks.push(this.copyTask(task));
      });
    }
    return stageState;
  }

  copyTask(task) {
    let begin = new Date(task.TaskDateOfBegin);
    let end = new Date(task.TaskDateOfEnd);
    let taskState = {
      id: task.Id,
      isActual: checkDateIsActual(begin, end),
      taskDateOfBegin: begin,
      taskDateOfEnd: end,
      description: task.Description,
    };
    return taskState;
  }

  checkDateIsActual(taskDateOfBegin, taskDateOfEnd) {
    var dateNow = new Date();
    return taskDateOfBegin < dateNow && taskDateOfEnd > dateNow;
  }

  handleInputChange(event) {
    const target = event.target;
    const value = target.value;
    const key = target.key;
    var arr = [];
    arr[key] = value;
    this.setState({ answers: answers.concat(arr) });
  }

  sendAnswer(taskId, answer) {
    var data = {
      taskId: taskId,
      participantId: this.props.participantId,
      projectLink: answer,
    };
    this.props.saveAnswer(data);
  }

  render() {
    if (!this.props.isSignedIn || this.props.role != "participant") {
      return <Redirect to="/singin" />;
    } else if (this.props.error) {
      return <Error error={this.props.error.message} />;
    } else if (this.props.isFetching) {
      return <Loading />;
    } else if (this.props.items.length == 0) {
      return <NoResults mes={"Нет актуальных событий"} />;
    } else {
      this.copyToState();
      return (
        <div>
          {this.props.items.map((item) => (
            <ParticipantCompetititonsView
              competition={item}
              sendAnswer={sendAnswer}
            />
          ))}
        </div>
      );
    }
  }
}

let mapProps = (state, ownProps) => {
  return {
    participantId: ownProps.cookies.id,
    role: ownProps.cookies.role,
    isSignedIn: ownProps.cookies.isSignedIn,
    items: state.data,
    isFetching: state.isFetching,
    error: state.error,
  };
};

let mapDispatch = (dispatch) => {
  return {
    getCompetitionsByParticipant: (participantId) =>
      dispatch(getCompetitionsByParticipant(participantId)),
    saveAnswer: (data) => dispatch(saveAnswer(data)),
  };
};

export default connect(mapProps, mapDispatch)(ParticipantCompetititons);
