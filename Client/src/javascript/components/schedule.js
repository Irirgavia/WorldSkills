import React from 'react';
import { connect } from 'react-redux';
import { getSchedule } from '../actions/actions.js'

export class Schedule extends React.Component {
    constructor(props) {
      super(props);
    }

    componentDidMount() {
      this.props.getSchedule();
    }
        
    render() {
        if (this.props.error) {
            return <div>Ошибка: {this.props.error.message}</div>;
        } else if (this.props.isFetching) {
            return <div>Загрузка...</div>;
        } else {
            return (
                <div>
                  {this.props.items.map((item) =>
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

    let mapProps = (state) => {
      return {
          items: state.data,
          isFetching: state.isFetching,
          error: state.error
      }
  }
  
  let mapDispatch = (dispatch) => {
      return {
        getSchedule: () => dispatch(getSchedule())
      }
  }
  
  export default connect(mapProps, mapDispatch)(Schedule)