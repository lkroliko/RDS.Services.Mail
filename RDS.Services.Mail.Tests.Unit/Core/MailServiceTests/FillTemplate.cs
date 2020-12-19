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
    public class FillTemplate
    {
        IMailService _service;
        IMailMessageFiller _filler;
        MailMessage _message;
        object _model;

        public FillTemplate()
        {
            _message = new MailMessage();
            _model = new object();
            _filler = Mock.Of<IMailMessageFiller>();
            _service = new MailService(null, _filler, null); 
        }

        [Fact]
        public void ItHasMethod()
        {
            _service.FillTemplate(_model);
        }

        [Fact]
        public void GivemModelThenMailMessageFillerCalled()
        {
            _service.FillTemplate(_model);

            Mock.Get(_filler).Verify(f => f.Fill(_service.MessageTemplate, _model), Times.Once);
        }
    }
}
