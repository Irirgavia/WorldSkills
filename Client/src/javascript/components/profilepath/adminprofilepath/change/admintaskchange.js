import React from "react";
import { connect } from "react-redux";
import { saveTask } from "../../../../actions/actions.js";
import AdminStageChange from "./adminstagechange.js";
import Error from "../../../system/error.js";
import Loading from "../../../system/loading.js";

export class AdminTaskChange extends React.Component {
  constructor(props) {
    super(props);
    this.sendTask = this.sendTask.bind(this);
    this.finishEditing = this.finishEditing.bind(this);
    this.state = {
      finishEditingFlag: false,
      taskDateOfBegin: "",
      taskDateOfEnd: "",
      description: "",
      addresses: "",
    };

    this.handleInputChange = this.handleInputChange.bind(this);
  }

  handleInputChange(event) {
    const target = event.target;
    const value = target.value;
    const name = target.name;

    this.setState({
      [name]: value,
    });
  }

  sendTask(event) {
    event.preventDefault();
    var data = {
      competitionId: this.props.competitionId,
      stageId: this.props.stageId,
      id: this.props.task.Id,
      taskDateOfBegin: this.state.taskDateOfBegin,
      taskDateOfEnd: this.state.taskDateOfEnd,
      description: this.state.description,
      addresses: this.state.addresses,
    };
    this.props.saveTask(data);
  }

  finishEditing() {
    this.setState({ finishEditingFlag: true });
  }

  render() {
    if (!this.props.isSignedIn || this.props.role != "administrator") {
      return <Redirect to="/singin" />;
    } else if (this.props.error) {
      return <Error error={this.props.error.message} />;
    } else if (this.props.isFetching) {
      return <Loading />;
    } else if (this.state.finishEditingFlag) {
      return (
        <div>
          <AdminStageChange />
        </div>
      );
    } else {
      return (
        <div class="tasks">
          <form onSubmit={this.sendTask}>
            <p>
              <label class="questionField" for="taskDateOfBegin">
                Дата начала:
              </label>
              <input
                type="date"
                class="answerField"
                id="taskDateOfBegin"
                name="taskDateOfBegin"
                onChange={this.handleInputChange}
                maxLength="50"
                required
              >
                {this.props.task.TaskDateOfBegin}
              </input>
            </p>
            <p>
              <label class="questionField" for="taskDateOfEnd">
                Дата начала:
              </label>
              <input
                type="date"
                class="answerField"
                id="taskDateOfEnd"
                name="taskDateOfEnd"
                onChange={this.handleInputChange}
                maxLength="50"
                required
              >
                {this.props.task.TaskDateOfEnd}
              </input>
            </p>
            <p>
              <label class="questionField" for="description">
                Дата начала:
              </label>
              <input
                type="text"
                class="answerField"
                id="description"
                name="description"
                onChange={this.handleInputChange}
                maxLength="50"
                required
              >
                {this.props.task.Description}
              </input>
            </p>
            <p>
              <label class="questionField" for="addresses">
                Дата начала:
              </label>
              <input
                type="text"
                class="answerField"
                id="addresses"
                name="addresses"
                onChange={this.handleInputChange}
                maxLength="50"
                required
              >
                {this.props.task.Addresses}
              </input>
            </p>
            <button type="submit">Сохранить</button>
            <button onClick={this.finishEditing}>Вернуться</button>
          </form>
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
    isFetching: state.isFetching,
    error: state.error,
  };
};

let mapDispatch = (dispatch) => {
  return {
    saveTask: (data) => dispatch(saveTask(data)),
  };
};

export default connect(mapProps, mapDispatch)(AdminTaskChange);
