namespace BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BLL.DTO.NotificationSystem;
    using BLL.Services.Interfaces;
    using BLL.Utilities;

    using DAL.Entities.NotificationSystem;
    using DAL.UnitOfWorks;
    using DAL.UnitOfWorks.Interfaces;

    public class SystemService : ISystemService
    {
        private readonly ISystemUnitOfWork systemUnitOfWork;

        public SystemService(string systemConnection)
        {
            this.systemUnitOfWork = new SystemUnitOfWork(systemConnection);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public NewsDTO CreateNews(int accountIdFrom, string subject, string body)
        {
            return ObjectMapper<NewsEntity, NewsDTO>.Map(
                this.systemUnitOfWork.NewsRepository.Create(
                    new NewsEntity(accountIdFrom, DateTime.Now, subject, body)));
        }

        public IEnumerable<NewsDTO> GetAllNews()
        {
            return ObjectMapper<NewsEntity, NewsDTO>.MapList(this.systemUnitOfWork.NewsRepository.GetAll());
        }

        public MailDTO GetMailById(int id)
        {
            return ObjectMapper<MailEntity, MailDTO>.Map(
                this.systemUnitOfWork.MailRepository.Get(m => m.Id == id).FirstOrDefault());
        }

        public IEnumerable<NewsDTO> GetNewsByDataRange(DateTime begin, DateTime end)
        {
            return ObjectMapper<NewsEntity, NewsDTO>.MapList(
                this.systemUnitOfWork.NewsRepository.Get(
                    n => n.PublicationDateTime >= begin && n.PublicationDateTime <= end));
        }

        public IEnumerable<NewsDTO> GetNewsByFromAccountId(int id)
        {
            return ObjectMapper<NewsEntity, NewsDTO>.MapList(
                this.systemUnitOfWork.NewsRepository.Get(n => n.AccountIdFrom == id));
        }

        public NewsDTO GetNewsById(int id)
        {
            return ObjectMapper<NewsEntity, NewsDTO>.Map(
                this.systemUnitOfWork.NewsRepository.Get(n => n.Id == id).FirstOrDefault());
        }

        public IEnumerable<NotificationDTO> GetNotificationByFromAccountId(int id)
        {
            return ObjectMapper<NotificationEntity, NotificationDTO>.MapList(
                this.systemUnitOfWork.NotificationRepository.Get(n => n.MailEntity.AccountIdFrom == id));
        }

        public NotificationDTO GetNotificationById(int id)
        {
            return ObjectMapper<NotificationEntity, NotificationDTO>.Map(
                this.systemUnitOfWork.NotificationRepository.Get(n => n.Id == id).FirstOrDefault());
        }

        public IEnumerable<NotificationDTO> GetNotificationByToAccountId(int id)
        {
            return ObjectMapper<NotificationEntity, NotificationDTO>.MapList(
                this.systemUnitOfWork.NotificationRepository.Get(n => n.MailEntity.AccountIdsTo.Contains(id)));
        }

        public void UpdateMail(MailDTO mail)
        {
            this.systemUnitOfWork.MailRepository.Update(ObjectMapper<MailDTO, MailEntity>.Map(mail));
            this.systemUnitOfWork.SaveChanges();
        }

        public void UpdateNews(NewsDTO news)
        {
            this.systemUnitOfWork.NewsRepository.Update(ObjectMapper<NewsDTO, NewsEntity>.Map(news));
            this.systemUnitOfWork.SaveChanges();
        }

        public void UpdateNotification(NotificationDTO notification)
        {
            this.systemUnitOfWork.NotificationRepository.Update(
                ObjectMapper<NotificationDTO, NotificationEntity>.Map(notification));
            this.systemUnitOfWork.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) this.systemUnitOfWork?.Dispose();
        }
    }
}