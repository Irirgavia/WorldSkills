import "../sass/styles.scss";
import React from "react";
import { Route, Switch } from "react-router-dom";
import ProfileMenu from "./containers/profilemenu.js";
import Main from "./components/simplepages/main.js";
import About from "./components/simplepages/about.js";
import Schedule from "./containers/schedule.js";
import Results from "./containers/results.js";
import Contacts from "./components/simplepages/contacts.js";
import SignIn from "./containers/signin.js";
import SignOut from "./containers/signout.js";
import PersonalData from "./containers/profile/personaldata.js";
import PersonalDataChange from "./containers/profile/personaldatachange.js";
import Notifications from "./containers/profile/notifications.js";
import JudgeAnswers from "./containers/profile/judge/judgeanswers.js";
import ParticipantCompetitions from "./containers/profile/participant/participantcompetitions.js";
import ParticipantResults from "./containers/profile/participant/participantresults.js";
import AdminCompetitions from "./containers/profile/admin/admincompetition.js";
import AdminAccount from "./containers/profile/admin/adminaccount.js";
import NotFound from "./components/system/notfound.js";
import { withCookies } from "react-cookie";

export class App extends React.Component {
  constructor(props) {
    super(props);
    this.setCookies = this.setCookies.bind(this);
    this.clearAllCookies = this.clearAllCookies.bind(this);

    const { cookies } = props;
    this.state = {
      login: cookies.get("login") || "",
      id: cookies.get("id") || "0",
      role: cookies.get("role") || "",
      isSignedIn: cookies.get("isSignedIn") || false,
      unreadNotificationAmount: cookies.get("unreadNotificationAmount") || "0",
    };
  }

  setCookies(nameCookie, value) {
    const { cookies } = this.props;

    cookies.set(nameCookie, value, { path: "/" });
    this.setState({ [nameCookie]: value });
  }

  clearAllCookies() {
    const { cookies } = this.props;

    cookies.remove("isSignedIn", { path: "/" });
    cookies.remove("id", { path: "/" });
    cookies.remove("login", { path: "/" });
    cookies.remove("role", { path: "/" });
    cookies.remove("unreadNotificationAmount", { path: "/" });
    this.setState({
      login: "",
      id: "0",
      role: "",
      isSignedIn: false,
      unreadNotificationAmount: "0",
    });
  }

  render() {
    return (
      <div>
        <ProfileMenu
          id={this.state.id}
          login={this.state.login}
          role={this.state.role}
          isSignedIn={this.state.isSignedIn}
          unreadNotificationAmount={this.state.unreadNotificationAmount}
        />
        <Switch>
          <Route exact path="/" component={Main} />
          <Route path="/about" component={About} />
          <Route path="/schedule" component={Schedule} />
          <Route path="/results" component={Results} />
          <Route path="/contacts" component={Contacts} />
          <Route
            path="/signin"
            render={() => <SignIn setCookies={this.setCookies} />}
          />
          <Route
            path="/signout"
            render={() => <SignOut clearAllCookies={this.clearAllCookies} />}
          />
          <Route
            path="/judge/answers"
            render={() => <JudgeAnswers cookies={this.props.cookies} />}
          />
          <Route
            exact
            path="/judge/personaldata"
            render={() => (
              <PersonalData
                cookies={this.props.cookies}
                returnURL={"/judge/personaldata/change"}
              />
            )}
          />
          <Route
            path="/judge/personaldata/change"
            render={() => (
              <PersonalDataChange
                cookies={this.props.cookies}
                returnURL={"/judge/personaldata"}
              />
            )}
          />
          <Route
            path="/judge/notifications"
            render={() => <Notifications cookies={this.props.cookies} />}
          />
          <Route
            path="/participant/competitions"
            render={() => (
              <ParticipantCompetitions cookies={this.props.cookies} />
            )}
          />
          <Route
            exact
            path="/participant/personaldata"
            render={() => (
              <PersonalData
                cookies={this.props.cookies}
                returnURL={"/participant/personaldata/change"}
              />
            )}
          />
          <Route
            path="/participant/personaldata/change"
            render={() => (
              <PersonalDataChange
                cookies={this.props.cookies}
                returnURL={"/participant/personaldata"}
              />
            )}
          />
          <Route
            path="/participant/notifications"
            render={() => <Notifications cookies={this.props.cookies} />}
          />
          <Route
            path="/participant/results"
            render={() => <ParticipantResults cookies={this.props.cookies} />}
          />
          <Route
            exact
            path="/administrator/personaldata"
            render={() => (
              <PersonalData
                cookies={this.props.cookies}
                returnURL={"/administrator/personaldata/change"}
              />
            )}
          />
          <Route
            path="/administrator/personaldata/change"
            render={() => (
              <PersonalDataChange
                cookies={this.props.cookies}
                returnURL={"/administrator/personaldata"}
              />
            )}
          />
          <Route
            path="/administrator/competitions"
            render={() => <AdminCompetitions cookies={this.props.cookies} />}
          />
          <Route
            path="/administrator/accounts"
            render={() => <AdminAccount cookies={this.props.cookies} />}
          />
          <Route component={NotFound} />
        </Switch>
      </div>
    );
  }
}

export default withCookies(App);
