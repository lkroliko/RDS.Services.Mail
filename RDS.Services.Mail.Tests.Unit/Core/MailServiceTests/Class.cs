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
        [Fact]
        public void ItExists()
        {
            MailService service = new MailService(null, null, null);
        }
    }
}
