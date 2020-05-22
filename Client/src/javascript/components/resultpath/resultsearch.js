import React from 'react';
import { connect } from 'react-redux';
import { getResults } from '../../actions/actions.js'


export default class ResultsSearch extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      error: null,
      isLoaded: false,
      items: []
    };
  }

  componentDidMount() {
    var params = new URLSearchParams(this.props.location.search);
    var skill = params.get("skill");
    var stage = params.get("stage");
    var year = params.get("year");
    fetch("http://localhost:49263/api/results?skill=" + skill + '&stage=' + stage + '&year=' + year)
      .then(res => res.json())
      .then(
        (result) => {
          this.setState({
            isLoaded: true,
            items: result
          });
        },
        (error) => {
          this.setState({
            isLoaded: true,
            error
          });
        }
      )
  }
      
  render() {
      const { error, isLoaded, items } = this.state;
      if (error) {
          return <div>Ошибка: {error.message}</div>;
      } else if (!isLoaded) {
          return <div>Загрузка...</div>;
      } else {
        var params = new URLSearchParams(this.props.location.search);
        var skill = params.get("skill");
        var stage = params.get("stage");
        var year = params.get("year");
          return (
          <div>
            <form action="/results/search" method="get">
              <label for = "skill">Профессия: </label>
              <input  type = "text" id = "skill" name = "skill" required />
              <label for = "stage">Этап: </label>
              <input  type = "text" id = "stage" name = "stage" required />
              <label for = "year">Год: </label>
              <input  type = "text" id = "year" name = "year" required />
              <button id = "search" type="submit">Искать</button>
              <button id = "download" onClick = "">Скачать</button>
            </form>
            <table border="1">
              <caption>Результаты в соревновании {skill}, этап {stage} за год {year}</caption>
              <tr>
                <th>Дата</th>
                <th>Победитель</th>
                <th>Баллы</th>
              </tr>
              {
              items.map(item => (
                <tr>
                  <td>{item.Date}</td>
                  <td>{item.Participant}</td>
                  <td>{item.Marks}</td>
                </tr>
              ))}
            </table>
          </div>
        );
      }
    }
  }

/*class ResultsSearch extends React.Component {

    componentDidMount() {
        this.props.getResults(0);
    }

    render() {
      <table border="1">
        <caption>Результаты</caption>
        <tr>
          <th>Дата</th>
          <th>Победитель</th>
          <th>Баллы</th>
          <th>Профессия</th>
          <th>Этап</th>
        </tr>
        {this.props.competitionResults.records.map(item => (
          <tr>
            <td>{item.Date}</td>
            <td>{item.Participant}</td>
            <td>{item.Marks}</td>
          </tr>
          ))}
        </table>
    };
};

let mapProps = (state) => {
    return {
        competitionResults: state.data,
        error: state.error
    }
}

let mapDispatch = (dispatch) => {
    return {
        getResults: (skill, stage, year) => dispatch(getResults(skill, stage, year))
    }
}

export default connect(mapProps, mapDispatch)(ResultsSearch) */


/*
            <td>{item.Skill}</td>
            <td>{item.Stage}</td>*/