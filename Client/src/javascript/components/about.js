import React from "react";
import { Link } from "react-router-dom";

export default class About extends React.Component {
  render() {
    return (
      <nav id="navbar-about">
        <ul>
          <li>
            <Link to="/about/history">История</Link>
          </li>
          <li>
            <Link to="/about/rules">Правила</Link>
          </li>
        </ul>
      </nav>
    );
  }
}
