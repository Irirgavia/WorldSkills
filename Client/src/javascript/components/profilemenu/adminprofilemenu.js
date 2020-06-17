import React from "react";

export default class AdminProfileMenu extends React.Component {
  render() {
    return (
      <ul id="registration">
        <li id="profilemenu" class="down">
          {this.props.login}{" "}
          <span className="unreadNotificationAmount">
            {"{" + this.props.unreadNotificationAmount + "}"}
          </span>
          <ul class="submenu">
            <li>
              <a href="/administrator/personaldata">Личные данные</a>
            </li>
            <li>
              <a href="/administrator/competitions">Соревнования</a>
            </li>
            <li>
              <a href="/administrator/accounts">Пользователи</a>
            </li>
            <li>
              <a href="/signout">Выйти</a>
            </li>
          </ul>
        </li>
      </ul>
    );
  }
}
