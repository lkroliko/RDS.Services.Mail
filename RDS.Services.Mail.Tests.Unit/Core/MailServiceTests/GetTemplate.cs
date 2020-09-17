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
    public class GetTemplate : IClassFixture<MailServiceOptionsFixture>
    {
        IMailService _service;
        IMailServiceOptions _options;
        ITemplateFactory _factory;
        MailMessage _template;
        public GetTemplate(MailServiceOptionsFixture fixture)
        {
            _template = new MailMessage();
            _options = fixture.ServiceOptions;
            _factory = Mock.Of<ITemplateFactory>();
            _service = new MailService(_factory, null, null);

            Mock.Get(_factory).Setup(f => f.Get(It.IsAny<string>())).Returns(_template);
        }

        [Fact]
        public void ItHasMethod()
        {
            _service.GetTemplate("name");
        }

        [Fact]
        public void GivenTemplateNameThenMailMessageReturned()
        {
            var actual = _service.GetTemplate("name");

            Assert.Same(_template, actual);
        }
    }
}
