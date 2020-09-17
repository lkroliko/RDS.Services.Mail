using Moq;
using RDS.Services.Mail.Factory;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace RDS.Services.Mail.Tests.Unit.Factory.TemplateFactoryOptionsBuilderTests
{
    [Trait("Category", "TemplateFactoryOptionsBuilder")]
    public class AddTemplates
    {
        ITemplateFactoryOptions _options = Mock.Of<ITemplateFactoryOptions>();
        TemplateFactoryOptionsBuilder _builder;
        ConcurrentDictionary<string, IMailTemplate> _templates = new ConcurrentDictionary<string, IMailTemplate>();

        public AddTemplates()
        {
            _options = Mock.Of<ITemplateFactoryOptions>();
            _builder = new TemplateFactoryOptionsBuilder(_options);
        }

        [Fact]
        public void ItHasMethod()
        {
            _builder.AddTemplates(CreateTemplatesArray(1));
        }

        [Fact]
        public void ItSetOptions()
        {
            var expected = CreateTemplatesArray(10);

            _builder.AddTemplates(expected);

            foreach (var key in _templates.Keys)
            {
                Mock.Get(_options).Verify(o => o.AddPrototype(_templates[key]), Times.Once);
            }
        }

        private IMailTemplate[] CreateTemplatesArray(int length)
        {
            List<IMailTemplate> templates = new List<IMailTemplate>();
            for (int i = 0; i < length; i++)
            {
                templates.Add(new MailTemplate() { Name = i.ToString() });
            }
            return templates.ToArray();
        }
    }
}
