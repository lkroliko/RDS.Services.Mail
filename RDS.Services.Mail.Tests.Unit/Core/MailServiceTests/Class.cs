using RDS.Services.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MailServiceTest.MailServiceTests
{
    [Trait("Category", "MailService")]
    public class Class
    {
        MailService _service = new MailService(null, null, null);

        [Fact]
        public void ItExists()
        {
            MailService service = new MailService(null, null, null);
        }

        [Fact]
        public void ItHasStaticOptionsProperty()
        {
            var options = MailService.Options;
        }

        [Fact]
        public void StaticOptionsPropertyIsNotNull()
        {
            Assert.NotNull(MailService.Options);
        }
    }
}
