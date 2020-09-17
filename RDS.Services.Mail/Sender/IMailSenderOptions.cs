using System.Net;

namespace RDS.Services.Mail.Sender
{
    public interface IMailSenderOptions
    {
        NetworkCredential SmtpCredential { get; set; }
        string SmtpHost { get; set; }
        int SmtpPort { get; set; }
    }
}