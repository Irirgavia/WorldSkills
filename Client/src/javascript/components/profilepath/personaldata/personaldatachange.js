import React from "react";
import { connect } from "react-redux";
import { savePersonalData } from "../../../actions/actions.js";
import Error from "../../system/error.js";
import Loading from "../../system/loading.js";

export class PersonalDataChange extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      finishEditingFlag: false,
      surname: this.props.items.Surname,
      name: this.props.items.Name,
      patronymic: this.props.items.Patronymic,
      birthday: this.props.items.Birthday,
      mail: this.props.items.Mail,
      telephone: this.props.items.Telephone,
      country: this.props.items.Country,
      city: this.props.items.City,
      street: this.props.items.Street,
      house: this.props.items.House,
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

  save(event) {
    event.preventDefault();
    var data = {
      userId: this.props.userId,
      surname: this.state.surname,
      name: this.state.name,
      patronymic: this.state.patronymic,
      birthday: this.state.birthday,
      mail: this.state.mail,
      telephone: this.state.telephone,
      addressId: this.props.addressId,
      country: this.state.country,
      city: this.state.city,
      street: this.state.street,
      house: this.state.house,
    };
    this.props.savePersonalData(data);
  }

  finishEditing() {
    this.setState({ finishEditingFlag: true });
  }

  render() {
    if (!this.props.isSignedIn) {
      return <Redirect to="/singin" />;
    } else if (this.props.error) {
      return <Error error={this.props.error.message} />;
    } else if (this.props.isFetching) {
      return <Loading />;
    } else if (this.state.finishEditingFlag) {
      return (
        <div>
          <Redirect
            from="/judge/personaldata/change"
            to="/judge/personaldata"
          />
          <Redirect
            from="/participant/personaldata/change"
            to="/participant/personaldata"
          />
          <Redirect
            from="/trainer/personaldata/change"
            to="/trainer/personaldata"
          />
        </div>
      );
    } else {
      return (
        <form class="personaldata" onSubmit={this.save.bind(this)}>
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
              value={this.state.birthday}
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
          <button onClick={this.finishEditing.bind(this)}>Вернуться</button>
        </form>
      );
    }
  }
}

let mapProps = (state) => {
  return {
    items: state.data,
    isSignedIn: state.isSignedIn,
    isFetching: state.isFetching,
    error: state.error,
  };
};

let mapDispatch = (dispatch) => {
  return {
    savePersonalData: (data) => dispatch(savePersonalData(data)),
  };
};

export default connect(mapProps, mapDispatch)(PersonalDataChange);
