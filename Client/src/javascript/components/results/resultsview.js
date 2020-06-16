import React from "react";
import NoResults from "../system/noresults.js";
import CompetitionResults from "./competitionresults.js";

export default class ResultsView extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      skill: this.props.skill,
      stage: this.props.stage,
      year: this.props.year,
    };

    this.handleInputChange = this.handleInputChange.bind(this);
    this.search = this.search.bind(this);
    this.download = this.download.bind(this);
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

  download(event) {
    event.preventDefault();
    this.props.downloadResults(
      this.state.skill,
      this.state.stage,
      this.state.year
    );
  }

  render() {
    if (this.props.results.length == 0) {
      return (
        <div>
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
          <button id="download" onClick={this.downloadResults}>
            Скачать
          </button>
          <NoResults mes={"Нет результатов"} />;
        </div>
      );
    } else {
      return (
        <div>
          <form onSubmit={this.searchResults}>
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
          <button id="download" onClick={this.downloadResults}>
            Скачать
          </button>
          {this.props.results.map((competition) => (
            <CompetitionResults competition={competition} />
          ))}
        </div>
      );
    }
  }
}
