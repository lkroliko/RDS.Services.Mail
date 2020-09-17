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
        IMailSenderOptions _options = Mock.Of<IMailSenderOptions>();

        [Fact]
        public void ItExists()
        {
            MailSender sender = new MailSender(_options);
        }
    }
}
