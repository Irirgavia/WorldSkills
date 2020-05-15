import React from 'react';

export default class TrainerProfile extends React.Component {
    render() {
        return <ul class="submenu">
            <li><Link to="/profile/trainer/personaldata">Личные данные</Link></li>
            <li><Link to="/profile/trainer/results">Результаты команд</Link></li>
        </ul>;
    }
}