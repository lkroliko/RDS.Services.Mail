using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;


namespace RDS.Services.Mail.Factory
{
    public class TemplateFactory : ITemplateFactory
    {
        public ITemplateFactoryOptions Options { get; set; } = MailService.Options.Template;

        public MailMessage Get(string name)
        {
            return Copy(Options.GetPrototype(name));
        }

        private MailMessage Copy(IMailTemplate template)
        {
            return new MailMessage()
            {
                Subject = template.Subject,
                Body = template.Body,
                IsBodyHtml = template.IsBodyHtml
            };
        }
    }
}
