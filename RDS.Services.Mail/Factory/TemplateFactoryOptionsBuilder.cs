using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace RDS.Services.Mail.Factory
{
    public class TemplateFactoryOptionsBuilder
    {
        ITemplateFactoryOptions _options;

        internal TemplateFactoryOptionsBuilder(ITemplateFactoryOptions options) 
        {
            _options = options;
        }

        public TemplateFactoryOptionsBuilder AddTemplate(IMailTemplate template)
        {
            _options.AddPrototype(template);
            return this;
        }

        public TemplateFactoryOptionsBuilder AddTemplates(IMailTemplate []templates)
        {
            foreach(IMailTemplate template in templates)
                _options.AddPrototype(template);
            return this;
        }
    }
}
