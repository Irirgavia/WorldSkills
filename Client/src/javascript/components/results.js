import React from 'react';

export default class Results extends React.Component {
    render() {
        return <div>
            <table>
                <caption>Результаты</caption>
                <tr>
                    <td><label for = "skill">Профессия: </label></td>
                    <td><label for = "stage">Этап: </label></td>
                    <td><label for = "year">Год: </label></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td><input  type = "text" id = "skill" name = "skill" /></td>
                    <td><input  type = "text" id = "stage" name = "stage" /></td>
                    <td><input  type = "text" id = "year" name = "year" /></td>
                    <td><button id = "search" onClick = "">Искать</button></td>
                    <td><button id = "download" onClick = "" disabled>Скачать</button></td>
                </tr>
            </table>
            <div id="results">

            </div>
        </div>
    }
}