import React from "react";
import { connect } from "react-redux";
import { Redirect } from "react-router-dom";
import { getPersonalData } from "../../../actions/actions.js";
import Error from "../../system/error.js";
import Loading from "../../system/loading.js";

export class PersonalData extends React.Component {
  constructor(props) {
    super(props);
    this.state = { changeFlag: false };
  }

  componentDidMount() {
    this.props.getPersonalData(this.props.userId);
  }

  changeData() {
    this.setState({ changeFlag: true });
  }

  render() {
    if (!this.props.isSignedIn) {
      return <Redirect to="/singin" />;
    } else if (this.props.error) {
      return <Error error={this.props.error.message} />;
    } else if (this.props.isFetching) {
      return <Loading />;
    } else if (this.state.changeFlag) {
      return (
        <div>
          <Redirect
            from="/judge/personaldata"
            to="/judge/personaldata/change"
          />
          <Redirect
            from="/participant/personaldata"
            to="/participant/personaldata/change"
          />
          <Redirect
            from="/trainer/personaldata"
            to="/trainer/personaldata/change"
          />
          <Redirect
            from="/administrator/personaldata"
            to="/administrator/personaldata/change"
          />
        </div>
      );
    } else {
      return (
        <div class="personaldata">
          <p>
            <label class="questionField">Фамилия:</label>
            <label class="answerField">{this.props.items.Surname}</label>
          </p>
          <p>
            <label class="questionField">Имя:</label>
            <label class="answerField">{this.props.items.Name}</label>
          </p>
          <p>
            <label class="questionField">Отчество:</label>
            <label class="answerField">{this.props.items.Patronymic}</label>
          </p>
          <p>
            <label class="questionField">Дата рождения:</label>
            <label class="answerField">{this.props.items.Birthday}</label>
          </p>
          <p>
            <label class="questionField">Почта:</label>
            <label class="answerField">{this.props.items.Mail}</label>
          </p>
          <p>
            <label class="questionField">Телефон:</label>
            <label class="answerField">{this.props.items.Telephone}</label>
          </p>
          <p>
            <label class="questionField">Адрес:</label>
          </p>
          <p>
            <label class="questionField">Страна:</label>
            <label class="answerField">{this.props.items.Country}</label>
          </p>
          <p>
            <label class="questionField">Город:</label>
            <label class="answerField">{this.props.items.City}</label>
          </p>
          <p>
            <label class="questionField">Улица:</label>
            <label class="answerField">{this.props.items.Street}</label>
          </p>
          <p>
            <label class="questionField">Дом:</label>
            <label class="answerField">{this.props.items.House}</label>
          </p>
          <button onClick={this.changeData.bind(this)}>Изменить</button>
        </div>
      );
    }
  }
}

let mapProps = (state) => {
  return {
    userId: state.user.id,
    items: state.data,
    isFetching: state.isFetching,
    isSignedIn: state.isSignedIn,
    error: state.error,
  };
};

let mapDispatch = (dispatch) => {
  return {
    getPersonalData: (userId) => dispatch(getPersonalData(userId)),
  };
};

export default connect(mapProps, mapDispatch)(PersonalData);
