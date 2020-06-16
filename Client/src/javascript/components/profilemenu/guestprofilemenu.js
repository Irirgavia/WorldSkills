import React from "react";

export default class GuestProfileMenu extends React.Component {
  render() {
    return (
      <ul id="registration">
        <li>
          <a href="https://docs.google.com/forms/d/e/1FAIpQLSdyPuXOouBLsxRCG3tiQTruitJjgcmV3Zlv17RZMSDIRXjEtQ/viewform?usp=sf_link">
            Регистрация на участие
          </a>
        </li>
        <li>
          <a href="/signin" id="accountlink">
            Вход
          </a>
        </li>
      </ul>
    );
  }
}
