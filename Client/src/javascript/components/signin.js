import React from 'react';

export default class Signin extends React.Component {
    render() {
        return <form action="/user" method="get">
            <label for = "login">Логин: </label>
            <input type = "text" id="login" name="login" />
            <label for = "password">Пароль: </label>
            <input type = "password" id="password" name="password" />
            <button type = "submit">Войти</button>
        </form>
    }
}