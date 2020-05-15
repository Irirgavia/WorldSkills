import React from 'react';
import ReactDOM from 'react-dom';
import { connect } from 'react-redux';
import { getResults } from '../../actions/actions.jsx'

class ResultsSearch extends React.Component {

    componentDidMount() {
        this.props.getPosts(0);
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
        {this.props.posts.records.map(item => (
          <tr>
            <td>{item.date}</td>
            <td>{item.winner}</td>
            <td>{item.marks}</td>
            <td>{item.skill}</td>
            <td>{item.stage}</td>
          </tr>
          ))}
        </table>
    };
};

let mapProps = (state) => {
    return {
        posts: state.data,
        error: state.error
    }
}

let mapDispatch = (dispatch) => {
    return {
        getResults: (skill, stage, year) => dispatch(getResults(skill, stage, year))
    }
}

export default connect(mapProps, mapDispatch)(ResultsSearch) 
