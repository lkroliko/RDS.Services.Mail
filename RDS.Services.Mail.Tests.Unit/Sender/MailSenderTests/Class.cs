using Moq;
using RDS.Services.Mail.Sender;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RDS.Services.Mail.Tests.Unit.MailSenderTests
{
    [Trait("Category","MailSender")]
    public class Class
    {
        MailSender _sender = new MailSender();

        [Fact]
        public void ItExists()
        {
            MailSender sender = new MailSender();
        }

        [Fact]
        public void ItHasOptionsProperty()
        {
            var options = _sender.Options;
        }

        [Fact]
        public void StaticPropertyIsNotNull()
        {
            Assert.NotNull(_sender.Options);
        }

        [Fact]
        public void OptionsPropertyImplementIMailSenderOptions()
        {
            Assert.IsAssignableFrom<IMailSenderOptions>(_sender.Options);
        }
    }
}
