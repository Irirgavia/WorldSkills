import React from 'react';

export default class ParticipantCompetititons extends React.Component {
    constructor(props) {
      super(props);
      this.state = {
        error   : null,
        isLoaded: false,
        items   : []
      };
    }
  
    componentDidMount() {
      fetch("https://localhost:3000/competitions?participant=${id}")
        .then(res => res.json())
        .then(
          (result) => {
            this.setState({
              isLoaded: true,
              items   : result.items
            });
          },
          (error) => {
            this.setState({
              isLoaded: true,
              error
            });
          }
        )
    }
  
    render() {
        const { error, isLoaded, items } = this.state;
        if (error) {
            return <div>Ошибка: {error.message}</div>;
        } else if (!isLoaded) {
            return <div>Загрузка...</div>;
        } else {
            return (<div>
                <button>Отправить ответы</button>
                <table border = "1">
                    <tr>
                        <th>Профессия</th>
                        <th>Этап</th>
                        <th>Дата начала</th>
                        <th>Дата конца</th>
                        <th>Адрес</th>
                        <th>Задание</th>
                        <th>Ответ</th>
                    </tr>
                    {items.map(item => (
                        <tr>
                            <td>{item.skill}</td>
                            <td>{item.stage}</td>
                            <td>{item.databegin}</td>
                            <td>{item.dataend}</td>
                            <td>{item.address}</td>
                            <td>{item.task}</td>
                            if (item.answer!=null) {
                                <td><input></input></td>
                            } else
                            {
                                <td>{item.answer}</td>
                            }
                        </tr>
                    ))}
                </table>
            </div>
            );
        }
    }
}