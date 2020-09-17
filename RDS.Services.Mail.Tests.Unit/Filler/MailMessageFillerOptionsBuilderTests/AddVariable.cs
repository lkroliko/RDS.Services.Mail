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
    public class AddVariable : IClassFixture<MailServiceOptionsFixture>
    {
        MailMessageFillerOptionsBuilder _builder;
        IMailMessageFillerOptions _options;
        ConcurrentDictionary<string, string> _variables = new ConcurrentDictionary<string, string>();

        public AddVariable(MailServiceOptionsFixture fixture)
        {
            _options = fixture.FillerOptions;
            _builder = new MailMessageFillerOptionsBuilder() { Options = _options };
            Mock.Get(_options).Setup(o => o.Variables).Returns(_variables);
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
            _builder.AddVariable("name", "value");

            Assert.Equal("value", _variables["name"]);
        }
    }
}
