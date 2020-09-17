using Moq;
using RDS.Services.Mail.Factory;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RDS.Services.Mail.Tests.Unit.Factory.TemplateFactoryOptionsBuilderTests
{
    [Trait("Category", "TemplateFactoryOptionsBuilder")]
    public class AddTemplate
    {
        ITemplateFactoryOptions _options = Mock.Of<ITemplateFactoryOptions>();
        TemplateFactoryOptionsBuilder _builder;
        ConcurrentDictionary<string, IMailTemplate> _templates = new ConcurrentDictionary<string, IMailTemplate>();

        public AddTemplate()
        {
            _builder = new TemplateFactoryOptionsBuilder(_options);
            Mock.Get(_options).Setup(o => o.GetPrototype(It.IsAny<string>()))
                .Returns((string name) => _templates[name]);
            Mock.Get(_options).Setup(o => o.AddPrototype(It.IsAny<IMailTemplate>()))
                .Callback<IMailTemplate>(t => _templates[t.Name] = t);
        }

        [Fact]
        public void ItHasMethod()
        {
            _builder.AddTemplate(new MailTemplate() { Name = "name" });
        }

        [Fact]
        public void ItSetOptions()
        {
            var expected = new MailTemplate() { Name = "name" };

            _builder.AddTemplate(expected);

            Mock.Get(_options).Verify(o => o.AddPrototype(expected), Times.Once);
        }
    }
}