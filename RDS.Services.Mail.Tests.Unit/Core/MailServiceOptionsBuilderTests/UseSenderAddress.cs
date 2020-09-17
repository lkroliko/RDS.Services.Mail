using RDS.Services.Mail;
using RDS.Services.Mail.Tests.Unit;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MailServiceTest.MailServiceOptionsTests
{
    [Trait("Category", "MailServiceOptionsBuilder")]
    public class UseSenderAddress : IClassFixture<MailServiceOptionsFixture>
    {
        IMailServiceOptions _options;
        MailServiceOptionsBuilder _builder;

        public UseSenderAddress(MailServiceOptionsFixture fixture)
        {
            _options = fixture.ServiceOptions;
            _builder = new MailServiceOptionsBuilder();
        }

        [Fact]
        public void ItSetSettings()
        {
            _builder.UseSenderAddress("sender@host.local", "display");

            Assert.Equal("sender@host.local", _options.Filler.UseFromAddress.Address);
            Assert.Equal("display", _options.Filler.UseFromAddress.DisplayName);
        }
    }
}
