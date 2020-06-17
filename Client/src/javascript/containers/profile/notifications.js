import React from "react";
import { Redirect } from "react-router-dom";
import { connect } from "react-redux";
import { getNotifications, readNotification } from "../../actions/actions.js";
import Error from "../../components/system/error.js";
import Loading from "../../components/system/loading.js";
import NoResults from "../../components/system/noresults.js";
import NotificationsView from "../../components/profile/notifications/notificationsview.js";

export class Notifications extends React.Component {
  constructor(props) {
    super(props);
    this.readNotificationMessage = this.readNotificationMessage.bind(this);
  }

  componentDidMount() {
    this.props.getNotifications(this.props.userId);
  }

  readNotificationMessage(notificationId) {
    this.props.readNotification(notificationId, this.props.userId);
  }

  render() {
    if (!this.props.isSignedIn) {
      return <Redirect to="/singin" />;
    } else if (this.props.error) {
      return <Error error={this.props.error.message} />;
    } else if (this.props.isFetching) {
      return <Loading />;
    } else if (this.props.items.length == 0) {
      return <NoResults mes={"Нет уведомлений"} />;
    } else {
      console.log("form!");
      return (
        <NotificationsView
          items={this.props.items}
          readNotificationMessage={this.readNotificationMessage}
        />
      );
    }
  }
}

let mapProps = (state, ownProps) => {
  return {
    userId: ownProps.cookies.id,
    items: state.data,
    isFetching: state.isFetching,
    isSignedIn: ownProps.cookies.isSignedIn,
    error: state.error,
  };
};

let mapDispatch = (dispatch) => {
  return {
    getNotifications: (userId) => dispatch(getNotifications(userId)),
    readNotification: (notificationId, userId) =>
      dispatch(readNotification(notificationId, userId)),
  };
};

export default connect(mapProps, mapDispatch)(Notifications);
