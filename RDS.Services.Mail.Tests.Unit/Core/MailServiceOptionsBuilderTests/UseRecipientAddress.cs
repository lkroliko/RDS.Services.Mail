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
    public class UseRecipientAddress : IClassFixture<MailServiceOptionsFixture>
    {
        IMailServiceOptions _options;
        MailServiceOptionsBuilder _builder;
        List<MailAddress> _recipientAddresses = new List<MailAddress>();

        public UseRecipientAddress(MailServiceOptionsFixture fixture)
        {
            _options = fixture.ServiceOptions;
            _builder = new MailServiceOptionsBuilder() { Options = _options };
        }

        [Fact]
        public void GivenMailAddressesThenOptionsSeted()
        {
            Mock.Get(_options.Filler).Setup(o => o.UseToAddresses).Returns(_recipientAddresses);

            _builder.UseRecipientAddress("recipient@host.local", "Display");

            Assert.Equal("recipient@host.local", _recipientAddresses[0].Address);
            Assert.Equal("Display", _recipientAddresses[0].DisplayName);
        }
    }
}
