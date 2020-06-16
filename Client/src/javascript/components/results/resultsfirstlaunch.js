import React from "react";

export default class ResultsFirstLaunch extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      skill: "",
      stage: "",
      year: "",
    };

    this.handleInputChange = this.handleInputChange.bind(this);
    this.search = this.search.bind(this);
  }

  handleInputChange(event) {
    const target = event.target;
    const value = target.value;
    const name = target.name;

    this.setState({
      [name]: value,
    });
  }

  search(event) {
    event.preventDefault();
    this.props.searchResults(
      this.state.skill,
      this.state.stage,
      this.state.year
    );
  }

  render() {
    console.log("ResultsFirstLaunch");
    return (
      <form onSubmit={this.search}>
        <label class="questionField">Профессия: </label>
        <select
          class="answerField"
          name="skill"
          onChange={this.handleInputChange}
        >
          <option selected value="All">
            Все
          </option>
          {this.props.skillNames.map((skillName) => (
            <option value={skillName}>{skillName}</option>
          ))}
        </select>

        <label class="questionField">Этап: </label>
        <select
          class="answerField"
          name="stage"
          onChange={this.handleInputChange}
        >
          <option selected value="All">
            Все
          </option>
          {this.props.stageTypes.map((stageType) => (
            <option value={stageType}>{stageType}</option>
          ))}
        </select>
        <label for="year">Год: </label>
        <input
          type="number"
          id="year"
          name="year"
          min="1946"
          max="3000"
          step="1"
          onChange={this.handleInputChange}
        />
        <button type="submit">Искать</button>
      </form>
    );
  }
}
