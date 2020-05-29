import React from 'react';
import { connect } from 'react-redux';
import { getResultsByYear } from '../../actions/actions.js';
import { Error } from '../system/error.js'
import { Loading } from '../system/loading.js';


export class ResultsSearch extends React.Component {
  constructor(props) {
    super(props);
  }

  componentDidMount() {
    var params = new URLSearchParams(this.props.location.search);
    var skill = params.get("skill");
    var stage = params.get("stage");
    var year = params.get("year");
    this.props.getResultsByYear(skill, stage, year);
  }
      
  render() {
    console.log(this.props.isFetching);
      if (this.props.error) {
          return <Error error={this.props.error.message} />;
      } else if (this.props.isFetching) {
          return <Loading />;
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
                <th>Участник</th>
                <th>Баллы</th>
              </tr>
              {
              this.props.items.map(item => (
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

  let mapProps = (state) => {
    return {
        items: state.data,
        isFetching: state.isFetching,
        error: state.error
    }
}

let mapDispatch = (dispatch) => {
    return {
      getResultsByYear: (skill, stage, year) => dispatch(getResultsByYear(skill, stage, year))
    }
}

export default connect(mapProps, mapDispatch)(ResultsSearch)