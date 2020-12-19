using Moq;
using RDS.Services.Mail;
using RDS.Services.Mail.Factory;
using RDS.Services.Mail.Filler;
using RDS.Services.Mail.Sender;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MailServiceTest.MailServiceTests
{
    [Trait("Category", "MailService")]
    public class SendTemplateAsync
    {
        MailService _service;
        IMailSender _sender = Mock.Of<IMailSender>();
        IMailMessageFiller _filler = Mock.Of<IMailMessageFiller>();
        ITemplateFactory _factory = Mock.Of<ITemplateFactory>();
        MailMessage _template = new MailMessage();
        string _templateName = "any";
        object _object = new object();

        public SendTemplateAsync()
        {
            Mock.Get(_factory).Setup(f => f.Get(It.IsAny<string>())).Returns(_template);
            _service = new MailService(_factory, _filler, _sender);
            _service.LoadTemplate(_templateName);
        }

        [Fact]
        public async Task ItHasMethod()
        {
            await _service.SendTemplateAsync();
        }

        [Fact]
        public async Task GivenMessageThenCallFillerFillFromAddressAndSenderSendAsync()
        {
            await _service.SendTemplateAsync();

            Mock.Get(_sender).Verify(s => s.SendAsync(_template), Times.Once);
        }
    }
}
