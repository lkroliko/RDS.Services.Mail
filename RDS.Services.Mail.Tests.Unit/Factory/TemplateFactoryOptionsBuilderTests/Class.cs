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
        TemplateFactoryOptionsBuilder _builder = new TemplateFactoryOptionsBuilder();

        [Fact]
        public void ItExists()
        {
            TemplateFactoryOptionsBuilder builder = new TemplateFactoryOptionsBuilder();
        }

        [Fact]
        public void ItHasOptionsProperty()
        {
            var options = _builder.Options;
        }

        [Fact]
        public void OptionsPropertyImplementITemplateFactoryOptions()
        {
            Assert.IsAssignableFrom<ITemplateFactoryOptions>(_builder.Options);
        }
    }
}
