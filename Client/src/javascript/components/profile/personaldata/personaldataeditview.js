import React from "react";

export default class PersonalDataEditView extends React.Component {
  constructor(props) {
    super(props);
    this.finish = this.finish.bind(this);
    this.save = this.save.bind(this);
    this.state = {
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

  finish() {
    this.props.finishEditData();
  }

  save(event) {
    event.preventDefault();
    this.props.saveData(
      this.state.surname,
      this.state.name,
      this.state.patronymic,
      this.state.birthday,
      this.state.mail,
      this.state.telephone,
      this.state.country,
      this.state.city,
      this.state.street,
      this.state.house
    );
    this.finish();
  }

  toDateFormat(sourceString) {
    return sourceString.slice(0, 10);
  }

  render() {
    return (
      <form class="personaldata" onSubmit={this.save}>
        <p>
          <label class="questionField" for="surname">
            Фамилия:
          </label>
          <input
            type="text"
            class="answerField"
            id="surname"
            name="surname"
            onChange={this.handleInputChange}
            maxLength="50"
            value={this.state.surname}
            required
          />
        </p>
        <p>
          <label class="questionField" for="name">
            Имя:
          </label>
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
        </p>
        <p>
          <label class="questionField" for="patronymic">
            Отчество:
          </label>
          <input
            type="text"
            class="answerField"
            id="patronymic"
            name="patronymic"
            onChange={this.handleInputChange}
            value={this.state.patronymic}
            maxLength="50"
          />
        </p>
        <p>
          <label class="questionField" for="birthday">
            Дата рождения:
          </label>
          <input
            type="date"
            class="answerField"
            id="birthday"
            name="birthday"
            onChange={this.handleInputChange}
            pattern="[0-3][0-9].[0-1][0-9].(1|2)(0|1|9)[0-9][0-9]"
            value={this.toDateFormat(this.state.birthday)}
          />
        </p>
        <p>
          <label class="questionField" for="mail">
            Почта:
          </label>
          <input
            type="email"
            class="answerField"
            id="mail"
            name="mail"
            onChange={this.handleInputChange}
            pattern=".*@[a-zA-Z_]+?\.[a-zA-Z_]{2,6}"
            value={this.state.mail}
          />
        </p>
        <p>
          <label class="questionField" for="telephone">
            Телефон (в формате +375xxxxxxxxx):
          </label>
          <input
            type="tel"
            class="answerField"
            id="telephone"
            name="telephone"
            onChange={this.handleInputChange}
            pattern="\+375[0-9]{9}"
            value={this.state.telephone}
          />
        </p>
        <p>
          <label class="questionField">Адрес:</label>
        </p>
        <p>
          <label class="questionField" for="country">
            Страна:
          </label>
          <input
            type="text"
            class="answerField"
            id="country"
            name="country"
            onChange={this.handleInputChange}
            maxLength="50"
            value={this.state.country}
          />
        </p>
        <p>
          <label class="questionField" for="city">
            Город:
          </label>
          <input
            type="text"
            class="answerField"
            id="city"
            name="city"
            onChange={this.handleInputChange}
            maxLength="50"
            value={this.state.city}
          />
        </p>
        <p>
          <label class="questionField" for="street">
            Улица:
          </label>
          <input
            type="text"
            class="answerField"
            id="street"
            name="street"
            onChange={this.handleInputChange}
            maxLength="50"
            value={this.state.street}
          />
        </p>
        <p>
          <label class="questionField" for="house">
            Дом:
          </label>
          <input
            type="text"
            class="answerField"
            id="house"
            name="house"
            onChange={this.handleInputChange}
            maxLength="50"
            value={this.state.house}
          />
        </p>
        <button type="submit">Сохранить</button>
        <button onClick={this.finish}>Вернуться</button>
      </form>
    );
  }
}
