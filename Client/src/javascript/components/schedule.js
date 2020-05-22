import React from 'react';

export default class Schedule extends React.Component {
    constructor(props) {
      super(props);
      this.state = {
        error: null,
        isLoaded: false,
        items: []
      };
    }

    componentDidMount(year) {
      fetch("http://localhost:49263/api/schedule")
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
            return (
                <div>
                  {items.map((item) =>
                  (
                    <div class="competition">
                      <p class="competitiondata">{item.Skill} {item.DateOfBegin}-{item.DateOfEnd}</p>
                      {item.Stages.map((stage) =>
                      (
                        <table class="stage" border="1">
                          <tr>
                            <td>{stage.Type}</td>
                            <td>
                              <table class="tasks" border="1">
                                {stage.Tasks.map((task) =>
                                (
                                  <tr class={"task " + task.IsActual}>
                                    <td>{task.TaskDateOfBegin}</td>
                                    <td>{task.TaskDateOfEnd}</td>
                                    <td>{task.Addresses}</td>
                                  </tr>
                                ))}
                              </table>
                            </td>
                          </tr>
                        </table>
                      ))}
                    </div>
                  ))}
                </div>
            );
        }
      }
    }






/*import React from 'react';
import { connect } from 'react-redux';
import { getSchedule } from '../actions/actions'

export default class Schedule extends React.Component {
  /*componentDidMount() {
    this.props.getSchedule();
                  <table border="1">
                    <caption>Результаты</caption>
                    <tr>
                        <th>Профессия</th>
                        <th>Этап</th>
                        <th>Дата начала</th>
                        <th>Дата конца</th>
                        <th>Адрес</th>
                    </tr>
                    {
                    items.map((item) => (
                        <tr>
                            <td>{item.Skill}</td>
                            <td>{item.Stage}</td>
                            <td>{item.DateOfBegin}</td>
                            <td>{item.DateOfEnd}</td>
                            <td>{item.Address}</td>
                        </tr>
                    ))}
                </table>
}*/
/*
render() {
  return <div>
    <h1>hi</h1>
    <table border = "1">
    <caption>Расписание</caption>
    <tr>
      <th>Профессия</th>
      <th>Этап</th>
      <th>Дата начала</th>
      <th>Дата конца</th>
      <th>Адрес</th>
    </tr>
    {
    this.props.schedule.map(item => (
    <tr>
      <td>{item.skill}</td>
      <td>{item.stage}</td>
      <td>{item.databegin}</td>
      <td>{item.dataend}</td>
      <td>{item.address}</td>
    </tr>
    ))}
    </table>;
    </div>
  }
}*/

/*let mapProps = (state) => {
  return {
      schedule: state.data,
      error: state.error
  }
}

let mapDispatch = (dispatch) => {
  return {
      getSchedule: () => dispatch(getSchedule())
  }
}

export default connect(mapProps, mapDispatch)(Schedule) */