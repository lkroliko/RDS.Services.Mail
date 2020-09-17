using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace RDS.Services.Mail
{
    internal class MailServiceJsonOptions
    {
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
        public List<string> AddCCAddresses { get; } = new List<string>();
        public string SenderAddress { get; set; }
        public string SenderDisplayName { get; set; }
        public List<string> ToAddresses { get; } = new List<string>();
        public string TemplatePrefix { get; set; }
        public string TemplateSuffix { get; set; }
        public List<MailTemplate> MailTemplates { get; } = new List<MailTemplate>();

        public static implicit operator MailServiceOptions(MailServiceJsonOptions jsonOptions)
        {
            MailServiceOptions options = new MailServiceOptions();
            options.Filler.Prefix = jsonOptions.TemplatePrefix;
            options.Filler.Suffix = jsonOptions.TemplateSuffix;
            CreateAddresses(options.Filler.AddCCAddresses, jsonOptions.AddCCAddresses);
            CreateAddresses(options.Filler.UseToAddresses, jsonOptions.ToAddresses);
            options.Sender.SmtpHost = jsonOptions.SmtpHost;
            options.Sender.SmtpPort = jsonOptions.SmtpPort;
            options.Filler.UseFromAddress = CreateFromAddress();
            options.Sender.SmtpCredential = new NetworkCredential(jsonOptions.SmtpUsername, jsonOptions.SmtpPassword);
            return options;

            MailAddress CreateFromAddress()
            {
                if (string.IsNullOrEmpty(jsonOptions.SenderAddress) == false)
                    return new MailAddress(jsonOptions.SenderAddress, jsonOptions.SenderDisplayName);
                return null;
            }

            void CreateAddresses(List<MailAddress> desination, List<string> source)
            {
                foreach (string address in source)
                    desination.Add(new MailAddress(address));
            }
        }
    }
}
