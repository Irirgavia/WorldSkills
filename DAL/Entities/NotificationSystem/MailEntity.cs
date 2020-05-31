namespace DAL.Entities.NotificationSystem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DAL.Entities.Account;

    public class MailEntity
    {
        public MailEntity()
        {
        }

        public MailEntity(
            AccountEntity from,
            ICollection<AccountEntity> to,
            DateTime dateTime,
            string subject,
            string body)
        {
            this.From = from;
            this.To = to;
            this.DateTime = dateTime;
            this.Subject = subject;
            this.Body = body;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        public AccountEntity From { get; set; }

        [Required]
        public ICollection<AccountEntity> To { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public string Subject { get; set; }
        
        [Required]
        public string Body { get; set; }
    }
}