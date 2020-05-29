import React from 'react';
import { connect } from 'react-redux';
import { savePersonalData } from '../../../actions/actions.js';
import * as systemComponents from '../../system'

export class PersonalDataChange extends React.Component {
    constructor(props) {
        super(props);
        this.surnameInput = React.createRef();
        this.nameInput = React.createRef();
        this.patronymicInput = React.createRef();
        this.birthdayInput = React.createRef();
        this.mailInput = React.createRef();
        this.telephoneInput = React.createRef();
        this.countryInput = React.createRef();
        this.cityInput = React.createRef();
        this.streetInput = React.createRef();
        this.houseInput = React.createRef();
        this.state = { finishEditingFlag: false };
    }

    save(){
        var data = {
            userId: this.props.userId,
            surname: this.surnameInput.value,
            name: this.nameInput.value,
            patronymic: this.patronymicInput.value,
            birthday: this.birthdayInput.value,
            mail: this.mailInput.value,
            telephone: this.telephoneInput.value,
            addressId: this.props.addressId,
            country: this.countryInput.value,
            city: this.cityInput.value,
            street: this.streetInput.value,
            house: this.houseInput.value,
        };
        this.props.savePersonalData(data);
    }

    finishEditing(){
        this.setState({finishEditingFlag: true});
    }

    render() {
        if (this.props.error) {
            return <systemComponents.Error error={this.props.error.message} />;
        } else if (this.props.isFetching) {
            return <systemComponents.Loading />;
        } else if(this.state.finishEditingFlag){
            return <div>
                Сохранено.
                <Redirect from="/judge/personaldata/change" to="/judge/personaldata" />
                <Redirect from="/participant/personaldata/change" to="/participant/personaldata" />
                <Redirect from="/trainer/personaldata/change" to="/trainer/personaldata" />
            </div>;
        }else {
            return <form class = "personaldata" action = { this.save.bind(this) }>
                    <p>
                        <label class = "questionField" for="surname">Фамилия:</label>
                        <input type = "text" class = "answerField" id="surname" name="surname" ref={this.surnameInput} maxLength="50" required>{this.props.items.Surname}</input>
                    </p>
                    <p>
                        <label class = "questionField" for="name">Имя:</label>
                        <input type = "text" class = "answerField" id="name" name="name" ref={this.nameInput} maxLength="50" required>{this.props.items.Name}</input>
                    </p>
                    <p>
                        <label class = "questionField" for="patronymic">Отчество:</label>
                        <input type = "text" class = "answerField" id="patronymic" name="patronymic" ref={this.patronymicInput} maxLength="50">{this.props.items.Patronymic}</input>
                    </p>
                    <p>
                        <label class = "questionField" for="birthday">Дата рождения:</label>
                        <input type = "date" class = "answerField" id="birthday" name="birthday" ref={this.birthdayInput} pattern="[0-3][0-9].[0-1][0-9].(1|2)(0|1|9)[0-9][0-9]">{this.props.items.Birthday}</input>
                    </p>
                    <p>
                        <label class = "questionField" for="mail">Почта:</label>
                        <input type = "email" class = "answerField" id="mail" name="mail" ref={this.mailInput} pattern=".*@[a-zA-Z_]+?\.[a-zA-Z_]{2,6}">{this.props.items.Mail}</input>
                    </p>
                    <p>
                        <label class = "questionField" for="telephone">Телефон (в формате +375xxxxxxxxx):</label>
                        <input type = "tel" class = "answerField" id="telephone" name="telephone" ref={this.telephoneInput} pattern="\+375[0-9]{9}">{this.props.items.Telephone}</input>
                    </p>
                    <p>
                        <label class = "questionField">Адрес:</label>
                    </p>
                    <p>
                        <label class = "questionField" for = "country">Страна:</label>
                        <input type = "text" class = "answerField" id="country" name="country" ref={this.countryInput} maxLength="50">{this.props.items.Country}</input>
                    </p>
                    <p>
                        <label class = "questionField" for = "city">Город:</label>
                        <input type = "text" class = "answerField" id="city" name="city" ref={this.cityInput} maxLength="50">{this.props.items.City}</input>
                    </p>
                    <p>
                        <label class = "questionField" for="street">Улица:</label>
                        <input type = "text" class = "answerField" id="street" name="street" ref={this.streetInput} maxLength="50">{this.props.items.Street}</input>
                    </p>
                    <p>
                        <label class = "questionField" for="house">Дом:</label>
                        <input type = "text" class = "answerField" id="house" name="house" ref={this.houseInput} maxLength="50">{this.props.items.House}</input>
                    </p>
                    <button type="submit">Сохранить</button>
                    <button onClick={this.finishEditing.bind(this)}>Вернуться</button>
                </form>;
        }
    }
}

    let mapProps = (state) => {
      return {
          items: state.data,
          isFetching: state.isFetching,
          isSignedIn: state.isSignedIn,
          error: state.error
      }
  }
  
  let mapDispatch = (dispatch) => {
      return {
        savePersonalData: (data) => dispatch(savePersonalData(data))
      }
  }
  
  export default connect(mapProps, mapDispatch)(PersonalDataChange)