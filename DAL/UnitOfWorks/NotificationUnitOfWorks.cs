namespace DAL.UnitOfWorks
{
    using System;

    using DAL.Contexts;
    using DAL.Entities.Account;
    using DAL.Entities.NotificationSystem;
    using DAL.Repositories.Account;
    using DAL.Repositories.Interfaces;
    using DAL.Repositories.NotificationSystem;
    using DAL.UnitOfWorks.Interfaces;

    public class NotificationUnitOfWorks : INotificationUnitOfWorks
    {
        private readonly NotificationSystemContext notificationSystemContext;
        private readonly AccountContext accountContext;

        public NotificationUnitOfWorks(string connectionString)
        {
            this.accountContext = new AccountContext(connectionString);
            this.notificationSystemContext = new NotificationSystemContext(connectionString);
        }

        public IGenericRepository<AccountEntity> AccountRepository =>
            new AccountRepository(this.accountContext);

        public IGenericRepository<MailEntity> MailRepository =>
            new MailRepository(this.notificationSystemContext);

        public IGenericRepository<NotificationEntity> NotificationRepository =>
            new NotificationRepository(this.notificationSystemContext);

        public void SaveChanges()
        {
            this.notificationSystemContext.SaveChanges();
            this.accountContext.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.notificationSystemContext?.Dispose();
                this.accountContext?.Dispose();
            }
        }
    }
}