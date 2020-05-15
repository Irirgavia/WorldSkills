import React from 'react';
import ParticipantProfile from './profilepath/participantprofile.js';
import TrainerProfile from './profilepath/trainerprofile.js';
import JudgeProfile from './profilepath/judgeprofile.js';

export default class Profile extends React.Component {
    constructor(props) {
        super(props);
      }
    
    render() {switch(role){
        case "participant":
            return <ParticipantProfile />;
        case "trainer":
            return <TrainerProfile />;
        case "judge":
            return <JudgeProfile />;
        }
    }
}