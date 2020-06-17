import React from "react";

export default class JudgeProfileMenu extends React.Component {
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
              <a href="/judge/notifications">Уведомления</a>
            </li>
            <li>
              <a href="/judge/personaldata">Личные данные</a>
            </li>
            <li>
              <a href="/judge/account">Аккаунт</a>
            </li>
            <li>
              <a href="/judge/answers">Ответы</a>
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
