namespace BLL.Services.Interfaces
{
    using System;
    using System.Collections.Generic;

    using BLL.DTO.NotificationSystem;

    public interface ISystemService : IDisposable
    {
        NewsDTO CreateNews(int accountIdFrom, string subject, string body);

        IEnumerable<NewsDTO> GetAllNews();

        MailDTO GetMailById(int id);

        IEnumerable<NewsDTO> GetNewsByDataRange(DateTime begin, DateTime end);

        IEnumerable<NewsDTO> GetNewsByFromAccountId(int id);

        NewsDTO GetNewsById(int id);

        IEnumerable<NotificationDTO> GetNotificationByFromAccountId(int id);

        NotificationDTO GetNotificationById(int id);

        IEnumerable<NotificationDTO> GetNotificationByToAccountId(int id);

        void UpdateMail(MailDTO mail);

        void UpdateNews(NewsDTO news);

        void UpdateNotification(NotificationDTO notification);
    }
}