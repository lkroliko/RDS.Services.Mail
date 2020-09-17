using RDS.Services.Mail;
using RDS.Services.Mail.Tests.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ServicesMailTest.Mail
{
    [Trait("Category", "MailServiceOptionsBuilder")]
    public class ConfigureFiller
    {
        MailServiceOptionsBuilder _builder = new MailServiceOptionsBuilder();

        [Fact]
        public void ItSetSettings()
        {
            _builder.ConfigureFiller("prefix", "suffix");

            Assert.Equal("prefix", _builder.Options.Filler.Prefix);
            Assert.Equal("suffix", _builder.Options.Filler.Suffix);
        }
    }
}
