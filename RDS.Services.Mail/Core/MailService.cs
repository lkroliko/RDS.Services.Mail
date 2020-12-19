using RDS.Services.Mail.Factory;
using RDS.Services.Mail.Filler;
using RDS.Services.Mail.Sender;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RDS.Services.Mail
{
    public class MailService : IMailService
    {
        private readonly ITemplateFactory _factory;
        private readonly IMailMessageFiller _filler;
        private readonly IMailSender _sender;
        public MailMessage MessageTemplate { get; private set; }

        public MailService(ITemplateFactory factory, IMailMessageFiller filler, IMailSender sender)
        {
            _factory = factory;
            _filler = filler;
            _sender = sender;
        }

        public IMailService AddRecipient(string email)
        {
            MessageTemplate.To.Add(email);
            return this;
        }

        public void SendTemplate()
        {
            _sender.Send(MessageTemplate);
        }

        public async Task SendTemplateAsync()
        {
            await _sender.SendAsync(MessageTemplate);
        }

        public IMailService LoadTemplate(string name)
        {
            MessageTemplate = _factory.Get(name);
            _filler.FillFromAddress(MessageTemplate);
            return this;
        }

        public IMailService FillTemplate(object model)
        {
            _filler.Fill(MessageTemplate, model);
            return this;
        }
    }
}
