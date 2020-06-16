import React from "react";

export default class NotificationPreview extends React.Component {
  render() {
    return (
      <p
        class={"notificationsubject" + this.props.notification.IsRead}
        onClick={this.props.selectNotification}
        key={this.props.notification.Id}
      >
        {this.props.notification.Subject}
      </p>
    );
  }
}
