using FluentAssertions;
using Moq;
using RDS.Services.Mail;
using RDS.Services.Mail.Factory;
using RDS.Services.Mail.Filler;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Xunit;

namespace MailServiceTest.MailServiceTests
{
    [Trait("Category", "MailService")]
    public class Class
    {
        IMailService _service;
        ITemplateFactory _factory = Mock.Of<ITemplateFactory>();
        IMailMessageFiller _filler = Mock.Of<IMailMessageFiller>();
        MailMessage _template = new MailMessage();

        public Class()
        {
            Mock.Get(_factory).Setup(f => f.Get(It.IsAny<string>())).Returns(_template);
            _service = new MailService(_factory, _filler, null);
        }

        [Fact]
        public void ItExists()
        {
            MailService service = new MailService(null, null, null);
        }

        [Fact]
        public void MailTemplatePropertyReturnsTemplate()
        {
            var result = _service.LoadTemplate("Template name").MessageTemplate;

            result.Should().BeSameAs(_template);
        }
    }
}
