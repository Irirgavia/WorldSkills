import React from "react";
import { connect } from "react-redux";
import { Redirect } from "react-router-dom";
import {
  getAllUsers,
  savePersonalDataByAdmin,
} from "../../../actions/actions.js";
import Error from "../../../components/system/error.js";
import Loading from "../../../components/system/loading.js";
import AdminAccountView from "../../../components/profile/admin/account/adminaccountview.js";

export class AdminAccount extends React.Component {
  constructor(props) {
    super(props);
    this.saveData = this.saveData.bind(this);
  }

  componentDidMount() {
    this.props.getAllUsers(this.props.userId);
  }

  saveData(user) {
    this.props.savePersonalDataByAdmin(user);
  }

  render() {
    if (!this.props.isSignedIn || this.props.role != "administrator") {
      return <Redirect to="/singin" />;
    } else if (this.props.error) {
      return <Error error={this.props.error.message} />;
    } else if (this.props.isFetching) {
      return <Loading />;
    } else {
      return (
        <AdminAccountView users={this.props.items} saveData={this.saveData} />
      );
    }
  }
}

let mapProps = (state, ownProps) => {
  return {
    userId: ownProps.cookies.cookies.id,
    role: ownProps.cookies.cookies.role,
    items: state.data,
    isFetching: state.isFetching,
    isSignedIn: ownProps.cookies.cookies.isSignedIn,
    error: state.error,
  };
};

let mapDispatch = (dispatch) => {
  return {
    getAllUsers: (userId) => dispatch(getAllUsers(userId)),
    savePersonalDataByAdmin: (data) => dispatch(savePersonalDataByAdmin(data)),
  };
};

export default connect(mapProps, mapDispatch)(AdminAccount);
