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

        public UserEntity GetUserByLogin(string login)
        {
            return this.DbSet
                .AsNoTracking()
                .FirstOrDefault(x => x.Login.Equals(login));
        }
    }
}