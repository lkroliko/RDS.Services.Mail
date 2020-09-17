using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Xunit;

namespace RDS.Services.Mail.Tests.Unit.MailTemplateTests
{
    [Trait("Category", "MailTemplate")]
    public class Class
    {
        MailTemplate _template = new MailTemplate();
        [Fact]
        public void ItExists()
        {
            MailTemplate template = new MailTemplate();
        }

        [Fact]
        public void ItHasNameWritableProperty()
        {
            var value = "name";

            _template.Name = value;

            Assert.Equal(value, _template.Name);
        }
        
        [Fact]
        public void ItHasBodyWritableProperty()
        {
            var value = "body";

            _template.Body = value;

            Assert.Equal(value, _template.Body);
        }

        [Fact]
        public void ItHasSubjectWritableProperty()
        {
            var value = "subject";

            _template.Subject = value;
            
            Assert.Equal(value, _template.Subject);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ItHasIsBodyHtmlWritableProperty(bool value)
        {
            _template.IsBodyHtml = value;

            Assert.Equal(value, _template.IsBodyHtml);
        }

        [Fact]
        public void ItHasIsBodyPropertyHasTrueDefaultValue()
        {
            MailTemplate template = new MailTemplate();

            Assert.True(template.IsBodyHtml);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void GivenEmptyNameThenThrowArgumentException(string name)
        {
            var result = Record.Exception(() => _template.Name = name);

            Assert.IsAssignableFrom<ArgumentException>(result.GetBaseException());
            Assert.StartsWith("Template name is null or empty.", result.Message);
            Assert.Contains("name", ((ArgumentException)result).ParamName);
        }
    }
}
