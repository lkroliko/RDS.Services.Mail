using Services.Mail;
using Services.Mail.Sender;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailServiceIntegrationTests.Fakes
{
    public class MailSenderFake : IMailSender
    {
        public List<MailMessage> Sended = new List<MailMessage>();
        public List<MailMessage> SendedAsync = new List<MailMessage>();
        public void Send(MailMessage message)
        {
            Sended.Add(message);
        }

        public Task SendAsync(MailMessage message)
        {
            SendedAsync.Add(message);
            return Task.CompletedTask;
        }
    }
}
