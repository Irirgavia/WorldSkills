/*import '../sass/styles.scss';
var ReactDOM = require('react-dom');
var React = require('react');
//var Greetings = require('./greetings.js')

function greetings(){
ReactDOM.render(
    <h1>Международный конкурс "WorldSkills" на базе ГрГУ им. Я. Купалы!</h1>,
    document.getElementById("main")
);
};*/
import ReactDOM from 'react-dom';
import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Nav from './nav.js';
import Main from './components/main.js';
import About from './components/about.js';
import Schedule from './components/schedule.js';
import Results from './components/results.js';
import Contacts from './components/contacts.js';
import Profile from './components/profile.js';
//import NotFound from './components/notfound.js';
 
ReactDOM.render(
    <Router>
        <div>
           <Nav />
            <Switch>
                <Route exact path="/" component={Main} />
                <Route path="/about" component={About} />
                <Route path="/schedule" component={Schedule} />
                <Route path="/results" component={Results} />
                <Route path="/contacts" component={Contacts} />
                <Route path="/profile" component={Profile} />
                {/* <Route component={NotFound} /> */}
            </Switch>
        </div>
    </Router>,
    document.getElementById("main")
)