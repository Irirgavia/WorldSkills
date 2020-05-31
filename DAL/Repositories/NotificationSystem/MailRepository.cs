namespace DAL.Repositories.NotificationSystem
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using DAL.Contexts;
    using DAL.Entities.NotificationSystem;

    public class MailRepository : GenericRepository<MailEntity, NotificationSystemContext>
    {
        public MailRepository(NotificationSystemContext context)
            : base(context)
        {
        }

        public override IEnumerable<MailEntity> Get(Func<MailEntity, bool> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(m => m.To.Select(a => a.PersonalDataEntity))
                .Include(m => m.To.Select(a => a.CredentialsEntity.RoleEntity))
                .Include(a => a.From.PersonalDataEntity)
                .Include(a => a.From.CredentialsEntity.RoleEntity)
                .AsEnumerable()
                .Where(predicate);
        }

        public override IEnumerable<MailEntity> GetAll()
        {
            return this.DbSet
                .AsNoTracking()
                .Include(m => m.To.Select(a => a.PersonalDataEntity))
                .Include(m => m.To.Select(a => a.CredentialsEntity.RoleEntity))
                .Include(a => a.From.PersonalDataEntity)
                .Include(a => a.From.CredentialsEntity.RoleEntity)
                .AsEnumerable();
        }
    }
}