using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Mail;

namespace RDS.Services.Mail.Filler
{
    public interface IMailMessageFillerOptions
    {
        List<MailAddress> AddCCAddresses { get; }
        MailAddress UseFromAddress { get; set; }
        List<MailAddress> UseToAddresses { get; }
        string Prefix { get; set; }
        string Suffix { get; set; }
        ConcurrentDictionary<string, string> Variables { get; }
    }
}