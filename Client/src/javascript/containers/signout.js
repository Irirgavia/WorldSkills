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
    this.props.cookies.set("isSignedIn", "false", { path: "/" });
    this.props.cookies.remove("id", { path: "/" });
    this.props.cookies.remove("login", { path: "/" });
    this.props.cookies.remove("role", { path: "/" });
  }

  render() {
    return <Redirect to="/" />;
  }
}

let mapProps = (ownProps) => {
  return {
    cookies: ownProps.cookies,
  };
};

let mapDispatch = (dispatch) => {
  return {
    logOutUser: () => dispatch(logOutUser()),
  };
};

export default connect(mapProps, mapDispatch)(SignOut);
