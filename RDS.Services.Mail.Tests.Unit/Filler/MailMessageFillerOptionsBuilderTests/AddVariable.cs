using Moq;
using RDS.Services.Mail.Filler;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RDS.Services.Mail.Tests.Unit.Filler.MailMessageFillerOptionsBuilderTests
{
    [Trait("Category", "MailMessageFillerOptionsBuilder")]
    public class AddVariable
    {
        MailMessageFillerOptionsBuilder _builder;

        public AddVariable()
        {
            _builder = new MailMessageFillerOptionsBuilder();
        }

        [Fact]
        public void ItHasMethod()
        {
            _builder.AddVariable("name", "value");
        }

        [Fact]
        public void WhenCalledThenMailMessageFillerOptionsBuilderReturned()
        {
            Assert.IsAssignableFrom<MailMessageFillerOptionsBuilder>(_builder.AddVariable("name", "value"));
        }

        [Fact]
        public void GivenParametersThenOptionSeted()
        {
            MailMessageFillerOptions result = _builder.AddVariable("name", "value");

            Assert.Equal("value", result.Variables["name"]);
        }
    }
}
