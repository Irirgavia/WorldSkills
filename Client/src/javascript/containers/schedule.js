import React from "react";
import { connect } from "react-redux";
import { getSchedule } from "../actions/actions.js";
import Error from "../components/system/error.js";
import Loading from "../components/system/loading.js";
import NoResults from "../components/system/noresults.js";
import CompetitionSchedule from "../components/schedule/competitionschedule.js";

export class Schedule extends React.Component {
  constructor(props) {
    super(props);
  }

  componentDidMount() {
    this.props.getSchedule();
  }

  render() {
    if (this.props.error) {
      return <Error error={this.props.error.message} />;
    } else if (this.props.isFetching) {
      return <Loading />;
    } else if (this.props.items.length == 0) {
      return <NoResults mes={"Нет актуальных событий"} />;
    } else {
      return (
        <div>
          {this.props.items.map((item) => (
            <CompetitionSchedule competition={item} />
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
    error: state.error,
  };
};

let mapDispatch = (dispatch) => {
  return {
    getSchedule: () => dispatch(getSchedule()),
  };
};

export default connect(mapProps, mapDispatch)(Schedule);

/*<div>
          {this.props.items.map((item) => (
            <div class="competition">
              <p class="competitiondata">
                Профессия: {item.Skill} Время проведения: {item.DateOfBegin}-
                {item.DateOfEnd}
              </p>
              {item.Stages.map((stage) => (
                <div class="stage">
                  <p class="stagetype">Этап: {stage.Type}</p>
                  <table class="tasks" border="1">
                    <thead>
                      <tr>
                        <th>Начало выполнения задания</th>
                        <th>Конец выполнения задания</th>
                        <th>Адреса</th>
                      </tr>
                    </thead>
                    <tbody>
                      {stage.Tasks.map((task) => (
                        <tr class={"task " + task.IsActual}>
                          <td>{task.TaskDateOfBegin}</td>
                          <td>{task.TaskDateOfEnd}</td>
                          <td>{task.Addresses}</td>
                        </tr>
                      ))}
                    </tbody>
                  </table>
                </div>
              ))}
            </div>
          ))}
        </div>*/
