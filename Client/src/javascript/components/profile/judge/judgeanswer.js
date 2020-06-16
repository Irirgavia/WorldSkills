import React from "react";

export default class JudgeAnswer extends React.Component {
  constructor(props) {
    super(props);
    this.send = this.send.bind(this);
    this.state = {
      mark: "",
    };

    this.handleInputChange = this.handleInputChange.bind(this);
  }

  handleInputChange(event) {
    const target = event.target;
    const value = target.value;

    this.setState({
      mark: value,
    });
  }

  send() {
    this.props.sendMark(this.props.answer.id, this.state.mark);
  }

  render() {
    return (
      <tr class="answer judge">
        <td>
          <a href={this.props.answer.Link}>Ответ</a>
        </td>
        <td>
          <input
            type="number"
            class="mark"
            min="0"
            onChange={this.handleInputChange}
          />
        </td>
        <td>
          <button class={"markButton"} onClick={this.send}>
            Отправить
          </button>
        </td>
      </tr>
    );
  }
}
