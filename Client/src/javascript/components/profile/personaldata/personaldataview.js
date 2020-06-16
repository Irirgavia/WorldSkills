import React from "react";

export default class PersonalDataView extends React.Component {
  constructor(props) {
    super(props);
    this.edit = this.edit.bind(this);
  }

  edit() {
    this.props.editData();
  }

  render() {
    return (
      <div class="personaldata">
        <p>
          <label class="questionField">Фамилия:</label>
          <label class="answerField">{this.props.data.Surname}</label>
        </p>
        <p>
          <label class="questionField">Имя:</label>
          <label class="answerField">{this.props.data.Name}</label>
        </p>
        <p>
          <label class="questionField">Отчество:</label>
          <label class="answerField">{this.props.data.Patronymic}</label>
        </p>
        <p>
          <label class="questionField">Дата рождения:</label>
          <label class="answerField">{this.props.data.Birthday}</label>
        </p>
        <p>
          <label class="questionField">Почта:</label>
          <label class="answerField">{this.props.data.Mail}</label>
        </p>
        <p>
          <label class="questionField">Телефон:</label>
          <label class="answerField">{this.props.data.Telephone}</label>
        </p>
        <p>
          <label class="questionField">Адрес:</label>
        </p>
        <p>
          <label class="questionField">Страна:</label>
          <label class="answerField">{this.props.data.Country}</label>
        </p>
        <p>
          <label class="questionField">Город:</label>
          <label class="answerField">{this.props.data.City}</label>
        </p>
        <p>
          <label class="questionField">Улица:</label>
          <label class="answerField">{this.props.data.Street}</label>
        </p>
        <p>
          <label class="questionField">Дом:</label>
          <label class="answerField">{this.props.data.House}</label>
        </p>
        <button onClick={this.edit}>Изменить</button>
      </div>
    );
  }
}
