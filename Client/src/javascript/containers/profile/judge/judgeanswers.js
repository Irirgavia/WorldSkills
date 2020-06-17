import React from "react";
import { connect } from "react-redux";
import { getAnswersToRate, saveMark } from "../../../actions/actions.js";
import Error from "../../../components/system/error.js";
import Loading from "../../../components/system/loading.js";
import NoResults from "../../../components/system/noresults.js";
import JudgeCompetititonsView from "../../../components/profile/judge/judgecompetitionsview.js";

export class JudgeAnswers extends React.Component {
  constructor(props) {
    super(props);
    this.sendMark = this.sendMark.bind(this);
  }

  componentDidMount() {
    this.props.getAnswersToRate(this.props.judgeId);
  }

  sendMark(answerId, mark) {
    var data = {
      answerId: answerId,
      mark: mark,
    };
    this.props.saveMark(data);
  }

  render() {
    if (!this.props.isSignedIn || this.props.role != "judge") {
      return <Redirect to="/singin" />;
    } else if (this.props.error) {
      return <Error error={this.props.error.message} />;
    } else if (this.props.isFetching) {
      return <Loading />;
    } else if (this.props.items.length == 0) {
      return <NoResults mes={"Нет ответов для проверки"} />;
    } else {
      return (
        <div>
          {this.props.items.map((item) => (
            <JudgeCompetititonsView
              competition={item}
              sendMark={this.sendMark}
            />
          ))}
        </div>
      );
    }
  }
}

let mapProps = (state, ownProps) => {
  return {
    judgeId: ownProps.cookies.cookies.id,
    role: ownProps.cookies.cookies.role,
    isSignedIn: ownProps.cookies.cookies.isSignedIn,
    items: state.data,
    isFetching: state.isFetching,
    error: state.error,
  };
};

let mapDispatch = (dispatch) => {
  return {
    getAnswersToRate: (judgeId) => dispatch(getAnswersToRate(judgeId)),
    saveMark: (data) => dispatch(saveMark(data)),
  };
};

export default connect(mapProps, mapDispatch)(JudgeAnswers);
