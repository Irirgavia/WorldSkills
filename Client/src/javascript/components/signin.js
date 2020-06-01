import React from "react";
import { Redirect } from "react-router-dom";
import { connect } from "react-redux";
import { getUser } from "../actions/actions.js";
import Error from "./system/error.js";
import Loading from "./system/loading.js";

export class SignIn extends React.Component {
  constructor(props) {
    super(props);
    this.logingIn = this.logingIn.bind(this);
    this.state = {
      login: "",
      password: "",
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
    console.log("logingIn!");
    console.log(this.state.login);
    console.log(this.state.password);
    this.props.getUser(this.state.login, this.state.password);
  }

  render() {
    console.log(this.props.isFetching);
    if (this.props.isSignedIn) {
      return <Redirect to="/" />;
    } else if (this.props.isFetching) {
      return <Loading />;
    } else {
      console.log("form!");
      return (
        <form onSubmit={this.logingIn}>
          <label for="login">Логин: </label>
          <input
            type="text"
            id="login"
            name="login"
            onChange={this.handleInputChange}
          />
          <label for="password">Пароль: </label>
          <input
            type="password"
            id="password"
            name="password"
            onChange={this.handleInputChange}
          />
          <button type="submit">Войти</button>
          <Error error={this.props.error.message} />
        </form>
      );
    }
  }
}

let mapProps = (state) => {
  return {
    isFetching: state.isFetching,
    isSignedIn: state.isSignedIn,
    error: state.error,
  };
};

let mapDispatch = (dispatch) => {
  return {
    getUser: (login, password) => dispatch(getUser(login, password)),
  };
};

export default connect(mapProps, mapDispatch)(SignIn);
