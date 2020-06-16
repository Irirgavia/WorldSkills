import React from "react";

export default class ParticipantTask extends React.Component {
  constructor(props) {
    super(props);
    this.send = this.send.bind(this);
    this.state = {
      answer: "",
    };

    this.handleInputChange = this.handleInputChange.bind(this);
  }

  handleInputChange(event) {
    const target = event.target;
    const value = target.value;

    this.setState({
      answer: value,
    });
  }

  send() {
    this.props.sendAnswer(this.props.task.id, this.state.answer);
  }

  render() {
    if (this.props.task.IsActual) {
      return (
        <tr class={"task true"}>
          <td>{task.taskDateOfBegin}</td>
          <td>{task.taskDateOfEnd}</td>
          <td>
            <a href={task.description}>Задание</a>
          </td>
          <td>
            <input
              type="url"
              class={"answer"}
              onChange={this.handleInputChange}
            />
          </td>
          <td>
            <button class={"answerButton"} onClick={this.send}>
              Отправить
            </button>
          </td>
        </tr>
      );
    } else {
      return (
        <tr class={"task false"}>
          <td>{task.taskDateOfBegin}</td>
          <td>{task.taskDateOfEnd}</td>
          <td>
            <a href={task.description}>Задание</a>
          </td>
          <td>Ответ дан.</td>
        </tr>
      );
    }
  }
}
