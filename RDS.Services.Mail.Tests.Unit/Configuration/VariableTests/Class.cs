using RDS.Services.Mail.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RDS.Services.Mail.Tests.Unit.Configuration.VariableTests
{
    [Trait("Category","Configuration")]
    public class Class
    {
        Variable _variable = new Variable();

        [Fact]
        public void ItExists()
        {
            Variable variable = new Variable();
        }

        [Fact]
        public void ItHasNameWritableProperty()
        {
            var expected = "name";

            _variable.Name = expected;

            Assert.Equal(expected, _variable.Name);
        }

        [Fact]
        public void ItHasValueWritableProperty()
        {
            var expected = "value";

            _variable.Value = expected;

            Assert.Equal(expected, _variable.Value);
        }
    }
}
