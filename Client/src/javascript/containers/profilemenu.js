import React from "react";
import AdminProfileMenu from "../components/profilemenu/adminprofilemenu.js";
import ParticipantProfileMenu from "../components/profilemenu/participantprofilemenu.js";
import GuestProfileMenu from "../components/profilemenu/guestprofilemenu.js";
import JudgeProfileMenu from "../components/profilemenu/judgeprofilemenu.js";

export default class ProfileMenu extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    console.log("name:" + this.props.login);
    console.log("isSignedIn:" + this.props.isSignedIn);
    if (!this.props.isSignedIn) {
      return <GuestProfileMenu />;
    } else if (
      this.props.role == "participant" ||
      this.props.role == "Participant"
    ) {
      return (
        <ParticipantProfileMenu
          login={this.props.login}
          unreadNotificationAmount={this.props.unreadNotificationAmount}
        />
      );
    } else if (this.props.role == "judge" || this.props.role == "Judge") {
      return (
        <JudgeProfileMenu
          login={this.props.login}
          unreadNotificationAmount={this.props.unreadNotificationAmount}
        />
      );
    } else if (
      this.props.role == "administrator" ||
      this.props.role == "Administrator"
    ) {
      return (
        <AdminProfileMenu
          login={this.props.login}
          unreadNotificationAmount={this.props.unreadNotificationAmount}
        />
      );
    }
  }
}
