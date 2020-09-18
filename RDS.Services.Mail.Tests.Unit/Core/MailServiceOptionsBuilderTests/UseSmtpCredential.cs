using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RDS.Services.Mail.Tests.Unit.MailServiceOptionsBuilderTests
{
    [Trait("Category", "MailServiceOptionsBuilder")]
    public class UseSmtpCredential
    {
        MailServiceOptionsBuilder _builder = new MailServiceOptionsBuilder();
        string _username = "username";
        string _password = "p@ssw0rd";

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

            Assert.Equal(_username, _builder.Options.Sender.SmtpCredential.UserName);
            Assert.Equal(_password, _builder.Options.Sender.SmtpCredential.Password);
        }
    }
}
