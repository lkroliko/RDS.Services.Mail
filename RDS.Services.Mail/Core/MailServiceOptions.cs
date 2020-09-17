using RDS.Services.Mail.Factory;
using RDS.Services.Mail.Filler;
using RDS.Services.Mail.Sender;

namespace RDS.Services.Mail
{
    internal class MailServiceOptions : IMailServiceOptions
    {
        public IMailSenderOptions Sender { get; } = new MailSenderOptions();
        public ITemplateFactoryOptions Template { get; } = new TemplateFactoryOptions();
        public IMailMessageFillerOptions Filler { get; } = new MailMessageFillerOptions();
    }
}
