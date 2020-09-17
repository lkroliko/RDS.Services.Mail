using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace RDS.Services.Mail.Configuration
{
    public class MailServiceJsonConfiguration
    {
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUserName { get; set; }
        public string SmtpPassword { get; set; }
        public string FromAddress { get; set; }
        public string FromDisplayName { get; set; }
        public MailAddressConfig[] UseToAddresses { get; set; }
        public MailAddressConfig[] AddCCAddresses { get; set; }
        public TemplateConfig Template { get; set; }
    }
}