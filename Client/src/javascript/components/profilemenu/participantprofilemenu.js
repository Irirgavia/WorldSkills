import React from "react";

export default class ParticipantProfileMenu extends React.Component {
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
              <a href="/participant/notifications">Уведомления</a>
            </li>
            <li>
              <a href="/participant/personaldata">Личные данные</a>
            </li>
            <li>
              <a href="/participant/results">Результаты</a>
            </li>
            <li>
              <a href="/participant/competitions">Текущие соревнования</a>
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
