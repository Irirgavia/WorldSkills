import React from "react";

export default class AdminAccount extends React.Component {
  constructor(props) {
    super(props);
    this.select = this.select.bind(this);
  }

  select() {
    this.props.editUser(this.props.user);
  }

  render() {
    return (
      <tr onDoubleClick={this.select}>
        <td>{this.props.user.Role}</td>
        <td>{this.props.user.Surname}</td>
        <td>{this.props.user.Name}</td>
        <td>{this.props.user.Patronymic}</td>
        <td>{this.props.user.Birthday}</td>
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
