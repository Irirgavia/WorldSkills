namespace BLL.Utilities
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Mail;

    public static class MailUtility
    {
        private static string mailFrom = "world.skills.by@gmail.com";
        private static string nameFrom = "World Skills";
        private static string passwordFrom = "password";

        public static void SendEmail(IEnumerable<string> mails, string messageSubject, string messageBody)
        {
            var smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(mailFrom, passwordFrom);

            var from = new MailAddress(mailFrom, nameFrom);
            foreach (var mail in mails)
            {
                var to = new MailAddress(mail);
                var message = new MailMessage(from, to);
                message.Subject = messageSubject;
                message.Body = messageBody;
                smtp.Send(message);
            }
        }
    }
}