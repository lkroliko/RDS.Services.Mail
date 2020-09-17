using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;

namespace RDS.Services.Mail.Factory
{
    public class TemplateFactoryOptionsBuilder
    {
        internal ITemplateFactoryOptions Options { get; set; } = MailService.Options.Template;

        internal TemplateFactoryOptionsBuilder() { }

        public TemplateFactoryOptionsBuilder AddTemplate(IMailTemplate template)
        {
            Options.AddPrototype(template);
            return this;
        }

        public TemplateFactoryOptionsBuilder AddTemplates(IMailTemplate []templates)
        {
            foreach(IMailTemplate template in templates)
                Options.AddPrototype(template);
            return this;
        }
    }
}
