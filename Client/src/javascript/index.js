import '../sass/styles.scss';
import ReactDOM from 'react-dom';
import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Main from './components/main.js';
import History from './components/aboutpath/history.js';
import Rules from './components/aboutpath/rules.js';
import About from './components/about.js';
import Schedule from './components/schedule.js';
import Results from './components/results.js';
import Contacts from './components/contacts.js';
import Profile from './components/profile.js';
import Signin from './components/signin.js';
//import NotFound from './components/notfound.js';
 
ReactDOM.render(
    <Router>
        <div>
            <Switch>
                <Route exact path="/" component={Main} />
                <Route path="/about/history" component={History} />
                <Route path="/about/rules" component={Rules} />
                <Route path="/about" component={About} />
                <Route path="/schedule" component={Schedule} />
                <Route path="/results" component={Results} />
                <Route path="/contacts" component={Contacts} />
                <Route path="/profile" component={Profile} />
                <Route path="/signin" component={Signin} />
                {/* <Route component={NotFound} /> */}
            </Switch>
        </div>
    </Router>,
    document.getElementById("main")
)