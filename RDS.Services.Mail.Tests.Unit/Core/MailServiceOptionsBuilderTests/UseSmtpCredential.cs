using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RDS.Services.Mail.Tests.Unit.MailServiceOptionsBuilderTests
{
    [Trait("Category", "MailServiceOptionsBuilder")]
    public class UseSmtpCredential : IClassFixture<MailServiceOptionsFixture>
    {
        IMailServiceOptions _options;
        MailServiceOptionsBuilder _builder;
        string _username = "username";
        string _password = "p@ssw0rd";

        public UseSmtpCredential(MailServiceOptionsFixture fixture)
        {
            _options = fixture.ServiceOptions;
            _builder = new MailServiceOptionsBuilder() { Options = _options };
        }

        [Fact]
        public void ItHasMethod()
        {
            _builder.UseSmtpCredential(_username, _password);
        }

        [Fact]
        public void ItReturnMailServiceOptionsBuilder()
        {
            var result = _builder.UseSmtpCredential(_username, _password);
            Assert.IsAssignableFrom<MailServiceOptionsBuilder>(result);
        }

        [Fact]
        public void ItSetSetting()
        {
            _builder.UseSmtpCredential(_username, _password);

            Assert.Equal(_username, _options.Sender.SmtpCredential.UserName);
            Assert.Equal(_password, _options.Sender.SmtpCredential.Password);
        }
    }
}
