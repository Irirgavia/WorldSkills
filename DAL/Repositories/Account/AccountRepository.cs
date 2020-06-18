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
                .Include(a => a.PersonalDataIdEntity.AddressEntity)
                .Include(a => a.CredentialsIdEntity.RoleEntity)
                .AsEnumerable()
                .Where(predicate);
        }

        public override IEnumerable<AccountEntity> GetAll()
        {
            return this.DbSet
                .AsNoTracking()
                .Include(a => a.PersonalDataIdEntity.AddressEntity)
                .Include(a => a.CredentialsIdEntity.RoleEntity)
                .AsEnumerable();
        }

        public override void Update(AccountEntity item)
        {
            var acc = this.DbSet
                       .Include(a => a.PersonalDataIdEntity.AddressEntity)
                       .Include(a => a.CredentialsIdEntity.RoleEntity)
                       .AsEnumerable()
                       .FirstOrDefault(a => a.Id == item.Id);

            acc.IsMailNotificationTurnOn = item.IsMailNotificationTurnOn;
            acc.StageIds = item.StageIds;
        }
    }
}