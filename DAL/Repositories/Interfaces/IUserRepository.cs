namespace DAL.Repositories.Interfaces
{
    using System;

    using DAL.Entities;

    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        UserEntity GetUserById(int id);

        UserEntity GetUserByLogin(string login);

        void CreateUser(
            string login,
            string password,
            string surname,
            string name,
            string patronymic,
            DateTime birthday,
            string photo,
            string mail,
            string telephone,
            string awards);

        void DeleteUser(int id);

        void UpdateUser(
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
            string awards);
    }
}