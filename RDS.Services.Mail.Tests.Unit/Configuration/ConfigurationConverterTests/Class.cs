using Moq;
using RDS.Services.Mail.Configuration;
using RDS.Services.Mail.Templates;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RDS.Services.Mail.Tests.Unit.Configuration.ConfigurationConverterTests
{
    [Trait("Category", "ConfigurationConverter")]
    public class Class
    {
        IMailTemplateFactory _mailTemplateFactory = Mock.Of<IMailTemplateFactory>();

        [Fact]
        public void ItExists()
        {
            ConfigurationConverter converter = new ConfigurationConverter(_mailTemplateFactory);
        }
    }
}
