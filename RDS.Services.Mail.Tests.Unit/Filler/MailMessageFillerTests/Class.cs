using Moq;
using RDS.Services.Mail.Filler;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MailServiceTest.MailMessageFillerTests
{
    [Trait("Category", "MailMessageFiller")]
    public class Class
    {
        IMailMessageFillerOptions options = Mock.Of<IMailMessageFillerOptions>();

        [Fact]
        public void ItExists()
        {
            MailMessageFiller filler = new MailMessageFiller(options);
        }
    }
}
