using System;
using System.Collections.Generic;
using System.Text;

namespace RDS.Services.Mail.Filler
{
    public class MailMessageFillerOptionsBuilder
    {
        IMailMessageFillerOptions _options;

        public MailMessageFillerOptionsBuilder()
        {
            _options = new MailMessageFillerOptions();
        }

        public MailMessageFillerOptionsBuilder AddVariable(string name, string value)
        {
            _options.Variables[name] = value;
            return this;
        }

        internal IMailMessageFillerOptions Build()
        {
            return _options;
        }
    }
}
