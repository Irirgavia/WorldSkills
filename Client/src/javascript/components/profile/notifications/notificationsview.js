import React from "react";
import NotificationPreview from "./notificationpreview.js";
import NotificationMessage from "./notificationmessage.js";

export default class NotificationsView extends React.Component {
  constructor(props) {
    super(props);
    this.selectNotification = this.selectNotification.bind(this, notification);
    this.state = {
      mes: "",
    };
  }

  selectNotification(notification) {
    var message = notification.Body;
    this.setState({
      mes: message,
    });
    if (!notification.IsRead) {
      this.props.readNotificationMessage(notification.Id);
      notification.IsRead = true;
    }
  }

  render() {
    return (
      <div>
        <div id="notificationspreview">
          {this.props.items.map((item) => (
            <NotificationPreview
              notification={item}
              onClick={this.selectNotification}
            />
          ))}
        </div>
        <div id="notificationsmessage">
          <NotificationMessage message={this.state.mes} />
        </div>
      </div>
    );
  }
}
