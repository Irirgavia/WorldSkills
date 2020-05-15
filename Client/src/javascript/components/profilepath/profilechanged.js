import React from 'react';
import ReactDOM from 'react-dom';
import ParticipantProfile from './participantprofile.js';
import TrainerProfile from './trainerprofile.js';
import JudgeProfile from './judgeprofile.js';

export function ProfileChanged(name, role){
    document.getElementById("accountlink").href="/profile";
    var element = document.getElementById("accountlink");
    element.href = "accountlink";
    element.innerHTML = name;

    switch(role){
        case "participant":
            ReactDOM.render(<ParticipantProfile />,
                document.getElementById("profilemenu"));
            break;
        case "trainer":
            ReactDOM.render(<TrainerProfile />,
                document.getElementById("profilemenu"));
            break;
        case "judge":
            ReactDOM.render(<JudgeProfile />,
                document.getElementById("profilemenu"));
            break;
    }
}