import React from 'react';

export default class JudgeAnswers extends React.Component {
    constructor(props) {
      super(props);
      this.state = {
        error: null,
        isLoaded: false,
        items: []
      };
    }
  
    componentDidMount(id) {
      fetch("https://localhost:3000/answers/judge?id=${id}")
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
                    <caption>Ответы</caption>
                    <tr>
                        <th>Соревнование</th>
                        <th>Этап</th>
                        <th>Задание</th>
                        <th>Ответ</th>
                        <th>Оценка</th>
                    </tr>
                    {items.map(item => (
                        <tr>
                            <td>{item.competition}</td>
                            <td>{item.stage}</td>
                            <td>{item.task}</td>
                            <td>{item.answer}</td>
                            <td>{item.mark}</td>
                        </tr>
                    ))}
                    <button type="submit">Отправить</button>
                </table>
            );
        }
    }
}