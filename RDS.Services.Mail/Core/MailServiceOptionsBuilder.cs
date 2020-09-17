
using RDS.Services.Mail.Factory;
using RDS.Services.Mail.Filler;
using System;
using System.Net;
using System.Net.Mail;

namespace RDS.Services.Mail
{
    public class MailServiceOptionsBuilder
    {
        internal IMailServiceOptions Options = MailService.Options;

        internal MailServiceOptionsBuilder() { }

        public MailServiceOptionsBuilder UseSmtpServer(string host, int port = 25)
        {
            Options.Sender.SmtpHost = host;
            Options.Sender.SmtpPort = port;
            return this;
        }

        public MailServiceOptionsBuilder UseSenderAddress(string address, string displayName = null)
        {
            Options.Filler.UseFromAddress = new MailAddress(address, displayName);
            return this;
        }

        public MailServiceOptionsBuilder UseRecipientAddress(string address, string displayName = null)
        {
            Options.Filler.UseToAddresses.Add(new MailAddress(address, displayName));
            return this;
        }

        public MailServiceOptionsBuilder AddCCAddress(string address, string displayName = null)
        {
            Options.Filler.AddCCAddresses.Add(new MailAddress(address, displayName));
            return this;
        }

        public MailServiceOptionsBuilder UseTemplates(Action<TemplateFactoryOptionsBuilder> options)
        {
            options.Invoke(new TemplateFactoryOptionsBuilder());
            return this;
        }

        public MailServiceOptionsBuilder ConfigureFiller(string prefix, string suffix)
        {
            Options.Filler.Prefix = prefix;
            Options.Filler.Suffix = suffix;
            return this;
        }

        public MailServiceOptionsBuilder UseSmtpCredential(string username, string password)
        {
            Options.Sender.SmtpCredential = new NetworkCredential(username, password);
            return this;
        }

        public MailServiceOptionsBuilder UseFiller(Action<MailMessageFillerOptionsBuilder> options)
        {
            options.Invoke(new MailMessageFillerOptionsBuilder());
            return this;
        }
    }
}
