import React from 'react';
import { connect } from 'react-redux';
import { getResultsByTrainer } from '../../../actions/actions.js';
import { Error } from '../../system/error.js';
import { Loading } from '../../system/loading.js';

export class TrainerResults extends React.Component {
    constructor(props) {
      super(props);
    }
  
    componentDidMount() {
      this.props.getResultsByTrainer(this.props.trainerId);
    }
  
    render() {
      if (this.props.error) {
        return <Error error={this.props.error.message} />;
    } else if (this.props.isFetching) {
        return <Loading />;
    } else {
      return (
          <table border="1">
            <tr>
              <th>Профессия</th>
              <th>Этап</th>
              <th>Дата</th>
              <th>Участник</th>
              <th>Баллы</th>
            </tr>
            {
            this.props.items.map(item => (
              <tr>
                <td>{item.Skill}</td>
                <td>{item.Stage}</td>
                <td>{item.Date}</td>
                <td>{item.Participant}</td>
                <td>{item.Marks}</td>
              </tr>
            ))}
          </table>
      );
    }
  }
}

let mapProps = (state) => {
  return {
    trainerId: state.user.id,
      items: state.data,
      isFetching: state.isFetching,
      error: state.error
  }
}

let mapDispatch = (dispatch) => {
  return {
    getResultsByTrainer: (trainerId) => dispatch(getResultsByTrainer(trainerId))
  }
}

export default connect(mapProps, mapDispatch)(TrainerResults)