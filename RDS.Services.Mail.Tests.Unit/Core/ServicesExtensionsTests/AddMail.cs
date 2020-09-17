using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RDS.Services.Mail;
using RDS.Services.Mail.Factory;
using RDS.Services.Mail.Filler;
using RDS.Services.Mail.Sender;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MailServiceTest.ServiceExtensionsTests
{
    [Trait("Category", "ServiceExtensions")]
    public class AddMail
    {
        [Fact (Skip = "how to test it?")]
        public void GivenConfigurationThenServicesCreated()
        {
            IServiceCollection services = new ServiceCollection();
            IConfiguration configuration = Mock.Of<IConfiguration>();
            Mock.Get(configuration).Setup(c => c.Bind(It.IsAny<string>(), It.IsAny<object>()));
            services.AddMail(configuration);

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            Assert.NotNull(serviceProvider.GetRequiredService<IMailService>());
            Assert.NotNull(serviceProvider.GetRequiredService<IMailMessageFiller>());
            Assert.NotNull(serviceProvider.GetRequiredService<ITemplateFactory>());
            Assert.NotNull(serviceProvider.GetRequiredService<IMailSender>());
        }

        [Fact]
        public void GivenBuilderThenServicesCreated()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddMail(options => options.ToString());

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            Assert.NotNull(serviceProvider.GetRequiredService<IMailService>());
            Assert.NotNull(serviceProvider.GetRequiredService<IMailMessageFiller>());
            Assert.NotNull(serviceProvider.GetRequiredService<ITemplateFactory>());
            Assert.NotNull(serviceProvider.GetRequiredService<IMailSender>());
        }
    }
}
