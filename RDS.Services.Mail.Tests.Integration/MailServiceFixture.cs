using MailServiceIntegrationTests.Fakes;
using Microsoft.Extensions.DependencyInjection;
using RDS.Services.Mail.Sender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MailServiceIntegrationTests
{
    public class MailServiceFixture
    {
        public IServiceCollection Services = new ServiceCollection();
        public MailSenderFake Sender = new MailSenderFake();

        public void AddFakeSender()
        {
            var serviceDescription = Services.First(s => s.ImplementationType == typeof(MailSender));
            Services.Remove(serviceDescription);
            Services.AddSingleton<IMailSender>(Sender);
        }
    }
}
