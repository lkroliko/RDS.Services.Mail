using System.Net.Mail;
using System.Threading.Tasks;

namespace RDS.Services.Mail.Sender
{
    public interface IMailSender
    {
        void Send(MailMessage message);
        Task SendAsync(MailMessage message);
    }
}