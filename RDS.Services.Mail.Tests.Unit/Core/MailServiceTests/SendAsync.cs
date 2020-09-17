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
    public class SendAsync
    {
        MailService _service;
        IMailSender _sender = Mock.Of<IMailSender>();
        IMailMessageFiller _filler = Mock.Of<IMailMessageFiller>();
        ITemplateFactory _factory = Mock.Of<ITemplateFactory>();
        MailMessage _message = new MailMessage();
        object _object = new object();

        public SendAsync()
        {
            _service = new MailService(_factory, _filler, _sender);
        }

        [Fact]
        public async Task ItHasMethod()
        {
            await _service.SendAsync(new MailMessage());
        }

        [Fact]
        public async Task GivenMessageThenCallFillerFillFromAddressAndSenderSendAsync()
        {
            await _service.SendAsync(_message);

            Mock.Get(_filler).Verify(f => f.FillFromAddress(_message), Times.Once);
            Mock.Get(_sender).Verify(s => s.SendAsync(_message), Times.Once);
        }
    }
}
