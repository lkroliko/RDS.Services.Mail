using RDS.Services.Mail;
using RDS.Services.Mail.Tests.Unit;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MailServiceTest.MailServiceOptionsTests
{
    [Trait("Category", "MailServiceOptionsBuilder")]
    public class UseSmtpServer
    {
        MailServiceOptionsBuilder _builder;

        public UseSmtpServer()
        {
            _builder = new MailServiceOptionsBuilder();
        }

        [Fact]
        public void ItSetSettings()
        {
            _builder.UseSmtpServer("host", 123);

            Assert.Equal("host", _builder.Options.Sender.SmtpHost);
            Assert.Equal(123, _builder.Options.Sender.SmtpPort);
        }
    }
}
