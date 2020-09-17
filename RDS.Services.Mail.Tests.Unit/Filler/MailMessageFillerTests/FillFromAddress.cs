using Moq;
using RDS.Services.Mail.Filler;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Xunit;

namespace RDS.Services.Mail.Tests.Unit.Filler.MailMessageFillerTests
{
    [Trait("Category", "MailMessageFiller")]
    public class FillFromAddress : IClassFixture<MailServiceOptionsFixture>
    {
        IMailMessageFiller _filler;
        IMailMessageFillerOptions _options;
        MailMessage _message;
        MailAddress _from;

        public FillFromAddress(MailServiceOptionsFixture fixture)
        {
            _from = new MailAddress("from@host.local");
            _message = new MailMessage();
            _options = fixture.FillerOptions;
            _filler = new MailMessageFiller() { Options = _options };

            Mock.Get(_options).Setup(o => o.UseFromAddress).Returns(_from);
        }

        [Fact]
        public void ItHasMethod()
        {
            _filler.FillFromAddress(new MailMessage());
        }

        [Fact]
        public void GivenMessageThenFromAddressSeted()
        {
            Mock.Get(_options).Setup(o => o.UseFromAddress).Returns(_from);

            _filler.FillFromAddress(_message);

            Assert.Equal(_from, _message.From);
        }
    }
}
