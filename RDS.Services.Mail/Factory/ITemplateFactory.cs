using System.Net.Mail;

namespace RDS.Services.Mail.Factory
{
    public interface ITemplateFactory
    {
        MailMessage Get(string name);
    }
}