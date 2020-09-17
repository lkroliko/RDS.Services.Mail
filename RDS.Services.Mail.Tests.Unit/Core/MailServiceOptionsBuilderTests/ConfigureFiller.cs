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
    public class ConfigureFiller : IClassFixture<MailServiceOptionsFixture>
    {
        IMailServiceOptions _options;
        MailServiceOptionsBuilder _builder;

        public ConfigureFiller(MailServiceOptionsFixture fixture)
        {
            _options = fixture.ServiceOptions;
            _builder = new MailServiceOptionsBuilder() { Options = _options };
        }

        [Fact]
        public void ItSetSettings()
        {
            _builder.ConfigureFiller("prefix", "suffix");

            Assert.Equal("prefix", _options.Filler.Prefix);
            Assert.Equal("suffix", _options.Filler.Suffix);
        }
    }
}
