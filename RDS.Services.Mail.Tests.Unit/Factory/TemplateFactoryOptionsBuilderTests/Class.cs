using Moq;
using RDS.Services.Mail.Factory;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MailServiceTest.TemplateFactoryOptionsBuilderTests
{
    [Trait("Category","TemplateFactoryOptionsBuilder")]
    public class Class
    {
        ITemplateFactoryOptions _options = Mock.Of<ITemplateFactoryOptions>();

        [Fact]
        public void ItExists()
        {
            TemplateFactoryOptionsBuilder builder = new TemplateFactoryOptionsBuilder(_options);
        }
    }
}
