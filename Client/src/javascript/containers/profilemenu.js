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
      id: "0",
      role: "",
      login: "",
      isSignedIn: false,
      unreadNotificationAmount: "0",
    };
  }

  componentDidMount() {
    const { cookies } = this.props;
    let id = cookies.get("id");
    let role = cookies.get("role");
    let login = cookies.get("login");
    let isSignedIn = cookies.get("isSignedIn");
    let unreadNotificationAmount = cookies.get("unreadNotificationAmount");
    this.setState({
      id: id,
      role: role,
      login: login,
      isSignedIn: isSignedIn,
      unreadNotificationAmount: unreadNotificationAmount,
    });
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
