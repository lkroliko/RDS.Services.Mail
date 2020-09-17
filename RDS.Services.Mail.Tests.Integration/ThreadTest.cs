using Microsoft.Extensions.DependencyInjection;
using RDS.Services.Mail;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading;
using Xunit;

namespace MailServiceIntegrationTests
{
    [Trait("Category", "INTEGRATION")]
    public class ThreadTest :IClassFixture<MailServiceFixture>
    {
        MailServiceFixture _fixture;
        ServiceProvider _serviceProvider;
        public ThreadTest(MailServiceFixture fixture)
        {
            _fixture = fixture;
            _fixture.Services.AddMail(options => options
           .UseSmtpServer("192.168.0.2")
           .UseSenderAddress("sender@test.local", "Sender")
           .UseTemplates(options => options.AddTemplate(new FileMailTemplate() { Name = "test" })));

            _fixture.AddFakeSender();

            _serviceProvider = _fixture.Services.BuildServiceProvider();
        }

        [Fact (Skip ="to do")]
        public void ThreaddddTest()
        {
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                Thread thread = new Thread(work);
                thread.Start();
                
            }
            
            Thread.Sleep(1000000);
        }

        private void work()
        {
            while(true)
            {
                IMailService service = _serviceProvider.GetRequiredService<IMailService>();
                MailMessage message = service.GetTemplate("test");
                message.To.Add(new MailAddress("mailservice@host.local"));
                service.Send(message);
            }
        }
    }
}
