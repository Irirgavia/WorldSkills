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
    console.log("name:" + this.props.user.login);
    console.log("isSignedIn:" + this.props.isSignedIn);
    if (!this.props.isSignedIn) {
      return <GuestProfileMenu />;
    } else if (
      this.props.user.role == "participant" ||
      this.props.user.role == "Participant"
    ) {
      return (
        <ParticipantProfileMenu
          login={this.props.user.login}
          unreadNotificationAmount={this.props.unreadNotificationAmount}
        />
      );
    } else if (
      this.props.user.role == "judge" ||
      this.props.user.role == "Judge"
    ) {
      return (
        <JudgeProfileMenu
          login={this.props.user.login}
          unreadNotificationAmount={this.props.unreadNotificationAmount}
        />
      );
    } else if (
      this.props.user.role == "administrator" ||
      this.props.user.role == "Administrator"
    ) {
      return (
        <AdminProfileMenu
          login={this.props.user.login}
          unreadNotificationAmount={this.props.unreadNotificationAmount}
        />
      );
    }
  }
}

let mapProps = (state, ownProps) => {
  return {
    cookies: ownProps.cookies,
    user: {
      login: ownProps.cookies.login,
      role: ownProps.cookies.role,
    },
    isSignedIn: ownProps.cookies.isSignedIn,
    unreadNotificationAmount: ownProps.cookies.unreadNotificationAmount,
  };
};

export default connect(mapProps, null)(ProfileMenu);
