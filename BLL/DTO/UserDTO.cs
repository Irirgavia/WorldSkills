namespace BLL.DTO
{
    using System;

    public class UserDTO
    {
        public UserDTO()
        {
        }

        public UserDTO(
            string login,
            string password,
            string surname,
            string name,
            string patronymic,
            DateTime birthday,
            string photo,
            string mail,
            string telephone,
            string awards)
        {
            Login = login;
            Password = password;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Birthday = birthday;
            Photo = photo;
            Mail = mail;
            Telephone = telephone;
            Awards = awards;
        }

        public int Id { get; private set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public DateTime Birthday { get; set; }

        public string Photo { get; set; }

        public string Mail { get; set; }

        public string Telephone { get; set; }

        public string Awards { get; set; }
    }
}