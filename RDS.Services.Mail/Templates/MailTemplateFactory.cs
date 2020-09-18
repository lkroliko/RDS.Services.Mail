using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Text;

namespace RDS.Services.Mail.Templates
{
    internal class MailTemplateFactory : IMailTemplateFactory
    {
        public IMailTemplate GetMailTemplate()
        {
            return new MailTemplate();
        }

        public IFileMailTemplate GetFileMailTemplate()
        {
            return new FileMailTemplate(new FileSystem());
        }
    }
}
