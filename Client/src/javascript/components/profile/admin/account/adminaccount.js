import React from "react";

export default class AdminAccount extends React.Component {
  constructor(props) {
    super(props);
    this.select = this.select.bind(this);
  }

  select() {
    this.props.editUser(this.props.user);
  }

  toDateFormat(sourceString) {
    var stringDate =
      sourceString.slice(8, 10) +
      "." +
      sourceString.slice(5, 7) +
      "." +
      sourceString.slice(0, 4);
    return stringDate;
  }

  render() {
    return (
      <tr onDoubleClick={this.select}>
        <td>{this.props.user.Role}</td>
        <td>{this.props.user.Surname}</td>
        <td>{this.props.user.Name}</td>
        <td>{this.props.user.Patronymic}</td>
        <td>{this.toDateFormat(this.props.user.Birthday)}</td>
        <td>{this.props.user.Mail}</td>
        <td>{this.props.user.Telephone}</td>
        <td>{this.props.user.Country}</td>
        <td>{this.props.user.City}</td>
        <td>{this.props.user.Street}</td>
        <td>{this.props.user.House}</td>
        <td>{this.props.user.Apartment}</td>
      </tr>
    );
  }
}
