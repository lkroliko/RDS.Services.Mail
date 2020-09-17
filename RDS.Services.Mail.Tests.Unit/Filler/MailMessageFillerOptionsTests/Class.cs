using RDS.Services.Mail.Filler;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Xunit;

namespace RDS.Services.Mail.Tests.Unit.Filler.MailMessageFillerOptionsTests
{
    [Trait("Category", "MailMessageFillerOptions")]
    public class Class
    {
        MailMessageFillerOptions _options = new MailMessageFillerOptions();
        [Fact]
        public void ItExists()
        {
            MailMessageFillerOptions options = new MailMessageFillerOptions();
        }

        [Fact]
        public void ItImplementIMailMessageFillerOptions()
        {
            Assert.IsAssignableFrom<IMailMessageFillerOptions>(_options);
        }

        [Fact]
        public void ItHasNotNullAddCCAddressesProperty()
        {
            Assert.NotNull(_options.AddCCAddresses);
        }

        [Fact]
        public void ItHasUseFromAddressWritableProperty()
        {
            MailAddress address = new MailAddress("test@host.local");

            _options.UseFromAddress = address;

            Assert.Equal(address, _options.UseFromAddress);
        }

        [Fact]
        public void ItHasNotNullUseMessageToAddressesWritableProperty()
        {
            Assert.NotNull(_options.UseToAddresses);
        }

        [Fact]
        public void ItHasPrefixWritableProperty()
        {
            var value = "prefix";

            _options.Prefix = value;

            Assert.Equal(value, _options.Prefix);
        }

        [Fact]
        public void ItHasSuffixWritableProperty()
        {
            var value = "suffix";

            _options.Suffix = value;

            Assert.Equal(value, _options.Suffix);
        }

        [Fact]
        public void ItHasVariablesProperty()
        {
            Assert.NotNull(_options.Variables);
        }
    }
}
