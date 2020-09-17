using RDS.Services.Mail.Factory;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RDS.Services.Mail.Tests.Unit.Factory.TemplateFactoryOptionsTests
{
    [Trait("Category", "TemplateFactoryOptions")]
    public class GetPrototype
    {
        ConcurrentDictionary<string, IMailTemplate> _templates = new ConcurrentDictionary<string, IMailTemplate>();
        ITemplateFactoryOptions _options;
        IMailTemplate _template = new MailTemplate() { Name = "name" };

        public GetPrototype()
        {
            _templates[_template.Name] = _template;
            _options = new TemplateFactoryOptions(_templates);
        }

        [Fact]
        public void MethodExists()
        {
            _options.GetPrototype("name");
        }

        [Fact]
        public void ItReturnsIMailTemplateWhenFound()
        {
            var result = _options.GetPrototype("name");

            Assert.IsAssignableFrom<IMailTemplate>(result);
            Assert.Same(result, _template);
        }

        [Fact]
        public void ItReturnsNullWhenNotFound()
        {
            Assert.Null(_options.GetPrototype("not exists name"));
        }
    }
}
