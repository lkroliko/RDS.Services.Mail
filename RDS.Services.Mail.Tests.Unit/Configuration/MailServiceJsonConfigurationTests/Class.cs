using RDS.Services.Mail.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RDS.Services.Mail.Tests.Unit.Configuration.MailServiceJsonConfigurationTests
{
    [Trait("Category", "Configuration")]
    public class Class
    {
        MailServiceJsonConfiguration _configuration = new MailServiceJsonConfiguration();

        [Fact]
        public void ItExists()
        {
            MailServiceJsonConfiguration configuration = new MailServiceJsonConfiguration();
        }

        [Fact]
        public void ItHasAddCCAddressesWritableProperty()
        {
            var expected = new MailAddressConfig[1];

            _configuration.AddCCAddresses = expected;

            Assert.Equal(expected, _configuration.AddCCAddresses);
        }

        [Fact]
        public void ItHasFromAddressWritableProperty()
        {
            var expected = "from";

            _configuration.FromAddress = expected;

            Assert.Equal(expected, _configuration.FromAddress);
        }

        [Fact]
        public void ItHasFromDisplayNameWritableProperty()
        {
            var expected = "display";

            _configuration.FromDisplayName = expected;

            Assert.Equal(expected, _configuration.FromDisplayName);
        }

        [Fact]
        public void ItHasSmtpHostWritableProperty()
        {
            var expected = "host";

            _configuration.SmtpHost = expected;

            Assert.Equal(expected, _configuration.SmtpHost);
        }

        [Fact]
        public void ItHasSmtpPasswordWritableProperty()
        {
            var expected = "password";

            _configuration.SmtpPassword = expected;

            Assert.Equal(expected, _configuration.SmtpPassword);
        }

        [Fact]
        public void ItHasSmtpPortWritableProperty()
        {
            var expected = 123;

            _configuration.SmtpPort = expected;

            Assert.Equal(expected, _configuration.SmtpPort);
        }

        [Fact]
        public void ItHasSmtpUserNameWritableProperty()
        {
            var expected = "user name";

            _configuration.SmtpUserName = expected;

            Assert.Equal(expected, _configuration.SmtpUserName);
        }

        [Fact]
        public void ItHasTemplateWritableProperty()
        {
            var expected = new TemplateConfig();

            _configuration.Template = expected;

            Assert.Equal(expected, _configuration.Template);
        }

        [Fact]
        public void ItHasUseToAddressesWritableProperty()
        {
            var expected = new MailAddressConfig[1];

            _configuration.UseToAddresses = expected;

            Assert.Equal(expected, _configuration.UseToAddresses);
        }
    }
}
