import React from 'react';
 
export default class About extends React.Component{
    render(){
        return <nav id = "navbar-about">
        <ul>
            <li><a href = "/about/history">История</a></li>
            <li><a href = "/about/rules">Правила</a></li>
        </ul>
    </nav>;
    }
}