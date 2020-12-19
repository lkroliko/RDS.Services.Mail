using Moq;
using RDS.Services.Mail;
using RDS.Services.Mail.Factory;
using RDS.Services.Mail.Filler;
using RDS.Services.Mail.Sender;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Xunit;

namespace MailServiceTest.MailServiceTests
{
    [Trait("Category", "MailService")]
    public class SendTemplate
    {
        MailService _service;
        IMailSender _sender = Mock.Of<IMailSender>();
        IMailMessageFiller _filler = Mock.Of<IMailMessageFiller>();
        ITemplateFactory _factory = Mock.Of<ITemplateFactory>();
        MailMessage _template = new MailMessage();
        string _templateName = "any";

        public SendTemplate()
        {
            Mock.Get(_factory).Setup(f => f.Get(It.IsAny<string>())).Returns(_template);
            _service = new MailService(_factory, _filler, _sender);
            _service.LoadTemplate(_templateName);
        }

        [Fact]
        public void ItHasMethod()
        {
            _service.SendTemplate();
        }

        [Fact]
        public void WhanCalledThenMailSenderCalled()
        {
            _service.SendTemplate();

            Mock.Get(_sender).Verify(s => s.Send(_service.MessageTemplate), Times.Once);
        }
    }
}
