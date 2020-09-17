using RDS.Services.Mail.Factory;
using RDS.Services.Mail.Filler;
using RDS.Services.Mail.Sender;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RDS.Services.Mail
{
    public class MailService : IMailService
    {
        ITemplateFactory _factory;
        IMailMessageFiller _filler;
        IMailSender _sender;

        public MailService(ITemplateFactory factory, IMailMessageFiller filler, IMailSender sender)
        {
            _factory = factory;
            _filler = filler;
            _sender = sender;
        }

        public void Send(MailMessage message)
        {
            _filler.FillFromAddress(message);
            _sender.Send(message);
        }

        public async Task SendAsync(MailMessage message)
        {
            _filler.FillFromAddress(message);
            await _sender.SendAsync(message);
        }

        public MailMessage GetTemplate(string name)
        {
            return _factory.Get(name);
        }

        public void Fill(MailMessage message, object model)
        {
            _filler.Fill(message, model);
        }

        public void Fill(MailMessage message)
        {
            _filler.Fill(message);
        }

        public void FillAndSend(MailMessage message)
        {
            _filler.Fill(message);
            _sender.Send(message);
        }

        public void FillAndSend(MailMessage message, object model)
        {
            _filler.Fill(message, model);
            _sender.Send(message);
        }

        public async Task FillAndSendAsync(MailMessage message)
        {
            _filler.Fill(message);
            await _sender.SendAsync(message);
        }

        public async Task FillAndSendAsync(MailMessage message, object model)
        {
            _filler.Fill(message, model);
            await _sender.SendAsync(message);
        }
    }
}
