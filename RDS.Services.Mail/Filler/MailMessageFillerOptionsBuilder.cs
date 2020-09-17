using System;
using System.Collections.Generic;
using System.Text;

namespace RDS.Services.Mail.Filler
{
    public class MailMessageFillerOptionsBuilder
    {
        internal IMailMessageFillerOptions Options = MailService.Options.Filler;

        public MailMessageFillerOptionsBuilder AddVariable(string name, string value)
        {
            Options.Variables[name] = value;
            return this;
        }
    }
}
