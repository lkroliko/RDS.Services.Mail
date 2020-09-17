using RDS.Services.Mail;
using RDS.Services.Mail.Tests.Unit;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MailServiceTest.MailServiceOptionsTests
{
    [Trait("Category", "MailServiceOptionsBuilder")]
    public class UseSmtpServer : IClassFixture<MailServiceOptionsFixture>
    {
        IMailServiceOptions _options;
        MailServiceOptionsBuilder _builder;

        public UseSmtpServer(MailServiceOptionsFixture fixture)
        {
            _options = fixture.ServiceOptions;
            _builder = new MailServiceOptionsBuilder() { Options = _options };
        }

        [Fact]
        public void ItSetSettings()
        {
            _builder.UseSmtpServer("host", 123);

            Assert.Equal("host", _options.Sender.SmtpHost);
            Assert.Equal(123, _options.Sender.SmtpPort);
        }
    }
}
