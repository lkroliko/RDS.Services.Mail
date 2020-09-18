using Moq;
using RDS.Services.Mail.Configuration;
using RDS.Services.Mail.Templates;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Text;
using Xunit;

namespace RDS.Services.Mail.Tests.Unit.Configuration.ConfigurationConverterTests
{
    [Trait("Category", "ConfigurationConverter")]
    public class Convert
    {
        IMailTemplateFactory _mailTemplateFactory = Mock.Of<IMailTemplateFactory>();
        IFileMailTemplate _fileMailTemplate = Mock.Of<IFileMailTemplate>();
        IMailTemplate _mailTemplate = Mock.Of<IMailTemplate>();
        ConfigurationConverter _converter;
        MailServiceJsonConfiguration _configuration = new MailServiceJsonConfiguration();

        public Convert()
        {
            Mock.Get(_fileMailTemplate).SetupAllProperties();
            Mock.Get(_mailTemplate).SetupAllProperties();
            Mock.Get(_mailTemplateFactory).Setup(f => f.GetFileMailTemplate()).Returns(_fileMailTemplate);
            Mock.Get(_mailTemplateFactory).Setup(f => f.GetMailTemplate()).Returns(_mailTemplate);
            _converter = new ConfigurationConverter(_mailTemplateFactory);
            _configuration.Template = new TemplateConfig();
        }

        [Fact]
        public void ItExists()
        {
            _converter.Convert(_configuration);
        }

        [Fact]
        public void ItSetSmtpHostOption()
        {
            _configuration.SmtpHost = "host.local";

            var result = _converter.Convert(_configuration);

            Assert.Equal("host.local", result.Sender.SmtpHost);
        }

        [Fact]
        public void ItSetSmtpPortOption()
        {
            _configuration.SmtpPort = 454;

            var result = _converter.Convert(_configuration);

            Assert.Equal(454, result.Sender.SmtpPort);
        }

        [Fact]
        public void ItSetSmtpUserNameOption()
        {
            _configuration.SmtpUserName = "user name";

            var result = _converter.Convert(_configuration);

            Assert.Equal("user name", result.Sender.SmtpCredential.UserName);
        }

        [Fact]
        public void ItSetSmtpPasswordOption()
        {
            _configuration.SmtpUserName = "user name";
            _configuration.SmtpPassword = "password";

            var result = _converter.Convert(_configuration);

            Assert.Equal("password", result.Sender.SmtpCredential.Password);
        }

        [Fact]
        public void WhenSmtpUserNameIsNullThenSmtpCredentialOptionIsNull()
        {
            var result = _converter.Convert(_configuration);

            Assert.Null(result.Sender.SmtpCredential);
        }

        [Fact]
        public void ItSetUseFromAddressOption()
        {
            _configuration.FromAddress = "address@host.local";
            _configuration.FromDisplayName = "display";

            var result = _converter.Convert(_configuration);

            Assert.Equal("address@host.local", result.Filler.UseFromAddress.Address);
            Assert.Equal("display", result.Filler.UseFromAddress.DisplayName);
        }

        [Fact]
        public void ItSetUseToAddressesOption()
        {
            MailAddressConfig address = new MailAddressConfig()
            {
                Address = "to@host.local",
                Display = "To"
            };
            _configuration.UseToAddresses = new[] { address };

            var result = _converter.Convert(_configuration);

            Assert.Equal(address.Address, result.Filler.UseToAddresses[0].Address);
            Assert.Equal(address.Display, result.Filler.UseToAddresses[0].DisplayName);
        }

        [Fact]
        public void ItSetAddCCAddressesOption()
        {
            MailAddressConfig address = new MailAddressConfig()
            {
                Address = "cc@host.local",
                Display = "cc"
            };
            _configuration.AddCCAddresses = new[] { address };

            var result = _converter.Convert(_configuration);

            Assert.Equal(address.Address, result.Filler.AddCCAddresses[0].Address);
            Assert.Equal(address.Display, result.Filler.AddCCAddresses[0].DisplayName);
        }

        [Fact]
        public void GivenTemplatePrefixThenOptionSeated()
        {
            _configuration.Template.Prefix = "prefix";

            var result = _converter.Convert(_configuration);

            Assert.Equal("prefix", result.Filler.Prefix);
        }

        [Fact]
        public void GivernTemplateSuffixThenOptionSeated()
        {
            _configuration.Template.Suffix = "suffix";

            var result = _converter.Convert(_configuration);

            Assert.Equal("suffix", result.Filler.Suffix);
        }

        [Fact]
        public void GivenTemplateVariableThenOptionSeated()
        {
            _configuration.Template.Variables = new Variable[] { new Variable() { Name = "name", Value = "value" } };

            var result = _converter.Convert(_configuration);

            Assert.Equal("value", result.Filler.Variables["name"]);
        }

        [Fact]
        public void GivenFileMailTemplateThenTemplateOptionSeted()
        {
            MailTemplateConfig fileTemplate = new MailTemplateConfig()
            {
                Name = "file",
                IsBodyHtml = true,
                Path = "path"
            };
            _configuration.Template.MailTemplates = new[] { fileTemplate };

            var result = _converter.Convert(_configuration);

            Assert.True(result.Template.GetPrototype("file").IsBodyHtml);
            Assert.NotNull(result.Template.GetPrototype("file"));
        }

        [Fact]
        public void GivenMailTemplateThenTemplateOptionSeted()
        {
            MailTemplateConfig template = new MailTemplateConfig()
            {
                Name = "template",
                IsBodyHtml = true,
                Subject = "subject",
                Body = "body"
            };
            _configuration.Template.MailTemplates = new[] { template };

            var result = _converter.Convert(_configuration);

            Assert.True(result.Template.GetPrototype("template").IsBodyHtml);
            Assert.Equal("body", result.Template.GetPrototype("template").Body);
            Assert.Equal("subject", result.Template.GetPrototype("template").Subject);
        }
    }
}
