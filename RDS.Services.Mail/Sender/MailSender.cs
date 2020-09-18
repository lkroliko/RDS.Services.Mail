using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Services.Mail.Sender
{
    public class MailSender : IMailSender
    {
        IMailSenderOptions _options;

        public MailSender(IMailSenderOptions options)
        {
            _options = options;
        }

        public void Send(MailMessage message)
        {
            using (SmtpClient client = CreateClient())
            {
                client.Send(message);
            }
        }

        public async Task SendAsync(MailMessage message)
        {
            using (SmtpClient client = CreateClient())
            {
                await client.SendMailAsync(message);
            }
        }

        internal SmtpClient CreateClient()
        {
            SmtpClient client = new SmtpClient(_options.SmtpHost, _options.SmtpPort);
            if (_options.SmtpCredential != null)
                client.Credentials = _options.SmtpCredential;
            return client;
        }
    }
}
