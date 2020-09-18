using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Data;
using System.Xml.Serialization;
using System.Runtime.InteropServices.ComTypes;

namespace RDS.Services.Mail.Filler
{
    public class MailMessageFiller : IMailMessageFiller
    {
        IMailMessageFillerOptions _options;

        public MailMessageFiller(IMailMessageFillerOptions options)
        {
            _options = options;
        }

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
                if (_options.Variables.ContainsKey(match.Value))
                    template = template.Replace(match.Value, _options.Variables[match.Value]);

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
            return template.Replace($"{_options.Prefix}{propertyInfo.Name}{_options.Suffix}",
                GetValue(propertyInfo, model).ToString());
        }

        private string GetValue(PropertyInfo propertyInfo, object model)
        {
            return propertyInfo.GetValue(model).ToString();
        }

        private void ReplaceFromAddress(MailMessage message)
        {
            if (_options.UseFromAddress != null)
                message.From = _options.UseFromAddress;
        }

        private void ReplaceToAddresses(MailMessage message)
        {
            if (_options.UseToAddresses != null && _options.UseToAddresses.Count > 0)
            {
                message.To.Clear();
                foreach (MailAddress address in _options.UseToAddresses)
                    message.To.Add(address);
            }
        }

        private void AddCCAddresses(MailMessage message)
        {
            foreach (var address in _options.AddCCAddresses)
                message.CC.Add(address);
        }

        private string GetPattern()
        {
            return $"{_options.Prefix}\\w*{_options.Suffix}";
        }

        private string RemovePrefixAndSuffix(string value)
        {
            return value.Substring(
                _options.Prefix.Length, value.Length
                - _options.Suffix.Length
                - _options.Prefix.Length);
        }
    }
}
