import React from "react";

export default class About extends React.Component {
  render() {
    return (
      <div>
        <nav id="navbar-about">
          <ul>
            <li>
              <a href="#history">История</a>
            </li>
            <li>
              <a href="#rules">Правила</a>
            </li>
          </ul>
        </nav>
        <div id="history">History</div>
        <div id="rules">Rules</div>
      </div>
    );
  }
}
