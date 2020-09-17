using Moq;
using RDS.Services.Mail.Filler;
using RDS.Services.Mail.Sender;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Xunit;

namespace RDS.Services.Mail.Tests.Unit.MailServiceTests
{
    [Trait("Category", "MailService")]
    public class FillAndSend
    {
        IMailService _service;
        IMailMessageFiller _filler;
        IMailSender _sender;
        MailMessage _message;
        object _model;

        public FillAndSend()
        {
            _model = new object();
            _message = new MailMessage();
            _sender = Mock.Of<IMailSender>();
            _filler = Mock.Of<IMailMessageFiller>();
            _service = new MailService(null, _filler, _sender);
        }

        [Fact]
        public void ItHasMethod()
        {
            _service.FillAndSend(_message);
            _service.FillAndSend(_message, _model);
        }

        [Fact]
        public void GivenMessageThenFillerFillAndSenderSendCalled()
        {
            ClearInvocations();

            _service.FillAndSend(_message);

            Mock.Get(_filler).Verify(f => f.Fill(_message), Times.Once);
            Mock.Get(_sender).Verify(s => s.Send(_message), Times.Once);
        }

        [Fact]
        public void GivenMessageAndModelThenFillerFillAndSenderSendCalled()
        {
            ClearInvocations();

            _service.FillAndSend(_message, _model);

            Mock.Get(_filler).Verify(f => f.Fill(_message, _model), Times.Once);
            Mock.Get(_sender).Verify(s => s.Send(_message), Times.Once);
        }

        private void ClearInvocations()
        {
            Mock.Get(_filler).Invocations.Clear();
            Mock.Get(_sender).Invocations.Clear();
        }
    }
}
