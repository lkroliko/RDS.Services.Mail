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
        MailMessageFiller _filler = new MailMessageFiller();

        [Fact]
        public void ItExists()
        {
            MailMessageFiller filler = new MailMessageFiller();
        }

        [Fact]
        public void ItHasOptionProperty()
        {
            var options = _filler.Options;
        }

        [Fact]
        public void OptionPropertyIsNotNull()
        {
            Assert.NotNull(_filler.Options);
        }
    }
}
