namespace BLL.DTO.NotificationSystem
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using BLL.DTO.Account;

    public class NewsDTO
    {
        public NewsDTO()
        {
        }

        public NewsDTO(AccountDTO account, DateTime publicationDateTime, string subject, string body)
        {
            this.Account = account;
            this.PublicationDateTime = publicationDateTime;
            this.Subject = subject;
            this.Body = body;
        }

        public int Id { get; private set; }

        public AccountDTO Account { get; set; }

        public DateTime PublicationDateTime { get; private set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}