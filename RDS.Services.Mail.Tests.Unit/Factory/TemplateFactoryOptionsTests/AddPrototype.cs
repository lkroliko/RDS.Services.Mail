using RDS.Services.Mail.Factory;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RDS.Services.Mail.Tests.Unit.Factory.TemplateFactoryOptionsTests
{
    [Trait("Category", "TemplateFactoryOptions")]
    public class AddPrototype
    {
        ConcurrentDictionary<string, IMailTemplate> _templates = new ConcurrentDictionary<string, IMailTemplate>();
        ITemplateFactoryOptions _options;
        IMailTemplate _template = new MailTemplate() { Name = "name" };

        public AddPrototype()
        {
            _options = new TemplateFactoryOptions(_templates);
        }

        [Fact]
        public void MethodExistst()
        {
            _options.AddPrototype(_template);
        }

        [Fact]
        public void GivenIMailTemplateThenOptionsSeted()
        {
            _options.AddPrototype(_template);

            Assert.Same(_template,_templates[_template.Name]);
        }
    }
}
