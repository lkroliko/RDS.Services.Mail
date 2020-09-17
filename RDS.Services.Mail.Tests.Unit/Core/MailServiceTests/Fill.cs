using Moq;
using RDS.Services.Mail.Filler;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Xunit;

namespace RDS.Services.Mail.Tests.Unit.MailServiceTests
{
    [Trait("Category", "MailService")]
    public class Fill
    {
        IMailService _service;
        IMailMessageFiller _filler;
        MailMessage _message;
        object _model;
        public Fill()
        {
            _message = new MailMessage();
            _model = new object();
            _filler = Mock.Of<IMailMessageFiller>();
            _service = new MailService(null, _filler, null);
            
        }

        [Fact]
        public void ItHasMethod()
        {
            _service.Fill(_message,_model);
            _service.Fill(_message);
        }

        [Fact]
        public void GivemMailMessageAndModelThenMessageFilled()
        {
            _service.Fill(_message, _model);

            Mock.Get(_filler).Verify(f => f.Fill(_message, _model), Times.Once);
        }

        [Fact]
        public void GivemMailMessageThenMessageFilled()
        {
            _service.Fill(_message);

            Mock.Get(_filler).Verify(f => f.Fill(_message), Times.Once);
        }
    }
}
