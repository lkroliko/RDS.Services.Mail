using RDS.Services.Mail.Filler;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RDS.Services.Mail.Tests.Unit.Filler.MailMessageFillerOptionsBuilderTests
{
    [Trait("Category", "MailMessageFillerOptionsBuilder")]
    public class Class
    {
        MailMessageFillerOptionsBuilder _builder = new MailMessageFillerOptionsBuilder();

        [Fact]
        public void ItExistst()
        {
            MailMessageFillerOptionsBuilder builder = new MailMessageFillerOptionsBuilder();
        }
    }
}
