import React from "react";
import { connect } from "react-redux";
import { Redirect } from "react-router-dom";
import { getPersonalData, savePersonalData } from "../../actions/actions.js";
import Error from "../../components/system/error.js";
import Loading from "../../components/system/loading.js";
import PersonalDataView from "../../components/profile/personaldata/personaldataview.js";
import PersonalDataEditView from "../../components/profile/personaldata/personaldataview.js";

export class PersonalData extends React.Component {
  constructor(props) {
    super(props);
    this.editData = this.editData.bind(this);
    this.finishEditData = this.finishEditData.bind(this);
    this.saveData = this.saveData.bind(this);
    this.state = { editFlag: false };
  }

  componentDidMount() {
    this.props.getPersonalData(this.props.userId);
  }

  editData() {
    this.setState({ editFlag: true });
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
      userId: this.props.userId,
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
    if (!this.props.isSignedIn) {
      return <Redirect to="/singin" />;
    } else if (this.props.error) {
      return <Error error={this.props.error.message} />;
    } else if (this.props.isFetching) {
      return <Loading />;
    } else if (this.state.editFlag) {
      return (
        <PersonalDataEditView
          data={this.props.items}
          finishEditData={this.finishEditData}
          saveData={this.saveData}
        />
      );
    } else {
      return (
        <PersonalDataView data={this.props.items} editData={this.editData} />
      );
    }
  }
}

let mapProps = (state, ownProps) => {
  return {
    cookies: ownProps.cookies,
    userId: ownProps.cookies.id,
    items: state.data,
    isFetching: state.isFetching,
    isSignedIn: ownProps.cookies.isSignedIn,
    error: state.error,
  };
};

let mapDispatch = (dispatch) => {
  return {
    getPersonalData: (userId) => dispatch(getPersonalData(userId)),
    savePersonalData: (data) => dispatch(savePersonalData(data)),
  };
};

export default connect(mapProps, mapDispatch)(PersonalData);
