using Moq;
using RDS.Services.Mail.Factory;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RDS.Services.Mail.Tests.Unit.TemplateFactoryTests
{
    [Trait("Category", "TemplateFactory")]
    public class Class
    {
        ITemplateFactoryOptions _options = Mock.Of<ITemplateFactoryOptions>();

        [Fact]
        public void ItExists()
        {
            TemplateFactory factory = new TemplateFactory(_options);
        }
    }
}
