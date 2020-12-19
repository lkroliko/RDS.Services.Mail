using FluentAssertions;
using Moq;
using RDS.Services.Mail.Factory;
using RDS.Services.Mail.Filler;
using System.Net.Mail;
using Xunit;

namespace RDS.Services.Mail.Tests.Unit.Core.MailServiceTests
{
    [Trait("Category", "MailService")]
    public class AddRecipient
    {
        private readonly IMailService _service;
        private readonly ITemplateFactory _factory = Mock.Of<ITemplateFactory>();
        private readonly IMailMessageFiller _filler = Mock.Of<IMailMessageFiller>();
        private readonly MailMessage _template = new MailMessage();
        private readonly string _templateName = "any";

        public AddRecipient()
        {
            Mock.Get(_factory).Setup(f => f.Get(It.IsAny<string>())).Returns(_template);
            _service = new MailService(_factory, _filler, null);
            _service.LoadTemplate(_templateName);
        }

        [Fact]
        public void WhenCalledTemplateToAddressAdded()
        {
            var email = "email@host.local";

            _service.AddRecipient(email);

            _service.MessageTemplate.To.Should().Contain(email);
        }
    }
}
