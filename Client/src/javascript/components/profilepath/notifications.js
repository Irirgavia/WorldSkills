import React from "react";
import { Redirect } from "react-router-dom";
import { connect } from "react-redux";
import { getNotifications, readNotification } from "../../actions/actions.js";
import Error from "../system/error.js";
import Loading from "../system/loading.js";
import NoResults from "../system/noresults.js";

export class Notifications extends React.Component {
  constructor(props) {
    super(props);
    this.selected = this.selected.bind(this);
    this.isReadMessage = this.isReadMessage.bind(this);
    this.state = {
      selectedIndex: -1,
      mes: "",
    };
  }

  componentDidMount() {
    this.props.getNotifications(this.props.userId);
  }

  selected(event) {
    const target = event.target;
    const id = target.key;
    var notification = this.props.items.find(this.findElementInArrayById, id);
    var message = notification.Body;
    this.setState({
      selectedIndex: key,
      mes: message,
    });
  }

  findElementInArrayById(element, index, array) {
    return element.Id == this;
  }

  isReadMessage(event) {
    const target = event.target;
    const id = target.key;
    var notification = this.props.items.find(this.findElementInArrayById, id);
    if (!notification.IsRead) {
      this.props.readNotification(notification.Id, this.props.userId);
      notification.IsRead = true;
    }
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
        <div>
          <div id="notificationspreview">
            {this.props.items.map((item) => (
              <p
                class={"notificationsubject" + item.IsRead}
                onClick={this.selected}
                key={item.Id}
              >
                {item.Subject}
              </p>
            ))}
          </div>
          <div id="notificationsmessage">
            <p key={this.state.selectedIndex} onChange={this.isReadMessage}>
              {this.props.items[this.state.selectedIndex]}
            </p>
          </div>
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
    getNotifications: (userId) => dispatch(getNotifications(userId)),
    readNotification: (notificationId, userId) =>
      dispatch(readNotification(notificationId, userId)),
  };
};

export default connect(mapProps, mapDispatch)(Notifications);
