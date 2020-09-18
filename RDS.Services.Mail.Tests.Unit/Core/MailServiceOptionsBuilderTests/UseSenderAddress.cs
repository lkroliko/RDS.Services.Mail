using RDS.Services.Mail;
using RDS.Services.Mail.Tests.Unit;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MailServiceTest.MailServiceOptionsTests
{
    [Trait("Category", "MailServiceOptionsBuilder")]
    public class UseSenderAddress
    {
        MailServiceOptionsBuilder _builder = new MailServiceOptionsBuilder();

        [Fact]
        public void ItSetSettings()
        {
            var result = _builder.UseSenderAddress("sender@host.local", "display").Build();

            Assert.Equal("sender@host.local", result.Filler.UseFromAddress.Address);
            Assert.Equal("display", result.Filler.UseFromAddress.DisplayName);
        }
    }
}
