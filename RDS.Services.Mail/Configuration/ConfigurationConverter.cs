using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace RDS.Services.Mail.Configuration
{
    internal class ConfigurationConverter
    {
        MailServiceOptions _options;
        MailServiceJsonConfiguration _jsonOptions;

        public MailServiceOptions Convert(MailServiceJsonConfiguration jsonOptions)
        {
            _jsonOptions = jsonOptions;
            _options = new MailServiceOptions();
            LoadSenderOptions();
            LoadFillerOptions();
            LoadTemplateOptions();
            return _options;
        }

        private void LoadFillerOptions()
        {
            if (string.IsNullOrEmpty(_jsonOptions.FromAddress) == false)
                _options.Filler.UseFromAddress = new MailAddress(_jsonOptions.FromAddress, _jsonOptions.FromDisplayName);

            if (_jsonOptions.UseToAddresses != null)
                for (int i = 0; i < _jsonOptions.UseToAddresses.Length; i++)
                {
                    MailAddress address = new MailAddress(_jsonOptions.UseToAddresses[i].Address, _jsonOptions.UseToAddresses[i].Display);
                    _options.Filler.UseToAddresses.Add(address);
                }

            if (_jsonOptions.AddCCAddresses != null)
                for (int i = 0; i < _jsonOptions.AddCCAddresses.Length; i++)
                {
                    MailAddress address = new MailAddress(_jsonOptions.AddCCAddresses[i].Address, _jsonOptions.AddCCAddresses[i].Display);
                    _options.Filler.AddCCAddresses.Add(address);
                }
        }

        private void LoadSenderOptions()
        {
            _options.Sender.SmtpHost = _jsonOptions.SmtpHost;
            _options.Sender.SmtpPort = _jsonOptions.SmtpPort;
            if (string.IsNullOrEmpty(_jsonOptions.SmtpUserName) == false)
                _options.Sender.SmtpCredential = new NetworkCredential(_jsonOptions.SmtpUserName, _jsonOptions.SmtpPassword);
        }

        public virtual void LoadTemplateOptions()
        {
            if (string.IsNullOrEmpty(_jsonOptions.Template.Prefix) == false)
                _options.Filler.Prefix = _jsonOptions.Template.Prefix;

            if (string.IsNullOrEmpty(_jsonOptions.Template.Suffix) == false)
                _options.Filler.Suffix = _jsonOptions.Template.Suffix;

            if (_jsonOptions.Template.Variables != null)
                _jsonOptions.Template.Variables.ToList().ForEach(v => _options.Filler.Variables[v.Name] = v.Value);

            if (_jsonOptions.Template.MailTemplates != null)
                _jsonOptions.Template.MailTemplates.ToList().ForEach(t =>
                {
                    if (string.IsNullOrEmpty(t.Path))
                        LoadMailTemplate(t);
                    else
                        LoadFileMailTemplate(t);
                });
        }

        private void LoadFileMailTemplate(MailTemplateConfig mailTemplateConfig)
        {
            FileMailTemplate template = new FileMailTemplate()
            {
                IsBodyHtml = mailTemplateConfig.IsBodyHtml,
                Name = mailTemplateConfig.Name,
                Path = mailTemplateConfig.Path,
                Subject = mailTemplateConfig.Subject
            };

            _options.Template.AddPrototype(template);
        }

        private void LoadMailTemplate(MailTemplateConfig mailTemplateConfig)
        {
            MailTemplate template = new MailTemplate()
            {
                IsBodyHtml = mailTemplateConfig.IsBodyHtml,
                Name = mailTemplateConfig.Name,
                Subject = mailTemplateConfig.Subject,
                Body = mailTemplateConfig.Body
            };

            _options.Template.AddPrototype(template);
        }
    }
}
