import React from 'react';
import {Link, BrowserRouter}  from 'react-router-dom';
 
export default class Nav extends React.Component{
    render(){
        return <div>
                <Link to="/">Главная</Link> 
                <Link to="/about">О конкурсе</Link>
                <Link to="/schedule">График</Link>
                <Link to="/results">Результаты</Link>
                <Link to="/contacts">Контакты</Link>
                <Link to="/profile">Личный кабинет</Link>
              </div>;
    }
}