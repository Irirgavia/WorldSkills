import React from "react";

export default class NotificationMessage extends React.Component {
  render() {
    return (
      <div id="notificationsmessage">
        <p>{this.props.message}</p>
      </div>
    );
  }
}
