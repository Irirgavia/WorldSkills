import '../sass/styles.scss';
import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import ProfileMenu from './components/profilemenu.js'
import Main from './components/main.js';
import History from './components/aboutpath/history.js';
import Rules from './components/aboutpath/rules.js';
import About from './components/about.js';
import Schedule from './components/schedule.js';
import Results from './components/results.js';
import ResultSearch from './components/resultpath/resultsearch.js';
import Contacts from './components/contacts.js';
import SignIn from './components/signin.js';
import SignOut from './components/signout.js';
import PersonalData from './components/profilepath/personaldata/personaldata.js'
import JudgeAnswers from './components/profilepath/judgeprofilepath/judgeanswers.js'
import ParticipantCompetitions from './components/profilepath/participantprofilepath/participantcompetitions.js'
import ParticipantPersonalData from './components/profilepath/participantprofilepath/participantpersonaldata.js'
import ParticipantResults from './components/profilepath/participantprofilepath/participantresults.js'
import TrainerResults from './components/profilepath/trainerprofilepath/trainerresults.js'
import NotFound from './components/system/notfound.js'

export default class App extends React.Component{
    render(){
        return <Router>
            <div>
                <ProfileMenu />
                <Switch>
                    <Route exact path="/" component={Main} />
                <Route path="/about/history" component={History} />
                <Route path="/about/rules" component={Rules} />
                <Route exact path="/about" component={About} />
                <Route path="/schedule" component={Schedule} />
                <Route exact path="/results" component={Results} />
                <Route path="/results/search" component={ResultSearch} />
                <Route path="/contacts" component={Contacts} />
                <Route path="/signin" component={SignIn} />
                <Route path="/signout" component={SignOut} />
                <Route path="/judge/answers" component={JudgeAnswers} />
                <Route path="/judge/personaldata" component={PersonalData} />
                <Route path="/participant/competitions" component={ParticipantCompetitions} />
                <Route path="/participant/personaldata" component={ParticipantPersonalData} />
                <Route path="/participant/results" component={ParticipantResults} />
                <Route path="/trainer/personaldata" component={PersonalData} />
                <Route path="/trainer/results" component={TrainerResults} />
                <Route component={NotFound} />
            </Switch>
        </div>
    </Router>;
    }
}