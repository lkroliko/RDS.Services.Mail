using System;
using System.Collections.Generic;
using System.Text;

namespace RDS.Services.Mail.Configuration
{
    public class MailTemplateConfig
    {
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsBodyHtml { get; set; } = true;
        public string Path { get; set; }
    }
}
