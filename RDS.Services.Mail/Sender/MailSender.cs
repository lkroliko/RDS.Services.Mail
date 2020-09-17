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
        public IMailSenderOptions Options { get; set; } = MailService.Options.Sender;

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
            SmtpClient client = new SmtpClient(Options.SmtpHost, Options.SmtpPort);
            if (Options.SmtpCredential != null)
                client.Credentials = Options.SmtpCredential;
            return client;
        }
    }
}
