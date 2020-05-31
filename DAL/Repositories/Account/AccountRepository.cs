namespace DAL.Repositories.Account
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using DAL.Contexts;
    using DAL.Entities.Account;

    public class AccountRepository : GenericRepository<AccountEntity, AccountContext>
    {
        public AccountRepository(AccountContext context)
            : base(context)
        {
        }

        public override IEnumerable<AccountEntity> Get(Func<AccountEntity, bool> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(a => a.PersonalDataEntity.AddressEntity)
                .Include(a => a.CredentialsEntity.RoleEntity)
                .AsEnumerable()
                .Where(predicate);
        }

        public override IEnumerable<AccountEntity> GetAll()
        {
            return this.DbSet
                .AsNoTracking()
                .Include(a => a.PersonalDataEntity.AddressEntity)
                .Include(a => a.CredentialsEntity.RoleEntity)
                .AsEnumerable();
        }
    }
}