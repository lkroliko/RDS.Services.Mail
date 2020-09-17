using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RDS.Services.Mail.Configuration;
using RDS.Services.Mail.Factory;
using RDS.Services.Mail.Filler;
using RDS.Services.Mail.Sender;
using System;
using System.Collections.Generic;
using System.Text;

namespace RDS.Services.Mail
{
    public static partial class ServicesExtensions
    {
        public static void AddMail(this IServiceCollection services, IConfiguration configuration)
        {
            MailServiceJsonConfiguration jsonConfiguration = new MailServiceJsonConfiguration();
            configuration.Bind("MailService", jsonConfiguration);
            jsonConfiguration.Load();
            AddService(services);
        }

        public static void AddMail(this IServiceCollection services, Action<MailServiceOptionsBuilder> options)
        {
            MailServiceOptionsBuilder builder = new MailServiceOptionsBuilder();
            options.Invoke(builder);
            AddService(services);
        }

        private static void AddService(IServiceCollection services)
        {
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IMailMessageFiller, MailMessageFiller>();
            services.AddScoped<ITemplateFactory, TemplateFactory>();
            services.AddScoped<IMailSender, MailSender>();
        }
    }
}
