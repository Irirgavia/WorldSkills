namespace BLL.Utilities
{
    using System.Collections.Generic;
    using System.Data;
    using System.Net;
    using System.Net.Mail;

    using BLL.DTO;

    public static class MailUtility
    {
        private static readonly string Host;
        private static readonly int Port;

        private static readonly string MailFrom;
        private static readonly string NameFrom;
        private static readonly string PasswordFrom;

        static MailUtility()
        {
            Host = "smtp.gmail.com";
            Port = 587;

            MailFrom = "world.skills.by@gmail.com";
            NameFrom = "World Skills";
            PasswordFrom = "password";
        }

        public static void SendEmail(IEnumerable<string> mails, string messageSubject, string messageBody)
        {
            var smtp = new SmtpClient(Host, Port)
                           {
                               EnableSsl = true,
                               DeliveryMethod = SmtpDeliveryMethod.Network,
                               UseDefaultCredentials = false,
                               Credentials = new NetworkCredential(MailFrom, PasswordFrom)
                           };

            var from = new MailAddress(MailFrom, NameFrom);
            foreach (var mail in mails)
            {
                var to = new MailAddress(mail);
                var message = new MailMessage(from, to) { Subject = messageSubject, Body = messageBody };
                smtp.Send(message);
            }
        }
    }
}