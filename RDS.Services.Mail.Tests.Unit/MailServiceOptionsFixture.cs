using Moq;
using RDS.Services.Mail;
using RDS.Services.Mail.Factory;
using RDS.Services.Mail.Filler;
using RDS.Services.Mail.Sender;
using System;
using System.Collections.Generic;
using System.Text;

namespace RDS.Services.Mail.Tests.Unit
{
    public class MailServiceOptionsFixture
    {
        public IMailServiceOptions ServiceOptions;
        public IMailMessageFillerOptions FillerOptions;
        public IMailSenderOptions SenderOptions;
        public ITemplateFactoryOptions TemplateOptions;

        public MailServiceOptionsFixture()
        {
            MailService.Options = ServiceOptions = Mock.Of<IMailServiceOptions>();
            FillerOptions = Mock.Of<IMailMessageFillerOptions>();
            SenderOptions = Mock.Of<IMailSenderOptions>();
            TemplateOptions = Mock.Of<ITemplateFactoryOptions>();

            Mock.Get(ServiceOptions).Setup(o => o.Filler).Returns(FillerOptions);
            Mock.Get(ServiceOptions).Setup(o => o.Sender).Returns(SenderOptions);
            Mock.Get(ServiceOptions).Setup(o => o.Filler).Returns(FillerOptions);
            Mock.Get(ServiceOptions).Setup(o => o.Template).Returns(TemplateOptions);
        }
    }
}
