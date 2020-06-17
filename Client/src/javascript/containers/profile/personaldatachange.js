import React from "react";
import { connect } from "react-redux";
import { Redirect } from "react-router-dom";
import { getPersonalData, savePersonalData } from "../../actions/actions.js";
import Error from "../../components/system/error.js";
import Loading from "../../components/system/loading.js";
import PersonalDataEditView from "../../components/profile/personaldata/personaldataeditview.js";

export class PersonalDataChange extends React.Component {
  constructor(props) {
    super(props);
    this.finishEditData = this.finishEditData.bind(this);
    this.saveData = this.saveData.bind(this);

    const { cookies } = props;
    this.state = {
      editFlag: true,
      userId: cookies.get("id") || "0",
      isSignedIn: cookies.get("isSignedIn") || false,
    };
  }

  finishEditData() {
    this.setState({ editFlag: false });
  }

  saveData(
    surname,
    name,
    patronymic,
    birthday,
    mail,
    telephone,
    country,
    city,
    street,
    house
  ) {
    var data = {
      userId: this.state.userId,
      surname: surname,
      name: name,
      patronymic: patronymic,
      birthday: birthday,
      mail: mail,
      telephone: telephone,
      country: country,
      city: city,
      street: street,
      house: house,
    };
    this.props.savePersonalData(data);
  }

  render() {
    console.log(this.state.editFlag);
    if (!this.state.isSignedIn) {
      console.log("Redirect");
      return <Redirect to="/singin" />;
    } else if (this.props.error) {
      console.log("Error");
      return <Error error={this.props.error.message} />;
    } else if (this.props.isFetching) {
      console.log("Loading");
      return <Loading />;
    } else console.log(this.props.items);
    return this.state.editFlag ? (
      <PersonalDataEditView
        data={this.props.items}
        finishEditData={this.finishEditData}
        saveData={this.saveData}
      />
    ) : (
      <Redirect to={this.props.returnURL} />
    );
  }
}

let mapProps = (state, ownProps) => {
  return {
    cookies: ownProps.cookies,
    items: state.data,
    isFetching: state.isFetching,
    error: state.error,
  };
};

let mapDispatch = (dispatch) => {
  return {
    getPersonalData: (userId) => dispatch(getPersonalData(userId)),
    savePersonalData: (data) => dispatch(savePersonalData(data)),
  };
};

export default connect(mapProps, mapDispatch)(PersonalDataChange);
