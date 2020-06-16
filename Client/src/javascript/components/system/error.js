import React from "react";

export default class Error extends React.Component {
  render() {
    var mes = "";
    switch (this.props.error) {
      case "Password is wrong.": {
        mes = "Неправильно введен пароль.";
      }
      case "User is not found.": {
        mes = "Пользователь с таким логином не найден.";
      }
      case "Bad Request": {
        mes = "Ошибка запроса.";
      }
      default: {
        mes = this.props.error;
      }
    }
    if (mes == "") return <div></div>;
    return <div id="error">Ошибка: {mes}</div>;
  }
}
