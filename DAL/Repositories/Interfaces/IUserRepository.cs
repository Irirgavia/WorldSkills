namespace DAL.Repositories.Interfaces
{
    using System;

    using DAL.Entities;

    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        UserEntity GetUserByLogin(string login);
    }
}