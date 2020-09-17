using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace RDS.Services.Mail
{
    public class MailTemplate : IMailTemplate
    {
        private string _name;
        public string Name { get { return _name; } set { SetName(value); } }
        public string Subject { get; set; }
        public virtual string Body { get; set; }
        public bool IsBodyHtml { get; set; } = true;

        private void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Template name is null or empty.", nameof(name));
            _name = name;
        }
    }
}
