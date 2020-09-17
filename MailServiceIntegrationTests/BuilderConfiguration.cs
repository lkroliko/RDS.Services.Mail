using MailServiceIntegrationTests.Fakes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Services.Mail;
using System;
using System.Linq;
using System.Net.Mail;
using Xunit;

namespace MailServiceIntegrationTests
{
    [Trait("Category", "INTEGRATION")]
    public class BuilderConfiguration : IClassFixture<MailServiceFixture>
    {
        ServiceProvider _serviceProvider;
        MailServiceFixture _fixture;

        public BuilderConfiguration(MailServiceFixture fixture)
        {
            _fixture = fixture;
            _fixture.Services.AddMail(options => options
            .UseSmtpServer("192.168.0.2")
            .UseSenderAddress("sender@host.local", "Sender")
            .UseTemplates(options=>options.AddTemplate(new FileMailTemplate() { Name = "name" })));

            _fixture.AddFakeSender();

            _serviceProvider = _fixture.Services.BuildServiceProvider();
        }

        [Fact]
        public void Test1()
        {
            IMailService service = _serviceProvider.GetRequiredService<IMailService>();
            MailMessage message = new MailMessage();

            service.Send(message);
            MailMessage actual = _fixture.Sender.Sended.First();
            Assert.Equal(message, actual);
            Assert.Equal("sender@host.local", actual.From.Address);
            Assert.Equal("Sender", actual.From.DisplayName);
        }
    }
}
