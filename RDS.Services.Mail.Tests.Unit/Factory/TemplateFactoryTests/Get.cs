using Moq;
using RDS.Services.Mail;
using RDS.Services.Mail.Factory;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Abstractions;
using System.Net.Mail;
using System.Text;
using Xunit;

namespace ServicesMailTest.Mail
{
    [Trait("Category", "TemplateFactory")]
    public class Get
    {
        ITemplateFactoryOptions _options = Mock.Of<ITemplateFactoryOptions>();
        TemplateFactory _factory;
        ConcurrentDictionary<string, IMailTemplate> _templates = new ConcurrentDictionary<string, IMailTemplate>();
        MailTemplate _template = new MailTemplate()
        {
            Name = "template name",
            Body = "test body",
            Subject = "test subject",
            IsBodyHtml = true
        };

        public Get()
        {
            _templates[_template.Name] = _template;
            Mock.Get(_options).Setup(o => o.GetPrototype(It.IsAny<string>()))
                .Returns<string>(n => _templates[n]);
            _factory = new TemplateFactory(_options);
        }

        [Fact]
        public void ItHasMethod()
        {
            var message = _factory.Get(_template.Name);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ItCreateMailMessage(bool isBodyHtml)
        {
            _template.IsBodyHtml = isBodyHtml;
            var message = _factory.Get(_template.Name);

            Assert.Equal(_template.Body, message.Body);
            Assert.Equal(_template.Subject, message.Subject);
            Assert.Equal(_template.IsBodyHtml, message.IsBodyHtml);
        }
    }
}
