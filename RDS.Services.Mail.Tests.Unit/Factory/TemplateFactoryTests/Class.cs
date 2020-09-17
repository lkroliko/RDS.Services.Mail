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
        TemplateFactory _factory = new TemplateFactory();

        [Fact]
        public void ItExists()
        {
            TemplateFactory factory = new TemplateFactory();
        }

        [Fact]
        public void ItHasOptionsProperty()
        {
            var options = _factory.Options;
        }

        [Fact]
        public void OptionsPropertyIsNotNull()
        {
            Assert.NotNull(_factory);
        }

        [Fact]
        public void OptionsPropertyImplementITemplateFactoryOptions()
        {
            Assert.IsAssignableFrom<ITemplateFactoryOptions>(_factory.Options);
        }
    }
}
