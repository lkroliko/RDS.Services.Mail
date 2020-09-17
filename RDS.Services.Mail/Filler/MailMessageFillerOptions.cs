using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace RDS.Services.Mail.Filler
{
    public class MailMessageFillerOptions : IMailMessageFillerOptions
    {
        public List<MailAddress> AddCCAddresses { get; } = new List<MailAddress>();
        public MailAddress UseFromAddress { get; set; }
        public List<MailAddress> UseToAddresses { get; } = new List<MailAddress>();
        public string Prefix { get; set; } = "<%";
        public string Suffix { get; set; } = "%>";
        public ConcurrentDictionary<string, string> Variables { get; } = new ConcurrentDictionary<string, string>();
    }
}
