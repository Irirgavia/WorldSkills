import React from 'react';

export default class ParticipantResults extends React.Component {
    constructor(props) {
      super(props);
      this.state = {
        error: null,
        isLoaded: false,
        items: []
      };
    }
  
    componentDidMount(year) {
      fetch("https://localhost:3000/results/participant?id=${id}")
        .then(res => res.json())
        .then(
          (result) => {
            this.setState({
              isLoaded: true,
              items: result.items
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
            return (
                <table border="1">
                    <caption>Результаты</caption>
                    <tr>
                        <th>Дата</th>
                        <th>Профессия</th>
                        <th>Этап</th>
                        <th>Баллы</th>
                    </tr>
                    {items.map(item => (
                        <tr>
                            <td>{item.date}</td>
                            <td>{item.skill}</td>
                            <td>{item.stage}</td>
                            <td>{item.marks}</td>
                        </tr>
                    ))}
                </table>
            );
        }
    }
}