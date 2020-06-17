import React from "react";
import { connect } from "react-redux";
import AdminProfileMenu from "../components/profilemenu/adminprofilemenu.js";
import ParticipantProfileMenu from "../components/profilemenu/participantprofilemenu.js";
import GuestProfileMenu from "../components/profilemenu/guestprofilemenu.js";
import JudgeProfileMenu from "../components/profilemenu/judgeprofilemenu.js";

export class ProfileMenu extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      id: this.props.cookies.get("id"),
      role: this.props.cookies.get("role"),
      login: this.props.cookies.get("login"),
      isSignedIn: this.props.cookies.get("isSignedIn"),
      unreadNotificationAmount: this.props.cookies.get(
        "unreadNotificationAmount"
      ),
    };
  }

  render() {
    console.log("name:" + this.state.login);
    console.log("isSignedIn:" + this.state.isSignedIn);
    if (!this.state.isSignedIn) {
      return <GuestProfileMenu />;
    } else if (
      this.state.role == "participant" ||
      this.state.role == "Participant"
    ) {
      return (
        <ParticipantProfileMenu
          login={this.state.login}
          unreadNotificationAmount={this.state.unreadNotificationAmount}
        />
      );
    } else if (this.state.role == "judge" || this.state.role == "Judge") {
      return (
        <JudgeProfileMenu
          login={this.state.login}
          unreadNotificationAmount={this.state.unreadNotificationAmount}
        />
      );
    } else if (
      this.state.role == "administrator" ||
      this.state.role == "Administrator"
    ) {
      return (
        <AdminProfileMenu
          login={this.state.login}
          unreadNotificationAmount={this.state.unreadNotificationAmount}
        />
      );
    }
  }
}

let mapProps = (ownProps) => {
  return {
    cookies: ownProps.cookies,
  };
};

export default connect(mapProps, null)(ProfileMenu);
