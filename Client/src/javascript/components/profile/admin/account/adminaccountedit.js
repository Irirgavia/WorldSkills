import React from "react";

export default class AdminAccountEdit extends React.Component {
  constructor(props) {
    super(props);
    this.saveData = this.saveData.bind(this);
    this.state = {
      role: this.props.data.Role,
      surname: this.props.data.Surname,
      name: this.props.data.Name,
      patronymic: this.props.data.Patronymic,
      birthday: this.props.data.Birthday,
      mail: this.props.data.Mail,
      telephone: this.props.data.Telephone,
      country: this.props.data.Country,
      city: this.props.data.City,
      street: this.props.data.Street,
      house: this.props.data.House,
      apartment: this.props.data.Apartment,
    };

    this.handleInputChange = this.handleInputChange.bind(this);
  }

  handleInputChange(event) {
    const target = event.target;
    const value = target.value;
    const name = target.name;

    this.setState({
      [name]: value,
    });
  }

  saveData() {
    this.props.saveUser(
      this.props.data.Id,
      this.state.role,
      this.state.surname,
      this.state.name,
      this.state.patronymic,
      this.state.birthday,
      this.state.mail,
      this.state.telephone,
      this.state.country,
      this.state.city,
      this.state.street,
      this.state.house,
      this.state.apartment
    );
  }

  render() {
    return (
      <tr>
        <td>
          <select
            class="answerField"
            id="role"
            name="role"
            onChange={this.handleInputChange}
            maxLength="50"
            value={this.state.role}
          >
            <option value="participant">Участник</option>
            <option value="judge">Жюри</option>
            <option value="administrator">Администратор</option>
          </select>
        </td>
        <td>
          <input
            type="text"
            class="answerField"
            id="surname"
            name="surname"
            onChange={this.handleInputChange}
            maxLength="50"
            value={this.state.surname}
          />
        </td>
        <td>
          <input
            type="text"
            class="answerField"
            id="name"
            name="name"
            onChange={this.handleInputChange}
            maxLength="50"
            value={this.state.name}
            required
          />
        </td>
        <td>
          <input
            type="text"
            class="answerField"
            id="patronymic"
            name="patronymic"
            onChange={this.handleInputChange}
            value={this.state.patronymic}
            maxLength="50"
          />
        </td>
        <td>
          <input
            type="date"
            class="answerField"
            id="birthday"
            name="birthday"
            onChange={this.handleInputChange}
            pattern="[0-3][0-9].[0-1][0-9].(1|2)(0|1|9)[0-9][0-9]"
            value={this.state.birthday}
          />
        </td>
        <td>
          <input
            type="email"
            class="answerField"
            id="mail"
            name="mail"
            onChange={this.handleInputChange}
            pattern=".*@[a-zA-Z_]+?\.[a-zA-Z_]{2,6}"
            value={this.state.mail}
          />
        </td>
        <td>
          <input
            type="tel"
            class="answerField"
            id="telephone"
            name="telephone"
            onChange={this.handleInputChange}
            pattern="\+375[0-9]{9}"
            value={this.state.telephone}
          />
        </td>
        <td>
          <input
            type="text"
            class="answerField"
            id="country"
            name="country"
            onChange={this.handleInputChange}
            maxLength="50"
            value={this.state.country}
          />
        </td>
        <td>
          <input
            type="text"
            class="answerField"
            id="city"
            name="city"
            onChange={this.handleInputChange}
            maxLength="50"
            value={this.state.city}
          />
        </td>
        <td>
          <input
            type="text"
            class="answerField"
            id="street"
            name="street"
            onChange={this.handleInputChange}
            maxLength="50"
            value={this.state.street}
          />
        </td>
        <td>
          <input
            type="text"
            class="answerField"
            id="house"
            name="house"
            onChange={this.handleInputChange}
            maxLength="50"
            value={this.state.house}
          />
        </td>
        <td>
          <input
            type="text"
            class="answerField"
            id="apartment"
            name="apartment"
            onChange={this.handleInputChange}
            maxLength="10"
            value={this.state.apartment}
          />
        </td>
        <td>
          <button onClick={this.saveData}>Сохранить</button>
        </td>
      </tr>
    );
  }
}
