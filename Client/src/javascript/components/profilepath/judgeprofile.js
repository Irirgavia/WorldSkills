import React from 'react';

export default class JudgeProfile extends React.Component {
    render() {
        return <ul class="submenu">
            <li><Link to="/profile/judge/personaldata">Личные данные</Link></li>
            <li><Link to="/profile/judge/tasks">Задания</Link></li>
            <li><Link to="/profile/judge/answers">Ответы</Link></li>
        </ul>;
    }
}