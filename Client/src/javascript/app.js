import "../sass/styles.scss";
import React from "react";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import ProfileMenu from "./containers/profilemenu.js";
import Main from "./components/simplepages/main.js";
import About from "./components/simplepages/about.js";
import Schedule from "./containers/schedule.js";
import Results from "./containers/results.js";
import Contacts from "./components/simplepages/contacts.js";
import SignIn from "./containers/signin.js";
import SignOut from "./containers/signout.js";
import PersonalData from "./containers/profile/personaldata.js";
import Notifications from "./containers/profile/notifications.js";
import JudgeAnswers from "./containers/profile/judge/judgeanswers.js";
import ParticipantCompetitions from "./containers/profile/participant/participantcompetitions.js";
import ParticipantResults from "./containers/profile/participant/participantresults.js";
import AdministratorCompetitions from "./containers/profile/admin/admincompetition.js";
import NotFound from "./components/system/notfound.js";

export default class App extends React.Component {
  render() {
    return (
      <Router>
        <div>
          <ProfileMenu />
          <Switch>
            <Route exact path="/" component={Main} />
            <Route path="/about" component={About} />
            <Route path="/schedule" component={Schedule} />
            <Route path="/results" component={Results} />
            <Route path="/contacts" component={Contacts} />
            <Route path="/signin" component={SignIn} />
            <Route path="/signout" component={SignOut} />
            <Route path="/judge/answers" component={JudgeAnswers} />
            <Route exact path="/judge/personaldata" component={PersonalData} />
            <Route path="/judge/notifications" component={Notifications} />
            <Route
              path="/participant/competitions"
              component={ParticipantCompetitions}
            />
            <Route
              exact
              path="/participant/personaldata"
              component={PersonalData}
            />
            <Route
              path="/participant/notifications"
              component={Notifications}
            />
            <Route path="/participant/results" component={ParticipantResults} />
            <Route
              exact
              path="/administrator/personaldata"
              component={PersonalData}
            />
            <Route
              path="/administrator/competitions"
              component={AdministratorCompetitions}
            />
            <Route component={NotFound} />
          </Switch>
        </div>
      </Router>
    );
  }
}
