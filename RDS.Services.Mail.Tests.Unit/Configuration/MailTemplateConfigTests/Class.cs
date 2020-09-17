using RDS.Services.Mail.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RDS.Services.Mail.Tests.Unit.Configuration.MailTemplateTests
{
    [Trait("Category","Configuration")]
    public class Class
    {
        MailTemplateConfig _template = new MailTemplateConfig();

        [Fact]
        public void ItExistst()
        {
            MailTemplateConfig template = new MailTemplateConfig();
        }

        [Fact]
        public void ItHasBodyWritableProperty()
        {
            var expected = "body";

            _template.Body = expected;

            Assert.Equal(expected, _template.Body);
        }

        [Fact]
        public void ItHasNameWritableProperty()
        {
            var expected = "name";

            _template.Name = expected;

            Assert.Equal(expected, _template.Name);
        }

        [Fact]
        public void ItHasSubjectWritableProperty()
        {
            var expected = "subject";

            _template.Subject = expected;

            Assert.Equal(expected, _template.Subject);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ItHasIsBodyHtmlWritableProperty(bool expected)
        {
            _template.IsBodyHtml = expected;

            Assert.Equal(expected, _template.IsBodyHtml);
        }

        [Fact]
        public void ItHasIsBodyHtmlWithDefaultValue()
        {
            Assert.True(_template.IsBodyHtml);
        }
    }
}
