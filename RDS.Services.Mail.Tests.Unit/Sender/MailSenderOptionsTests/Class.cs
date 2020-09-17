
using RDS.Services.Mail.Sender;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;

namespace RDS.Services.Mail.Tests.Unit.MailSenderOptionsTests
{
    [Trait("Category","MailSenderOptions")]
    public class Class
    {
        MailSenderOptions _options = new MailSenderOptions();
        
        [Fact]
        public void ItExists()
        {
            MailSenderOptions options = new MailSenderOptions();
        }

        [Fact]
        public void ItImplementIMailSenderOptions()
        {
            Assert.IsAssignableFrom<IMailSenderOptions>(_options);
        }

        [Fact]
        public void ItHasSmtpHostWritableProperty()
        {
            var value = "value";

            _options.SmtpHost = value;

            Assert.Equal(value, _options.SmtpHost);
        }

        [Fact]
        public void ItHasSmtpPortWritableProperty()
        {
            var value = 434;

            _options.SmtpPort = value;

            Assert.Equal(value, _options.SmtpPort);
        }

        [Fact]
        public void ItHasSmtpCredentialWritableProperty()
        {
            var value = new NetworkCredential();

            _options.SmtpCredential = value;

            Assert.Equal(value, _options.SmtpCredential);
        }
    }
}
