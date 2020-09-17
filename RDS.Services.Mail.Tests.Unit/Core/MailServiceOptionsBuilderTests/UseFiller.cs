using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RDS.Services.Mail.Tests.Unit.MailServiceOptionsBuilderTests
{
    [Trait("Category", "MailServiceOptionsBuilder")]
    public class UseFiller
    {
        MailServiceOptionsBuilder _builder = new MailServiceOptionsBuilder();
        [Fact]
        public void ItHasMethod()
        {
            _builder.UseFiller(options => options.GetType());
        }

        [Fact]
        public void ItReturnMailServiceOptionsBuilder()
        {
            Assert.IsAssignableFrom<MailServiceOptionsBuilder>(_builder.UseFiller(options => options.GetType()));
        }
    }
}
