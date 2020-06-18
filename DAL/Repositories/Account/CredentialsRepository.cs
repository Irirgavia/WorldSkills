namespace DAL.Repositories.Account
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using DAL.Contexts;
    using DAL.Entities.Account;

    public class CredentialsRepository : GenericRepository<CredentialsEntity, AccountContext>
    {
        public CredentialsRepository(AccountContext context)
            : base(context)
        {
        }

        public override IEnumerable<CredentialsEntity> Get(Func<CredentialsEntity, bool> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(c => c.RoleEntity)
                .AsEnumerable()
                .Where(predicate);
        }

        public override IEnumerable<CredentialsEntity> GetAll()
        {
            return this.DbSet
                .AsNoTracking()
                .Include(c => c.RoleEntity)
                .AsEnumerable();
        }

        public override void Update(CredentialsEntity item)
        {
            var credentials = this.DbSet
                                  .Include(c => c.RoleEntity)
                                  .AsEnumerable()
                                  .FirstOrDefault(c => c.Id == item.Id);

            credentials.Login = item.Login;
            credentials.Password = item.Password;
            credentials.RoleEntityId = item.RoleEntityId;
        }
    }
}