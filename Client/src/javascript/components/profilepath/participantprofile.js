import React from 'react';

export default class ParticipantProfile extends React.Component {
    render() {
        return <ul class="submenu">
            <li><Link to="/profile/participant/personaldata">Личные данные</Link></li>
            <li><Link to="/profile/participant/results">Результаты</Link></li>
            <li><Link to="/profile/participant/competitions">Текущие соревнования</Link></li>
        </ul>;
    }
}