using Moq;
using RDS.Services.Mail;
using RDS.Services.Mail.Filler;
using RDS.Services.Mail.Tests.Unit;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace MailServiceTest.MailMessageFillerTests
{
    [Trait("Category", "MailMessageFiller")]
    public class Fill : IClassFixture<MailServiceOptionsFixture>
    {
        IMailServiceOptions _options;
        IMailMessageFiller _filler;
        List<MailAddress> _addCCAddresses = new List<MailAddress>();
        List<MailAddress> _useToAddresses = new List<MailAddress>();

        public Fill(MailServiceOptionsFixture fixture)
        {
            _options = fixture.ServiceOptions;
            Mock.Get(_options).Setup(o => o.Filler.Prefix).Returns("<%");
            Mock.Get(_options).Setup(o => o.Filler.Suffix).Returns("%>");
            Mock.Get(_options).Setup(o => o.Filler.Variables).Returns(new ConcurrentDictionary<string, string>());

            _addCCAddresses.Add(new MailAddress("cc1@local.test"));
            _addCCAddresses.Add(new MailAddress("cc2@local.test"));
            Mock.Get(_options).Setup(o => o.Filler.AddCCAddresses).Returns(_addCCAddresses);

            _useToAddresses.Add(new MailAddress("to1@local.test"));
            _useToAddresses.Add(new MailAddress("to2@local.test"));
            Mock.Get(_options).Setup(o => o.Filler.UseToAddresses).Returns(_useToAddresses);

            _filler = new MailMessageFiller() { Options = _options.Filler };
        }

        [Fact]
        public void GivenMessageThenFromAddressAdded()
        {
            MailAddress expected = new MailAddress("from@host.local");
            Mock.Get(_options).Setup(o => o.Filler.UseFromAddress).Returns(expected);
            MailMessage message = new MailMessage();

            _filler.Fill(message);

            Assert.Equal(expected, message.From);
        }

        [Theory]
        [InlineData("Object StringProp is <%Property%>.", "some string value", "Object StringProp is some string value.")]
        public void GivenMessageThenMessageBodyFilled(string subjectTemplate, string value, string bodyExpected)
        {
            MailMessage message = new MailMessage() { Body = subjectTemplate };
            TestObject testObject = new TestObject()
            {
                Property = value
            };

            _filler.Fill(message, testObject);

            Assert.Equal(bodyExpected, message.Body);
        }

        [Theory]
        [InlineData("Object property is <%Property%>.", "some string value", "Object property is some string value.")]
        public void GivenMessageThenMessageSubjectFilled(string subjectTemplate, string value, string subjectExpected)
        {
            MailMessage message = new MailMessage() { Subject = subjectTemplate };
            TestObject testObject = new TestObject()
            {
                Property = value
            };

            _filler.Fill(message, testObject);

            Assert.Equal(subjectExpected, message.Subject);
        }

        [Theory]
        [InlineData("Mail <%TMP%> body", "tmp value", "Mail tmp value body")]
        [InlineData("><a href=\"https://<%TMP%>/Evaluation/Create/<%Id%>\"", "localhost", "><a href=\"https://localhost/Evaluation/Create/<%Id%>\"")]
        public void GivenMessageThenMessageBodyFilledWithVariables(string body, string variable, string expected)
        {
            _options.Filler.Variables.Clear();
            _options.Filler.Variables["<%TMP%>"] = variable;
            MailMessage message = new MailMessage() { Body = body };

            _filler.Fill(message);

            Assert.Equal(expected, message.Body);
        }

        [Theory]
        [InlineData("Mail <%TMP%> subject", "tmp value", "Mail tmp value subject")]
        public void GivenMessageThenMessageSubjectFilledWithVariables(string subject, string variable, string expected)
        {
            _options.Filler.Variables.Clear();
            _options.Filler.Variables["<%TMP%>"] = variable;
            MailMessage message = new MailMessage() { Subject = subject };

            _filler.Fill(message);

            Assert.Equal(expected, message.Subject);
        }

        [Fact]
        public void GivenMessageThenFromAddressReplaced()
        {
            MailAddress expected = new MailAddress("from@host.local");
            Mock.Get(_options).Setup(o => o.Filler.UseFromAddress).Returns(expected);
            MailMessage message = new MailMessage() { From = new MailAddress("bad@host.local") };
            
            _filler.Fill(message);

            Assert.Equal(expected, message.From);
        }

        [Fact]
        public void GivenMessageThenFromAddressNotReplaced()
        {
            MailAddress expected = new MailAddress("message@host.local");
            Mock.Get(_options).Setup(o => o.Filler.UseFromAddress).Returns((MailAddress)null);
            MailMessage message = new MailMessage() { From = expected };

            _filler.Fill(message);

            Assert.Equal(expected, message.From);
        }

        [Fact]
        public void GivenMessageThenCCAddressAdded()
        {
            MailMessage message = new MailMessage();
            MailAddress cc = new MailAddress("cc@host.local");
            message.CC.Add(cc);

            _filler.Fill(message);

            Assert.Contains(cc, message.CC);
            Assert.Contains(_addCCAddresses, a=> message.CC.Contains(a));
        }

        [Fact]
        public void GivenMessageThenToAddressesReplaced()
        {
            MailMessage message = new MailMessage();
            MailAddress to = new MailAddress("to@host.local");
            message.To.Add(to);

            _filler.Fill(message);

            Assert.Equal(_useToAddresses, message.To);
        }

        [Fact]
        public void GivenMessageThenToAddressNotReplacd()
        {
            Mock.Get(_options).Setup(o => o.Filler.UseToAddresses).Returns(new List<MailAddress>());
                MailMessage message = new MailMessage();
            MailAddress to = new MailAddress("to@host.local");
            message.To.Add(to);
            

            _filler.Fill(message);

            Assert.Equal(to , message.To.First());
        }

        class TestObject
        {
            public dynamic Property { get; set; }
        }
    }
}
