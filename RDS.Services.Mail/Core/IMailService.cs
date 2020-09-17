using System.Net.Mail;
using System.Threading.Tasks;

namespace RDS.Services.Mail
{
    public interface IMailService
    {
        void Send(MailMessage message);
        Task SendAsync(MailMessage message);
        MailMessage GetTemplate(string name);
        void Fill(MailMessage message, object model);
        void Fill(MailMessage message);
        void FillAndSend(MailMessage message);
        void FillAndSend(MailMessage message, object model);
        Task FillAndSendAsync(MailMessage message);
        Task FillAndSendAsync(MailMessage message, object model);
    }
}