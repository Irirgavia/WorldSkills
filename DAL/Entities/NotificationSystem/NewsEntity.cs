namespace DAL.Entities.NotificationSystem
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class NewsEntity
    {
        public NewsEntity()
        {
        }

        public NewsEntity(int accountIdFrom, DateTime publicationDateTime, string subject, string body)
        {
            this.AccountIdFrom = accountIdFrom;
            this.PublicationDateTime = publicationDateTime;
            this.Subject = subject;
            this.Body = body;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        public int AccountIdFrom { get; set; }

        [Required]
        public DateTime PublicationDateTime { get; private set; }

        [Required]
        [MaxLength(30)]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }
    }
}