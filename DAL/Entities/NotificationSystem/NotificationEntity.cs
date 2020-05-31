namespace DAL.Entities.NotificationSystem
{
    using System.ComponentModel.DataAnnotations;

    public class NotificationEntity
    {
        public NotificationEntity()
        {
        }

        public NotificationEntity(MailEntity mail, bool isSent = false, bool isRead = false)
        {
            this.MailEntity = mail;
            this.IsSent = isSent;
            this.IsRead = isRead;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        public MailEntity MailEntity { get; private set; }

        [Required]
        public bool IsSent { get; set; }

        [Required]
        public bool IsRead { get; set; }
    }
}