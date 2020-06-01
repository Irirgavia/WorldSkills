import React from "react";
import { Redirect } from "react-router-dom";
import { connect } from "react-redux";
import { logOutUser } from "../actions/actions.js";

export class SignOut extends React.Component {
  constructor(props) {
    super(props);
  }

  componentDidMount() {
    this.props.logOutUser();
  }

  render() {
    return <Redirect to="/" />;
  }
}

let mapDispatch = (dispatch) => {
  return {
    logOutUser: () => dispatch(logOutUser()),
  };
};

export default connect(null, mapDispatch)(SignOut);
