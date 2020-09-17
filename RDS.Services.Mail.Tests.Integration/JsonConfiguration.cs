using MailServiceIntegrationTests.Fakes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Services.Mail;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using Xunit;

namespace MailServiceIntegrationTests
{
    [Trait("Category", "INTEGRATION")]
    public class JsonConfiguration : IClassFixture<MailServiceFixture>
    {
        ServiceProvider _serviceProvider;
        MailServiceFixture _fixture;

        public JsonConfiguration(MailServiceFixture fixture)
        {
            _fixture = fixture;
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
            IConfiguration configuration = builder.Build();

            _fixture.Services.AddMail(configuration);
            _fixture.AddFakeSender();

            _serviceProvider = _fixture.Services.BuildServiceProvider();
        }

        [Theory]
        [InlineData("Template 1")]
        [InlineData("Template 2")]
        [InlineData("Template 3")]
        public void Test1(string templateName)
        {
            IMailService service = _serviceProvider.GetRequiredService<IMailService>();
            MailMessage message = service.GetTemplate(templateName);

            service.Send(message);
            MailMessage actual = _fixture.Sender.Sended.First();
            Assert.Equal(message, actual);
            Assert.Equal(templateName, actual.Body);
            Assert.Equal("from@host.local", actual.From.Address);
            Assert.Equal("From", actual.From.DisplayName);
        }
    }
}