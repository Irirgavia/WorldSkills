namespace BLL.DTO.NotificationSystem
{
    using System;
    using System.Collections.Generic;

    using BLL.DTO.Account;

    public class MailDTO
    {
        public MailDTO()
        {
            this.To = new List<AccountDTO>();
        }

        public MailDTO(
            AccountDTO from,
            ICollection<AccountDTO> to,
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

        public int Id { get; private set; }

        public AccountDTO From { get; set; }

        public ICollection<AccountDTO> To { get; set; }

        public DateTime DateTime { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}