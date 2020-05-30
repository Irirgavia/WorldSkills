import React from 'react';
import { Redirect } from 'react-router-dom';
import { connect } from 'react-redux';
import { getUser } from '../actions/actions.js';
import Error from './system/error.js'
import Loading from './system/loading.js';


export class SignIn extends React.Component {
    constructor(props) {
        super(props);
        this.loginInput = React.createRef();
        this.passwordInput = React.createRef();
        this.logingIn= this.logingIn.bind(this);
    }
  
    logingIn(event) {
        event.preventDefault();
        console.log("logingIn!");
        console.log(this.loginInput);
        console.log(this.passwordInput);
        var login = this.loginInput.current.value;
        var password = this.passwordInput.current.value;
        console.log(login);
        console.log(password);
        this.props.getUser(login, password);
    }

    render() {
        console.log(this.props.isFetching);
        if(this.props.isSignedIn)
        {
            return <Redirect to="/" />;
        } else if(this.props.isFetching)
        {
            return <Loading />;
        } else
        {
            console.log("form!");
            return <form onSubmit={this.logingIn}>
            <label for = "login">Логин: </label>
            <input type = "text" id="login" name="login" ref={this.loginInput} />
            <label for = "password">Пароль: </label>
            <input type = "password" id="password" name="password" ref={this.passwordInput} />
            <button type="submit">Войти</button>
            <Error error={this.props.error.message} />
        </form>
        }
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

export default connect(mapProps, mapDispatch)(SignIn)