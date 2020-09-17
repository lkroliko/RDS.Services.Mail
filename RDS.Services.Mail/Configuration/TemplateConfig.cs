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

        public virtual void Load()
        {
            if (string.IsNullOrEmpty(Prefix) == false)
                MailService.Options.Filler.Prefix = Prefix;

            if (string.IsNullOrEmpty(Suffix) == false)
                MailService.Options.Filler.Suffix = Suffix;

            if (Variables != null)
                for (int i = 0; i < Variables.Length; i++)
                {
                    MailService.Options.Filler.Variables[Variables[i].Name] = Variables[i].Value;
                }

            LoadTemplates();
        }

        private void LoadTemplates()
        {
            if (MailTemplates != null)
                for (int i = 0; i < MailTemplates.Length; i++)
                    if (string.IsNullOrEmpty(MailTemplates[i].Path))
                        LoadMailTemplate(MailTemplates[i]);
                    else
                        LoadFileMailTemplate(MailTemplates[i]);
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

            MailService.Options.Template.AddPrototype(template);
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

            MailService.Options.Template.AddPrototype(template);
        }
    }
}