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
    public class Send
    {
        MailService _service;
        IMailSender _sender = Mock.Of<IMailSender>();
        IMailMessageFiller _filler = Mock.Of<IMailMessageFiller>();
        ITemplateFactory _factory = Mock.Of<ITemplateFactory>();
        MailMessage _message = new MailMessage();
        object _object = new object();

        public Send()
        {
            _service = new MailService(_factory, _filler, _sender);
        }

        [Fact]
        public void ItHasMethod()
        {
            _service.Send(new MailMessage());
        }

        [Fact]
        public void GivenMessageThenCallFillerFillFromAddressAndSenderSend()
        {
            _service.Send(_message);

            Mock.Get(_filler).Verify(f => f.FillFromAddress(_message), Times.Once);
            Mock.Get(_sender).Verify(s => s.Send(_message), Times.Once);
        }
    }
}
