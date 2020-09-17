//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Xunit;

//namespace RDS.Services.Mail.Tests.Unit.MailServiceJsonOptionsTests
//{
//    [Trait("Category", "MailServiceJsonOptions")]
//    public class Class
//    {
//        MailServiceJsonOptions _options = new MailServiceJsonOptions();

//        [Fact]
//        public void ItExists()
//        {
//            MailServiceJsonOptions options = new MailServiceJsonOptions();
//        }

//        [Fact]
//        public void ItHasWritableSmtpHostProperty()
//        {
//            var value = "value";

//            _options.SmtpHost = value;

//            Assert.Equal(value, _options.SmtpHost);
//        }

//        [Fact]
//        public void ItHasWritableSmtpPortProperty()
//        {
//            var value = 565;

//            _options.SmtpPort = value;

//            Assert.Equal(value, _options.SmtpPort);
//        }

//        [Fact]
//        public void ItHasWritableSmtpUsernameProperty()
//        {
//            var value = "username";

//            _options.SmtpUsername = value;

//            Assert.Equal(value, _options.SmtpUsername);
//        }

//        [Fact]
//        public void ItHasWritableSmtpPasswordProperty()
//        {
//            var value = "p@ssw0rd";

//            _options.SmtpPassword = value;

//            Assert.Equal(value, _options.SmtpPassword);
//        }

//        [Fact]
//        public void ItHasWritableAddCCAddressesProperty()
//        {
//            var value = "value";

//            _options.AddCCAddresses.Add(value);

//            Assert.Equal(value, _options.AddCCAddresses.First());
//        }

//        [Fact]
//        public void ItHasWritableSenderAddressProperty()
//        {
//            var value = "value";

//            _options.SenderAddress = value;

//            Assert.Equal(value, _options.SenderAddress);
//        }

//        [Fact]
//        public void ItHasWritableToAddressesProperty()
//        {
//            var value = "value";

//            _options.SenderDisplayName = value;

//            Assert.Equal(value, _options.SenderDisplayName);
//        }

//        [Fact]
//        public void ItHasWritableTemplatePrefixProperty()
//        {
//            var value = "value";

//            _options.TemplatePrefix = value;

//            Assert.Equal(value, _options.TemplatePrefix);
//        }

//        [Fact]
//        public void ItHasWritableTemplateSuffixProperty()
//        {
//            var value = "value";

//            _options.TemplateSuffix = value;

//            Assert.Equal(value, _options.TemplateSuffix);
//        }
//    }
//}
