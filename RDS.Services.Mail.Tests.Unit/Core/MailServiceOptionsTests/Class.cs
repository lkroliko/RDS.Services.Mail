using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using Xunit;

namespace RDS.Services.Mail.Tests.Unit.MailServiceOptionsTests
{
    [Trait("Category", "MailServiceOptions")]
    public class Class
    {
        IMailServiceOptions _options = new MailServiceOptions();

        [Fact]
        public void ItExists()
        {
            MailServiceOptions options = new MailServiceOptions();
        }

        [Fact]
        public void ItHasSenderProperty()
        {
            Assert.NotNull(_options.Sender);
        }

        [Fact]
        public void ItHasTemplateProperty()
        {
            Assert.NotNull(_options.Template);
        }

        [Fact]
        public void ItHasFillerProperty()
        {
            Assert.NotNull(_options.Filler);
        }
    }
}
