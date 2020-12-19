using System.Net.Mail;
using System.Threading.Tasks;

namespace RDS.Services.Mail
{
    public interface IMailService
    {
        MailMessage MessageTemplate { get; }

        IMailService FillTemplate(object model);
        IMailService LoadTemplate(string name);
        void SendTemplate();
        Task SendTemplateAsync();
    }
}