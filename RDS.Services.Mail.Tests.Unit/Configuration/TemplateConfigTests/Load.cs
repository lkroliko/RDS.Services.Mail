using RDS.Services.Mail.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RDS.Services.Mail.Tests.Unit.Configuration.TemplateConfigTests
{
    [Trait("Category", "Configuration")]
    public class Load
    {
        TemplateConfig _config = new TemplateConfig();
        [Fact]
        public void ItExistst()
        {
            _config.Load();
        }

        [Fact]
        public void ItSetAddPrefixOption()
        {
            _config.Prefix = "prefix";

            _config.Load();

            Assert.Equal("prefix", MailService.Options.Filler.Prefix);
        }

        [Fact]
        public void ItSetAddSuffixOption()
        {
            _config.Suffix = "suffix";

            _config.Load();

            Assert.Equal("suffix", MailService.Options.Filler.Suffix);
        }

        [Fact]
        public void ItSetFillerVariablesOption()
        {
            _config.Variables = new Variable[] { new Variable() { Name ="name", Value = "value" } };

            _config.Load();

            Assert.Equal("value", MailService.Options.Filler.Variables["name"]);
        }

        [Fact]
        public void ItSetVariablesOption()
        {
            Variable variable = new Variable()
            {
                Name = "name",
                Value = "value"
            };
            _config.Variables = new[] { variable };

            _config.Load();

            Assert.Equal("value", MailService.Options.Filler.Variables["name"]);
        }

        [Fact]
        public void WhenFileMailTemplateThenTemplateOptionSeted()
        {
            MailTemplateConfig fileTemplate = new MailTemplateConfig()
            {
                Name = "file",
                IsBodyHtml = true,
                Path = "path"
            };
            _config.MailTemplates = new[] { fileTemplate };

            _config.Load();

            Assert.True(MailService.Options.Template.GetPrototype("name").IsBodyHtml);
            Assert.NotNull(MailService.Options.Template.GetPrototype("file"));
        }

        [Fact]
        public void WhenMailTemplateThenTemplateOptionSeted()
        {
            MailTemplateConfig template = new MailTemplateConfig()
            {
                Name = "template",
                IsBodyHtml = true,
                Subject = "subject",
                Body = "body"
            };
            _config.MailTemplates = new[] { template };

            _config.Load();

            Assert.True(MailService.Options.Template.GetPrototype("template").IsBodyHtml);
            Assert.Equal("body", MailService.Options.Template.GetPrototype("template").Body);
            Assert.Equal("subject", MailService.Options.Template.GetPrototype("template").Subject);
        }
    }
}
