using Moq;
using RDS.Services.Mail;
using RDS.Services.Mail.Tests.Unit;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Xunit;

namespace MailServiceTest.MailServiceOptionsTests
{
    [Trait("Category", "MailServiceOptionsBuilder")]
    public class UseRecipientAddress
    {
        MailServiceOptionsBuilder _builder = new MailServiceOptionsBuilder();

        [Fact]
        public void GivenMailAddressesThenOptionsSeted()
        {
            _builder.UseRecipientAddress("recipient@host.local", "Display");

            Assert.Equal("recipient@host.local", _builder.Options.Filler.UseToAddresses[0].Address);
            Assert.Equal("Display", _builder.Options.Filler.UseToAddresses[0].DisplayName);
        }
    }
}
