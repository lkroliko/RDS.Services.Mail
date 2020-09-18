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
        ITemplateFactoryOptions _options;

        public TemplateFactory (ITemplateFactoryOptions options)
        {
            _options = options;
        }

        public MailMessage Get(string name)
        {
            return Create(_options.GetPrototype(name));
        }

        private MailMessage Create(IMailTemplate template)
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
