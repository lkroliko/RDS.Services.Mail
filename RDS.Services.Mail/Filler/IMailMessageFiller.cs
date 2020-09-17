using System.Net.Mail;

namespace RDS.Services.Mail.Filler
{
    public interface IMailMessageFiller
    {
        void Fill(MailMessage message);
        void Fill(MailMessage message, object model);
        void FillFromAddress(MailMessage message);
    }
}