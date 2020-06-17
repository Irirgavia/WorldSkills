import React from "react";
import { Redirect } from "react-router-dom";
import { connect } from "react-redux";
import { getUser } from "../actions/actions.js";
import Error from "../components/system/error.js";
import Loading from "../components/system/loading.js";

export class SignIn extends React.Component {
  constructor(props) {
    super(props);
    this.logingIn = this.logingIn.bind(this);
    this.state = {
      login: "login",
      password: "password",
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

  logingIn(event) {
    event.preventDefault();
    this.props.getUser(this.state.login, this.state.password);
  }

  success() {
    const { cookies } = this.props;
    cookies.set("isSignedIn", "true", { path: "/" });
    cookies.set("id", this.props.id, { path: "/" });
    cookies.set("login", this.state.login, { path: "/" });
    cookies.set("role", this.props.role, { path: "/" });
    cookies.set(
      "unreadNotificationAmount",
      this.props.unreadNotificationAmount,
      { path: "/" }
    );
  }

  render() {
    console.log(this.props.isFetching);
    if (this.props.isSignedIn) {
      this.success();
      return <Redirect to="/" />;
    } else if (this.props.isFetching) {
      return <Loading />;
    } else {
      return (
        <form onSubmit={this.logingIn}>
          <p>
            <label for="login">Логин: </label>
            <input
              type="text"
              id="login"
              name="login"
              onChange={this.handleInputChange}
              value={this.state.login}
            />
          </p>
          <p>
            <label for="password">Пароль: </label>
            <input
              type="password"
              id="password"
              name="password"
              onChange={this.handleInputChange}
              value={this.state.password}
            />
          </p>
          <button type="submit">Войти</button>
          <Error error={this.props.error.message} />
        </form>
      );
    }
  }
}

let mapProps = (state, ownProps) => {
  return {
    cookies: ownProps.cookies,
    isFetching: state.isFetching,
    id: state.user.id,
    role: state.user.role,
    isSignedIn: state.isSignedIn,
    unreadNotificationAmount: state.unreadNotificationAmount,
    error: state.error,
  };
};

let mapDispatch = (dispatch) => {
  return {
    getUser: (login, password) => dispatch(getUser(login, password)),
  };
};

export default connect(mapProps, mapDispatch)(SignIn);
