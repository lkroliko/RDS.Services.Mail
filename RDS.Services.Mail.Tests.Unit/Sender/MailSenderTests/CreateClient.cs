using Moq;
using RDS.Services.Mail.Sender;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;

namespace RDS.Services.Mail.Tests.Unit.MailSenderTests
{
    [Trait("Category", "MailSender")]
    public class CreateClient : IClassFixture<MailServiceOptionsFixture>
    {
        IMailSenderOptions _options;
        MailSender _sender;

        public CreateClient(MailServiceOptionsFixture fixture)
        {
            _options = fixture.SenderOptions;
            _sender = new MailSender() { Options = _options };
        }

        [Fact]
        public void ItHasMethod()
        {
            _sender.CreateClient();
        }

        [Theory]
        [InlineData(99)]
        public void ItUsePortSetting(int expected)
        {
            Mock.Get(_options).Setup(o => o.SmtpPort).Returns(expected);

            int actual = _sender.CreateClient().Port;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("host.local")]
        public void ItUseHostSetting(string expected)
        {
            Mock.Get(_options).Setup(o => o.SmtpHost).Returns(expected);

            string actual = _sender.CreateClient().Host;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ItUseCredentialSetting()
        {
            NetworkCredential expected = new NetworkCredential();
            Mock.Get(_options).Setup(o => o.SmtpCredential).Returns(expected);

            var actual = _sender.CreateClient().Credentials;

            Assert.Equal(expected, actual);
        }
    }
}
