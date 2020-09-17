using System.Net;

namespace RDS.Services.Mail.Sender
{
    public class MailSenderOptions : IMailSenderOptions
    {
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; } = 25;
        public NetworkCredential SmtpCredential { get; set; }
    }
}
