using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Data;
using System.Xml.Serialization;

namespace RDS.Services.Mail.Filler
{
    public class MailMessageFiller : IMailMessageFiller
    {
        public IMailMessageFillerOptions Options = MailService.Options.Filler;

        public void Fill(MailMessage message)
        {
            ReplaceFromAddress(message);
            ReplaceToAddresses(message);
            AddCCAddresses(message);
            FillWithVariables(message);
        }

        public void Fill(MailMessage message, object model)
        {
            Fill(message);
            FillWithModel(message, model);           
        }

        public void FillFromAddress(MailMessage message)
        {
            ReplaceFromAddress(message);
        }

        private void FillWithModel(MailMessage message, object model)
        {
            message.Subject = FillWithModel(message.Subject, model);
            message.Body = FillWithModel(message.Body, model);
        }

        private void FillWithVariables(MailMessage message)
        {
            message.Subject = FillWithVariables(message.Subject);
            message.Body = FillWithVariables(message.Body);
        }

        private string FillWithVariables(string template)
        {
            foreach (Match match in Regex.Matches(template, GetPattern()))
                if (Options.Variables.ContainsKey(match.Value))
                    template = template.Replace(match.Value, Options.Variables[match.Value]);

            return template;
        }

        private string FillWithModel(string template, object model)
        {
            PropertyInfo[] propertysInfo = model.GetType().GetProperties();

            foreach (Match match in Regex.Matches(template, GetPattern()))
            {
                string propertyName = RemovePrefixAndSuffix(match.Value);
                var propertyInfo = propertysInfo.FirstOrDefault(p => p.Name == RemovePrefixAndSuffix(match.Value));
                if (propertyInfo != null)
                    template = Replace(template, propertyInfo, model);
            }

            return template;
        }

        private string Replace(string template, PropertyInfo propertyInfo, object model)
        {
            return template.Replace($"{Options.Prefix}{propertyInfo.Name}{Options.Suffix}",
                GetValue(propertyInfo, model).ToString());
        }

        private string GetValue(PropertyInfo propertyInfo, object model)
        {
            return propertyInfo.GetValue(model).ToString();
        }

        private void ReplaceFromAddress(MailMessage message)
        {
            if (Options.UseFromAddress != null)
                message.From = Options.UseFromAddress;
        }

        private void ReplaceToAddresses(MailMessage message)
        {
            if (Options.UseToAddresses != null && Options.UseToAddresses.Count > 0)
            {
                message.To.Clear();
                foreach (MailAddress address in Options.UseToAddresses)
                    message.To.Add(address);
            }
        }

        private void AddCCAddresses(MailMessage message)
        {
            foreach (var address in Options.AddCCAddresses)
                message.CC.Add(address);
        }

        private string GetPattern()
        {
            return $"{Options.Prefix}\\w*{Options.Suffix}";
        }

        private string RemovePrefixAndSuffix(string value)
        {
            return value.Substring(
                Options.Prefix.Length, value.Length
                - Options.Suffix.Length
                - Options.Prefix.Length);
        }
    }
}
