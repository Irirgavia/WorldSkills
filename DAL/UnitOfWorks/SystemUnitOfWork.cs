namespace DAL.UnitOfWorks
{
    using System;

    using DAL.Contexts;
    using DAL.Entities.NotificationSystem;
    using DAL.Repositories;
    using DAL.Repositories.Interfaces;
    using DAL.Repositories.NotificationSystem;
    using DAL.UnitOfWorks.Interfaces;

    public class SystemUnitOfWork : ISystemUnitOfWork
    {
        private readonly SystemContext systemContext;

        public SystemUnitOfWork(string connectionString)
        {
            this.systemContext = new SystemContext(connectionString);
        }

        public IGenericRepository<MailEntity> MailRepository =>
            new GenericRepository<MailEntity, SystemContext>(this.systemContext);

        public IGenericRepository<NotificationEntity> NotificationRepository =>
            new NotificationRepository(this.systemContext);

        public IGenericRepository<NewsEntity> NewsRepository =>
            new GenericRepository<NewsEntity, SystemContext>(this.systemContext);

        public void SaveChanges()
        {
            this.systemContext.SaveChanges();
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
                this.systemContext?.Dispose();
            }
        }
    }
}