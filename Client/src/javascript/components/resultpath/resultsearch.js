import React from 'react';

export default class ResultsSearchForYear extends React.Component {
    constructor(props) {
      super(props);
      this.state = {
        error: null,
        isLoaded: false,
        items: []
      };
    }
  
    componentDidMount(year) {
      fetch("https://localhost:3000/results?year=${year}")
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
                        <th>Победитель</th>
                        <th>Баллы</th>
                        <th>Профессия</th>
                        <th>Этап</th>
                    </tr>
                    {items.map(item => (
                        <tr>
                            <td>{item.date}</td>
                            <td>{item.winner}</td>
                            <td>{item.marks}</td>
                            <td>{item.skill}</td>
                            <td>{item.stage}</td>
                        </tr>
                    ))}
                </table>
            );
        }
    }
}