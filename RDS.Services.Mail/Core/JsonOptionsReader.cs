//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Net;
//using System.Text;

//namespace RDS.Services.Mail
//{
//    internal class JsonOptionsReader
//    {
//        internal IMailServiceOptions Options { get; set; }
//        IConfiguration _configuration;

//        internal JsonOptionsReader(IConfiguration configuration)
//        {
//            Options = MailService.Options;
//            _configuration = configuration;
//        }

//        internal void Read()
//        {
//            ReadSenderOptions();
//            ReadFillerOptions();
//            ReadFactoryOptions();
//        }

//        private void ReadSenderOptions()
//        {
//            IConfigurationSection section = _configuration.GetSection("MailService");
//            Options.Sender.SmtpHost = section.GetValue<string>("SmtpHost");
//            Options.Sender.SmtpPort = section.GetValue<int>("SmtpPort");
            
//            string userName = section.GetValue<string>("SmtpUsername");
//            string password = section.GetValue<string>("SmtpPassword");
//            if (string.IsNullOrEmpty(userName) == false)
//                Options.Sender.SmtpCredential = new NetworkCredential(userName, password);
//        }

//        private void ReadFillerOptions()
//        {
//            IConfigurationSection sectionTemplates = _configuration.GetSection("MailService:Templates");
//            Options.Filler.Prefix = sectionTemplates.GetValue<string>("Prefix");
//            Options.Filler.Suffix = sectionTemplates.GetValue<string>("Suffix");

//            foreach (var variable in sectionTemplates.GetSection("Variables").GetChildren())
//                Options.Filler.Variables[variable.GetValue<string>("Variable")] = variable.GetValue<string>("Value");
//        }

//        private void ReadFactoryOptions()
//        {
//            IConfigurationSection section = _configuration.GetSection("MailService:Template:Templates");
//            foreach(var template in section.GetChildren())
//            {
//                string name = template.GetValue<string>("Name");
//                string subject = template.GetValue<string>("Subject");
//                bool isBodyHtml = template.GetValue<bool>("Subject");
//            }
            
//        }
//    }
//}
