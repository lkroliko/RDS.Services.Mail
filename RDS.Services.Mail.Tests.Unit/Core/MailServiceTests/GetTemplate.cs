using Moq;
using RDS.Services.Mail.Factory;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Xunit;

namespace RDS.Services.Mail.Tests.Unit.MailServiceTests
{
    [Trait("Category", "MailService")]
    public class GetTemplate
    {
        IMailService _service;
        ITemplateFactory _factory = Mock.Of<ITemplateFactory>();
        MailMessage _template;

        public GetTemplate()
        {
            _template = new MailMessage();
            Mock.Get(_factory).Setup(f => f.Get(It.IsAny<string>())).Returns(_template);         
            _service = new MailService(_factory, null, null);            
        }

        [Fact]
        public void ItHasMethod()
        {
            _service.GetTemplate("name");
        }

        [Fact]
        public void GivenTemplateNameThenMailMessageReturned()
        {
            var result = _service.GetTemplate("name");

            Assert.Same(_template, result);
        }
    }
}
