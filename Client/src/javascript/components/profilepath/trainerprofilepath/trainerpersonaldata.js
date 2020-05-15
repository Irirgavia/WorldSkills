import React from 'react';

export default class TrainerPersonalData extends React.Component {
    constructor(props) {
      super(props);
      this.state = {
        error: null,
        isLoaded: false,
        items: []
      };
    }
  
    componentDidMount(year) {
      fetch("https://localhost:3000/personaldata/user?id=${id}")
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
                    <caption>Личные данные</caption>
                    <tr>
                        <th>Фамилия</th>
                        <th>Имя</th>
                        <th>Отчество</th>
                        <th>Дата рождения</th>
                        <th>Электронная почта</th>
                        <th>Телефон</th>
                        <th>Адрес</th>
                    </tr>
                    {items.map(item => (
                        <tr>
                            <td>{item.surname}</td>
                            <td>{item.name}</td>
                            <td>{item.patronymic}</td>
                            <td>{item.dateofbirth}</td>
                            <td>{item.email}</td>
                            <td>{item.telephone}</td>
                            <td>{item.address}</td>
                        </tr>
                    ))}
                </table>
            );
        }
    }
}