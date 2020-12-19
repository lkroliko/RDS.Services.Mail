using MailServiceIntegrationTests.Fakes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RDS.Services.Mail;
using System;
using System.Linq;
using System.Net.Mail;
using Xunit;
using FluentAssertions;

namespace MailServiceIntegrationTests
{
    [Trait("Category", "INTEGRATION")]
    public class BuilderConfiguration : IClassFixture<MailServiceFixture>
    {
        ServiceProvider _serviceProvider;
        MailServiceFixture _fixture;
        string _templateName = "template name";
        string _fromAddress = "sender@host.local";
        string _fromDisplayName = "Sender display name";

        public BuilderConfiguration(MailServiceFixture fixture)
        {
            _fixture = fixture;
            _fixture.Services.AddMail(options => options
            .UseSmtpServer("192.168.0.2")
            .UseSenderAddress(_fromAddress, _fromDisplayName)
            .UseTemplates(options=>options.AddTemplate(new FileMailTemplate() { Name = _templateName })));

            _fixture.AddFakeSender();

            _serviceProvider = _fixture.Services.BuildServiceProvider();
        }

        [Fact]
        public void SendTest()
        {
            IMailService service = _serviceProvider.GetRequiredService<IMailService>();
   
            service.LoadTemplate(_templateName).SendTemplate();
            MailMessage actual = _fixture.Sender.Sended.First();
            actual.From.Address.Should().Be(_fromAddress);
            actual.From.DisplayName.Should().Be(_fromDisplayName);
        }
    }
}
