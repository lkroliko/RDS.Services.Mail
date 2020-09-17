//using Moq;
//using RDS.Services.Mail.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Net.Mail;
//using System.Text;
//using Xunit;

//namespace RDS.Services.Mail.Tests.Unit.Configuration.MailServiceJsonConfigurationTests
//{
//    [Trait("Category", "Configuration")]
//    public class Load
//    {
//        MailServiceJsonConfiguration _configuration = new MailServiceJsonConfiguration();

//        public Load()
//        {

//        }

//        [Fact]
//        public void ItExists()
//        {
//            _configuration.Load();
//        }

//        [Fact]
//        public void ItSetSmtpHostOption()
//        {
//            _configuration.SmtpHost = "host.local";

//            _configuration.Load();

//            Assert.Equal("host.local", MailService.Options.Sender.SmtpHost);
//        }

//        [Fact]
//        public void ItSetSmtpPortOption()
//        {
//            _configuration.SmtpPort = 454;

//            _configuration.Load();

//            Assert.Equal(454, MailService.Options.Sender.SmtpPort);
//        }

//        [Fact]
//        public void ItSetSmtpUserNameOption()
//        {
//            _configuration.SmtpUserName = "user name";

//            _configuration.Load();

//            Assert.Equal("user name", MailService.Options.Sender.SmtpCredential.UserName);
//        }

//        [Fact]
//        public void ItSetSmtpPasswordOption()
//        {
//            _configuration.SmtpUserName = "user name";
//            _configuration.SmtpPassword = "password";

//            _configuration.Load();

//            Assert.Equal("password", MailService.Options.Sender.SmtpCredential.Password);
//        }

//        [Fact]
//        public void WhenSmtpUserNameIsNullThenSmtpCredentialOptionIsNull()
//        {

//            _configuration.Load();

//            Assert.Null(MailService.Options.Sender.SmtpCredential);
//        }

//        [Fact]
//        public void ItSetUseFromAddressOption()
//        {
//            _configuration.FromAddress = "address@host.local";
//            _configuration.FromDisplayName = "display";

//            _configuration.Load();

//            Assert.Equal("address@host.local", MailService.Options.Filler.UseFromAddress.Address);
//            Assert.Equal("display", MailService.Options.Filler.UseFromAddress.DisplayName);
//        }

//        [Fact]
//        public void ItSetUseToAddressesOption()
//        {
//            MailAddressConfig address = new MailAddressConfig()
//            {
//                Address = "to@host.local",
//                Display = "To"
//            };
//            _configuration.UseToAddresses = new[] { address };

//            _configuration.Load();

//            Assert.Equal(address.Address, MailService.Options.Filler.UseToAddresses[0].Address);
//            Assert.Equal(address.Display, MailService.Options.Filler.UseToAddresses[0].DisplayName);
//        }

//        [Fact]
//        public void ItSetAddCCAddressesOption()
//        {
//            MailAddressConfig address = new MailAddressConfig()
//            {
//                Address = "cc@host.local",
//                Display = "cc"
//            };
//            _configuration.AddCCAddresses = new[] { address };

//            _configuration.Load();

//            Assert.Equal(address.Address, MailService.Options.Filler.AddCCAddresses[0].Address);
//            Assert.Equal(address.Display, MailService.Options.Filler.AddCCAddresses[0].DisplayName);
//        }

//        [Fact]
//        public void ItCallTemplateLoad()
//        {
//            _configuration.Template = Mock.Of<TemplateConfig>();
//            Mock.Get(_configuration.Template).Setup(t => t.Load());

//            _configuration.Load();

//            Mock.Get(_configuration.Template).Verify(t => t.Load(), Times.Once);
//        }
//    }
//}
