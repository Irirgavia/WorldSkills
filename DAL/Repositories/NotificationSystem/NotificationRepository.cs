namespace DAL.Repositories.NotificationSystem
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using DAL.Contexts;
    using DAL.Entities.NotificationSystem;

    public class NotificationRepository : GenericRepository<NotificationEntity, NotificationSystemContext>
    {
        public NotificationRepository(NotificationSystemContext context)
            : base(context)
        {
        }

        public override IEnumerable<NotificationEntity> Get(Func<NotificationEntity, bool> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(n => n.MailEntity)
                .AsEnumerable()
                .Where(predicate);
        }

        public override IEnumerable<NotificationEntity> GetAll()
        {
            return this.DbSet
                .AsNoTracking()
                .Include(n => n.MailEntity)
                .AsEnumerable();
        }
    }
}