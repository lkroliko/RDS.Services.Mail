using RDS.Services.Mail.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RDS.Services.Mail.Tests.Unit.Configuration.MailAddressConfigTests
{
    [Trait("Category", "Configuration")]
    public class Class
    {
        MailAddressConfig _address = new MailAddressConfig();

        [Fact]
        public void ItExists()
        {
            MailAddressConfig address = new MailAddressConfig();
        }

        [Fact]
        public void ItHasDisplayWritableProperty()
        {
            var expected = "display";

            _address.Display = expected;

            Assert.Equal(expected, _address.Display);
        }

        [Fact]
        public void ItHasAddressWritableProperty()
        {
            var expected = "address";

            _address.Address = expected;

            Assert.Equal(expected, _address.Address);
        }
    }
}
