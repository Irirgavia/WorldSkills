import React from "react";
import AdminAccount from "./adminaccount.js";
import AdminAccountEdit from "./adminaccountedit.js";

export default class AdminAccountView extends React.Component {
  constructor(props) {
    super(props);
    this.editUser = this.editUser.bind(this);
    this.saveData = this.saveData.bind(this);
    this.createUser = this.createUser.bind(this);
    this.state = { users: [], selectedUser: { Id: -1 } };
  }

  componentDidMount() {
    var usersCopy = this.props.users.slice();
    this.setState({ users: usersCopy });
  }

  editUser(user) {
    this.setState({ selectedUser: user });
  }

  saveData(
    userId,
    role,
    surname,
    name,
    patronymic,
    birthday,
    mail,
    telephone,
    country,
    city,
    street,
    house,
    apartment
  ) {
    var users = this.state.users.slice();
    var user = users.find(this.findElementInArrayById, userId);
    user.Role = role;
    user.Surname = surname;
    user.Name = name;
    user.Patronymic = patronymic;
    user.Birthday = birthday;
    user.Mail = mail;
    user.Telephone = telephone;
    user.Country = country;
    user.City = city;
    user.Street = street;
    user.House = house;
    user.Apartment = apartment;
    this.setState({ users: users, selectedUser: user });
    this.props.saveData(user);
  }

  findElementInArrayById(element, index, array) {
    return element.Id == this;
  }

  createUser() {
    var users = this.state.users.slice();
    var user = {
      Id: -1,
      Role: "",
      Surname: "",
      Name: "",
      Patronymic: "",
      Birthday: "",
      Mail: "",
      Telephone: "",
      Country: "",
      City: "",
      Street: "",
      House: "",
      Apartment: "",
    };
    users.push(user);
    this.setState({ users: users, selectedUser: user });
  }

  choose(user) {
    if (user.Id == this.state.selectedUser.Id) {
      return <AdminAccountEdit data={user} saveUser={this.saveData} />;
    } else {
      return <AdminAccount user={user} editUser={this.editUser} />;
    }
  }

  render() {
    return (
      <div>
        <table>
          <thead>
            <th>Роль</th>
            <th>Фамилия</th>
            <th>Имя</th>
            <th>Отчество</th>
            <th>Дата рождения</th>
            <th>Почта</th>
            <th>Телефон</th>
            <th>Страна</th>
            <th>Город</th>
            <th>Улица</th>
            <th>Дом</th>
            <th>Квартира</th>
          </thead>
          <tbody>{this.state.users.map((user) => this.choose(user))}</tbody>
        </table>
        <button id="createUser" onClick={this.createUser}>
          {" "}
          Создать нового пользователя
        </button>
      </div>
    );
  }
}
