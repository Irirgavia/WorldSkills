import React from "react";

export default class StageResults extends React.Component {
  render() {
    return (
      <div class="stage">
        <p class="stagetype">Этап: {this.props.stage.Type}</p>
        <table border="1">
          <tr>
            <th>Участник</th>
            <th>Балл</th>
          </tr>
          {this.props.stage.ResultRecords.map((resultRecord) => (
            <tr>
              <td>{resultRecord.Participant}</td>
              <td>{resultRecord.Mark}</td>
            </tr>
          ))}
        </table>
      </div>
    );
  }
}
