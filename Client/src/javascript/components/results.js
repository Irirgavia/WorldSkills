import React from "react";

export default class Results extends React.Component {
  render() {
    return (
      <form action="/results/search" method="get">
        <label for="skill">Профессия: </label>
        <input type="text" id="skill" name="skill" required />
        <label for="stage">Этап: </label>
        <input type="text" id="stage" name="stage" required />
        <label for="year">Год: </label>
        <input type="text" id="year" name="year" required />
        <button type="submit">Искать</button>
      </form>
    );
  }
}
