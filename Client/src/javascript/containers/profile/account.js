import React from "react";
import { Redirect } from "react-router-dom";
import { connect } from "react-redux";
import { saveAccountData } from "../../actions/actions.js";
import Error from "../../components/system/error.js";

export class Account extends React.Component {
  constructor(props) {
    super(props);
    this.save = this.save.bind(this);
    this.state = {
      newLogin: "",
      oldPassword: "",
      newPassword: "",
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

  save() {
    var data = {
      oldLogin: this.props.login,
      oldPassword: this.state.oldPassword,
      newLogin: this.state.newLogin,
      newPassword: this.state.newPassword,
    };
    this.props.saveAccountData(data);
  }

  render() {
    if (!this.props.isSignedIn) {
      return <Redirect to="/singin" />;
    } else {
      return (
        <form onSubmit={this.save}>
          <p>Ваш текущий логин: {this.props.login}</p>
          <p>
            <label for="newLogin">Введите новый логин: </label>
            <input
              type="text"
              id="newLogin"
              name="newLogin"
              onChange={this.handleInputChange}
              value={this.state.newLogin}
            />
          </p>
          <p>
            <label for="oldPassword">Введите старый пароль: </label>
            <input
              type="password"
              id="oldPassword"
              name="oldPassword"
              onChange={this.handleInputChange}
              value={this.state.oldPassword}
            />
          </p>
          <p>
            <label for="newPassword">Введите новый пароль: </label>
            <input
              type="password"
              id="newPassword"
              name="newPassword"
              onChange={this.handleInputChange}
              value={this.state.newPassword}
            />
          </p>
          <button type="submit">Сохранить</button>
          <Error error={this.props.error.message} />
        </form>
      );
    }
  }
}

let mapProps = (state) => {
  return {
    userId: state.user.id,
    login: state.user.login,
    isFetching: state.isFetching,
    isSignedIn: state.isSignedIn,
    error: state.data,
  };
};

let mapDispatch = (dispatch) => {
  return {
    saveAccountData: (userId, login, password) =>
      dispatch(saveAccountData(userId, login, password)),
  };
};

export default connect(mapProps, mapDispatch)(Account);
