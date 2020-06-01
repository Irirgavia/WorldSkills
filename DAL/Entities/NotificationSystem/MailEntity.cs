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
            this.AccountIdsTo = new List<int>();
        }

        public MailEntity(
            int accountIdFrom,
            ICollection<int> accountIdsTo,
            DateTime dateTime,
            string subject,
            string body)
        {
            this.AccountIdFrom = accountIdFrom;
            this.AccountIdsTo = accountIdsTo;
            this.DateTime = dateTime;
            this.Subject = subject;
            this.Body = body;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        public int AccountIdFrom { get; set; }

        [Required]
        public ICollection<int> AccountIdsTo { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public string Subject { get; set; }
        
        [Required]
        public string Body { get; set; }
    }
}