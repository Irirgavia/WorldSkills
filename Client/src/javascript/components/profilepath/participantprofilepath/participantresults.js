import React from "react";
import { connect } from "react-redux";
import { getResultsByParticipant } from "../../../actions/actions.js";
import Error from "../../system/error.js";
import Loading from "../../system/loading.js";
import NoResults from "../../system/noresults.js";

export class ParticipantResults extends React.Component {
  constructor(props) {
    super(props);
  }

  componentDidMount() {
    this.props.getResultsByParticipant(this.props.participantId);
  }

  render() {
    if (!this.props.isSignedIn || this.props.role != "participant") {
      return <Redirect to="/singin" />;
    } else if (this.props.error) {
      return <Error error={this.props.error.message} />;
    } else if (this.props.isFetching) {
      return <Loading />;
    } else if (this.props.items.length == 0) {
      return <NoResults mes={"Нет результатов"} />;
    } else {
      return (
        <table border="1">
          <tr>
            <th>Профессия</th>
            <th>Этап</th>
            <th>Дата</th>
            <th>Баллы</th>
          </tr>
          {this.props.items.map((item) => (
            <tr>
              <td>{item.Skill}</td>
              <td>{item.Stage}</td>
              <td>{item.Date}</td>
              <td>{item.Mark}</td>
            </tr>
          ))}
        </table>
      );
    }
  }
}

let mapProps = (state) => {
  return {
    participantId: state.user.id,
    role: state.user.role,
    isSignedIn: state.isSignedIn,
    items: state.data,
    isFetching: state.isFetching,
    error: state.error,
  };
};

let mapDispatch = (dispatch) => {
  return {
    getResultsByParticipant: (participantId) =>
      dispatch(getResultsByParticipant(participantId)),
  };
};

export default connect(mapProps, mapDispatch)(ParticipantResults);
