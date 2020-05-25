import React from 'react';
import { connect } from 'react-redux';
import { getUser } from '../actions/actions.js'


export class Signin extends React.Component {
    constructor(props) {
      super(props);
    }
  
    logingIn() {
        var login = this.refs.loginInput.value;
        var password = this.refs.passwordInput.value;
        this.props.getUser(login, password);
    }

    render() {
        return <form action={this.logingIn.bind(this)}>
            <label for = "login">Логин: </label>
            <input type = "text" id="login" name="login" ref="loginInput" />
            <label for = "password">Пароль: </label>
            <input type = "password" id="password" name="password" ref="passwordInput" />
            <button type = "submit">Войти</button>
            <p>{
            }</p>
        </form>
    }
}

let mapProps = (state) => {
    return {
        isFetching: state.isFetching,
        isSignedIn: state.isSignedIn,
        error: state.error
    }
}

let mapDispatch = (dispatch) => {
    return {
        getUser: (login, password) => dispatch(getUser(login, password))
    }
}

export default connect(mapProps, mapDispatch)(Signin)