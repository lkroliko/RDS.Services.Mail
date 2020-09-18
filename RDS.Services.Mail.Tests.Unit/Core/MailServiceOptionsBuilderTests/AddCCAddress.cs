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
    public class AddCCAddress
    {
        MailServiceOptionsBuilder _builder = new MailServiceOptionsBuilder();

        [Fact]
        public void ItSetSettings()
        {
            IMailServiceOptions result = _builder.AddCCAddress("test@host.local","display").Build();

            Assert.Equal("test@host.local", result.Filler.AddCCAddresses[0].Address);
            Assert.Equal("display", result.Filler.AddCCAddresses[0].DisplayName);
        }
    }
}
