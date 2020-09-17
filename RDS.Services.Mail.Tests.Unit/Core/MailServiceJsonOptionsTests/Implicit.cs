//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Xunit;

//namespace RDS.Services.Mail.Tests.Unit.MailServiceJsonOptionsTests
//{
//    [Trait("Category", "MailServiceJsonOptions")]
//    public class Impicit
//    {
//        MailServiceOptions _options;
//        MailServiceJsonOptions _jsonOptions = new MailServiceJsonOptions();

//        public Impicit()
//        {
//            _jsonOptions.AddCCAddresses.Add("cc1@host.local");
//            _jsonOptions.AddCCAddresses.Add("cc2@host.local");
//            _jsonOptions.SenderAddress = "sender@host.local";
//            _jsonOptions.SenderDisplayName = "Sender";
//            _jsonOptions.SmtpHost = "host.local";
//            _jsonOptions.SmtpPort = 443;
//            _jsonOptions.TemplatePrefix = "prefix";
//            _jsonOptions.TemplateSuffix = "suffix";
//            _jsonOptions.ToAddresses.Add("to1@host.local");
//            _jsonOptions.ToAddresses.Add("to2@host.local");
//            _jsonOptions.SmtpUsername = "username";
//            _jsonOptions.SmtpPassword = "p@ssw0rd";
//        }

//        [Fact]
//        public void ItHasImplicitOperator()
//        {
//            _options = _jsonOptions;
//        }

//        [Fact]
//        public void GivenJsonOptionsThenOptionsReturned()
//        {
//            _options = _jsonOptions;

//            Assert.Equal(_jsonOptions.AddCCAddresses.First(), _options.Filler.AddCCAddresses.First().Address);
//            Assert.Equal(_jsonOptions.AddCCAddresses.Last(), _options.Filler.AddCCAddresses.Last().Address);
//            Assert.Equal(_jsonOptions.SenderAddress, _options.Filler.UseFromAddress.Address);
//            Assert.Equal(_jsonOptions.SenderDisplayName, _options.Filler.UseFromAddress.DisplayName);
//            Assert.Equal(_jsonOptions.SmtpHost, _options.Sender.SmtpHost);
//            Assert.Equal(_jsonOptions.SmtpPort, _options.Sender.SmtpPort);
//            Assert.Equal(_jsonOptions.TemplatePrefix, _options.Filler.Prefix);
//            Assert.Equal(_jsonOptions.TemplateSuffix, _options.Filler.Suffix);
//            Assert.Equal(_jsonOptions.ToAddresses.First(), _options.Filler.UseToAddresses.First().Address);
//            Assert.Equal(_jsonOptions.ToAddresses.Last(), _options.Filler.UseToAddresses.Last().Address);
//            Assert.Equal(_jsonOptions.SmtpUsername, _options.Sender.SmtpCredential.UserName);
//            Assert.Equal(_jsonOptions.SmtpPassword, _options.Sender.SmtpCredential.Password);
//        }
//    }
//}