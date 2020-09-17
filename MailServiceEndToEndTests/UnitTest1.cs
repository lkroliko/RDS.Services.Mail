using MailServiceIntegrationTests;
using Microsoft.Extensions.DependencyInjection;
using Services.Mail;
using System;
using System.Net.Mail;
using Xunit;

namespace MailServiceEndToEndTests
{
    [Trait("Category", "END TO END")]
    public class UnitTest1 : IClassFixture<MailServiceFixture>
    {
        MailServiceFixture _fixture;
        ServiceProvider _serviceProvider;
        public UnitTest1(MailServiceFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact(Skip ="End to end")]
        //[Fact]
        public void SendViaLocalServer()
        {
            FileMailTemplate template = new FileMailTemplate()
            {
                Name = "test",
                Subject = "Mail from template test",
                Path = "Template.html"
            };

            _fixture.Services.AddMail(options => options
            .UseSmtpServer("192.168.0.2", 25)
            .UseSenderAddress("mailservice@host.local", "Mail Service")
            .UseSmtpCredential("mailservice", "P@ssw0rd")
            //.UseRecipientAddress("mailservice@host.local", "Recipient")
            .UseFiller(options=>options.AddVariable("<%URL%>","github.com"))
            .UseTemplates(options => options.AddTemplate(template)));

            _serviceProvider = _fixture.Services.BuildServiceProvider();
     
            IMailService service = _serviceProvider.GetRequiredService<IMailService>();
            
            MailMessage message = service.GetTemplate("test");
            message.To.Add("mailservice@host.local");
            service.FillAndSend(message,new object());
        }
    }
}
