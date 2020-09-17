using Castle.DynamicProxy.Generators;
using Moq;
using RDS.Services.Mail;
using RDS.Services.Mail.Tests.Unit;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Xunit;

namespace MailServiceTest.MailServiceOptionsTests
{
    [Trait("Category", "MailServiceOptionsBuilder")]
    public class AddCCAddress : IClassFixture<MailServiceOptionsFixture>
    {
        IMailServiceOptions _options;
        MailServiceOptionsBuilder _builder;
        List<MailAddress> _addCCAddresses = new List<MailAddress>();

        public AddCCAddress(MailServiceOptionsFixture fixture)
        {
            _options = fixture.ServiceOptions;
            _builder = new MailServiceOptionsBuilder();

            Mock.Get(_options.Filler).Setup(o => o.AddCCAddresses).Returns(_addCCAddresses);
        }

        [Fact]
        public void ItSetSettings()
        {
            _builder.AddCCAddress("test@host.local","display");

            Assert.Equal("test@host.local", _addCCAddresses[0].Address);
            Assert.Equal("display", _addCCAddresses[0].DisplayName);
        }
    }
}
