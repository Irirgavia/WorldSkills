namespace DAL.Repositories
{
    using System;
    using System.Linq;

    using DAL.Entities;
    using DAL.Repositories.Interfaces;

    public class UserRepository : GenericRepository<UserEntity,CompetitionContext>,IUserRepository
    {
        public UserRepository(CompetitionContext context)
            : base(context)
        {
        }

        public UserEntity GetUserById(int id)
        {
            return Context.Users.FirstOrDefault(x => x.Id == id);
        }

        public UserEntity GetUserByLogin(string login)
        {
            return Context.Users.FirstOrDefault(x => x.Login == login);
        }

        public void CreateUser(
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
            Context.Users.Add(
                new UserEntity(login, password, surname, name, patronymic, birthday, photo, mail, telephone, awards));
        }

        public void DeleteUser(int id)
        {
            var user = this.GetUserById(id);
            if (user != null)
            {
                Context.Users.Remove(user);
            }
        }

        public void UpdateUser(
            int id,
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
            var user = this.GetUserById(id);
            if (user != null)
            {
                user.Login = login;
                user.Password = password;
                user.Surname = surname;
                user.Name = name;
                user.Patronymic = patronymic;
                user.Birthday = birthday;
                user.Photo = photo;
                user.Mail = mail;
                user.Telephone = telephone;
                user.Awards = awards;
            }
        }
    }
}