using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RDS.Services.Mail.Tests.Unit.MailServiceOptionsBuilderTests
{
    [Trait("Category", "MailServiceOptionsBuilder")]
    public class UseTemplates
    {
        MailServiceOptionsBuilder _options = new MailServiceOptionsBuilder();

        [Fact]
        public void ItHasMethod()
        {
            _options.UseTemplates(o => o.ToString());
        }
    }
}
