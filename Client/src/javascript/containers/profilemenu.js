import React from "react";
import { connect } from "react-redux";
import AdminProfileMenu from "../components/profilemenu/adminprofilemenu.js";
import ParticipantProfileMenu from "../components/profilemenu/participantprofilemenu.js";
import GuestProfileMenu from "../components/profilemenu/guestprofilemenu.js";
import JudgeProfileMenu from "../components/profilemenu/judgeprofilemenu.js";

export class ProfileMenu extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    console.log("name:" + this.props.cookies.login);
    console.log("isSignedIn:" + this.props.cookies.isSignedIn);
    if (!this.props.cookies.isSignedIn) {
      return <GuestProfileMenu />;
    } else if (
      this.props.cookies.role == "participant" ||
      this.props.cookies.role == "Participant"
    ) {
      return (
        <ParticipantProfileMenu
          login={this.props.cookies.login}
          unreadNotificationAmount={this.props.cookies.unreadNotificationAmount}
        />
      );
    } else if (
      this.props.cookies.role == "judge" ||
      this.props.cookies.role == "Judge"
    ) {
      return (
        <JudgeProfileMenu
          login={this.props.cookies.login}
          unreadNotificationAmount={this.props.cookies.unreadNotificationAmount}
        />
      );
    } else if (
      this.props.cookies.role == "administrator" ||
      this.props.cookies.role == "Administrator"
    ) {
      return (
        <AdminProfileMenu
          login={this.props.cookies.login}
          unreadNotificationAmount={this.props.cookies.unreadNotificationAmount}
        />
      );
    }
  }
}

export default connect(null, null)(ProfileMenu);
