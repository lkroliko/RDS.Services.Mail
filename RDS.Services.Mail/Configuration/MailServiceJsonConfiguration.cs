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

        public void Load()
        {
            MailService.Options.Sender.SmtpHost = SmtpHost;
            MailService.Options.Sender.SmtpPort = SmtpPort;
            if (string.IsNullOrEmpty(SmtpUserName) == false)
                MailService.Options.Sender.SmtpCredential = new NetworkCredential(SmtpUserName, SmtpPassword);

            if (string.IsNullOrEmpty(FromAddress) == false)
                MailService.Options.Filler.UseFromAddress = new MailAddress(FromAddress, FromDisplayName);

            if (UseToAddresses != null)
                for (int i = 0; i < UseToAddresses.Length; i++)
                {
                    MailAddress address = new MailAddress(UseToAddresses[i].Address, UseToAddresses[i].Display);
                    MailService.Options.Filler.UseToAddresses.Add(address);
                }

            if (AddCCAddresses != null)
                for (int i = 0; i < AddCCAddresses.Length; i++)
                {
                    MailAddress address = new MailAddress(AddCCAddresses[i].Address, AddCCAddresses[i].Display);
                    MailService.Options.Filler.AddCCAddresses.Add(address);
                }

            if (Template != null)
                Template.Load();
        }
    }
}