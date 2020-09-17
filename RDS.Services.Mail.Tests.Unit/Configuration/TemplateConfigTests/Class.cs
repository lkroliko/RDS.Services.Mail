using RDS.Services.Mail.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RDS.Services.Mail.Tests.Unit.Configuration.TemplateConfigTests
{
    [Trait("Category","Configuration")]
    public class Class
    {
        TemplateConfig _config = new TemplateConfig();
        
        [Fact]
        public void ItExistst()
        {
            TemplateConfig config = new TemplateConfig();
        }

        [Fact]
        public void ItHasPrefixWritableProperty()
        {
            var expected = "prefix";

            _config.Prefix = expected;

            Assert.Equal(expected, _config.Prefix);
            
        }

        [Fact]
        public void ItHasSuffixWritableProperty()
        {
            var expected = "suffix";

            _config.Suffix = expected;

            Assert.Equal(expected, _config.Suffix);

        }

        [Fact]
        public void ItHasVariablesWritableProperty()
        {
            var expected = new Variable[1];

            _config.Variables = expected;

            Assert.Equal(expected, _config.Variables);
        }

        [Fact]
        public void ItHasMailTemplatesWritableProperty()
        {
            var expected = new MailTemplateConfig[1];

            _config.MailTemplates = expected;

            Assert.Equal(expected, _config.MailTemplates);
        }
    }
}
