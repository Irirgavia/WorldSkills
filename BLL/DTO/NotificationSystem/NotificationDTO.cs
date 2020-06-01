namespace BLL.DTO.NotificationSystem
{
    public class NotificationDTO
    {
        public NotificationDTO()
        {
        }

        public NotificationDTO(MailDTO mail, bool isSent = false, bool isRead = false)
        {
            this.Mail = mail;
            this.IsSent = isSent;
            this.IsRead = isRead;
        }

        public int Id { get; private set; }

        public MailDTO Mail { get; private set; }

        public bool IsSent { get; set; }

        public bool IsRead { get; set; }
    }
}