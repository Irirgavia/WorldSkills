import React from 'react';

export default class Signin extends React.Component {
    render() {
        return <div>
            <p>
                <label for="login">Логин: </label>
                <input type="text" id="login" name="login" />
            </p>
            <p>
                <label for="password">Пароль: </label>
                <input type="password" id="password" name="password" />
            </p>
            <p>
                <button type="submit">Войти</button>
            </p>
        </div>
    }
}