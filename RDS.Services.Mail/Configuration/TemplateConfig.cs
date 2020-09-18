using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace RDS.Services.Mail.Configuration
{
    public class TemplateConfig
    {
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public Variable[] Variables { get; set; }
        public MailTemplateConfig[] MailTemplates { get; set; }
    }
}