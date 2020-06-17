import React from "react";
import { connect } from "react-redux";
import { Redirect } from "react-router-dom";
import { getPersonalData } from "../../actions/actions.js";
import Error from "../../components/system/error.js";
import Loading from "../../components/system/loading.js";
import PersonalDataView from "../../components/profile/personaldata/personaldataview.js";

export class PersonalData extends React.Component {
  constructor(props) {
    super(props);
    this.editData = this.editData.bind(this);

    const { cookies } = props;
    this.state = {
      editFlag: false,
      userId: cookies.get("id") || "0",
      isSignedIn: cookies.get("isSignedIn") || false,
    };
  }

  componentDidMount() {
    this.props.getPersonalData(this.state.userId);
  }

  editData() {
    this.setState({ editFlag: true });
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
    } else
      return this.state.editFlag ? (
        <Redirect to={this.props.returnURL} />
      ) : (
        <PersonalDataView data={this.props.items} editData={this.editData} />
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
  };
};

export default connect(mapProps, mapDispatch)(PersonalData);
