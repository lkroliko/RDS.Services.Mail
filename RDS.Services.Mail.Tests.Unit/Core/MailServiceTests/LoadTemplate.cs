using FluentAssertions;
using Moq;
using RDS.Services.Mail.Factory;
using RDS.Services.Mail.Filler;
using System.Net.Mail;
using Xunit;

namespace RDS.Services.Mail.Tests.Unit.MailServiceTests
{
    [Trait("Category", "MailService")]
    public class LoadTemplate
    {
        IMailService _service;
        ITemplateFactory _factory = Mock.Of<ITemplateFactory>();
        IMailMessageFiller _filler = Mock.Of<IMailMessageFiller>();
        MailMessage _template = new MailMessage();
        string _templateName = "template name";

        public LoadTemplate()
        {
            _service = new MailService(_factory, _filler, null);
            Mock.Get(_factory).Setup(f => f.Get(_templateName)).Returns(_template);
        }

        [Fact]
        public void ItHasMethod()
        {
            _service.LoadTemplate(_templateName);
        }

        [Fact]
        public void WhenCalledThenTemplateLoaded()
        { 
            _service.LoadTemplate(_templateName);

            _service.MessageTemplate.Should().BeSameAs(_template);
        }

        [Fact]
        public void WhenCalledThenFillFromAddressCalled()
        {
            _service.LoadTemplate(_templateName);

            Mock.Get(_filler).Verify(f => f.FillFromAddress(_template), Times.Once);
        }
    }
}
