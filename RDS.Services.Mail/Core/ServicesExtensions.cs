using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RDS.Services.Mail.Configuration;
using RDS.Services.Mail.Factory;
using RDS.Services.Mail.Filler;
using RDS.Services.Mail.Sender;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace RDS.Services.Mail
{
    public static partial class ServicesExtensions
    {

        public static void AddMail(this IServiceCollection services, IConfiguration configuration)
        {
            MailServiceJsonConfiguration jsonConfiguration = new MailServiceJsonConfiguration();
            configuration.Bind("MailService", jsonConfiguration);
            var converter = new ConfigurationConverter();
            var options = converter.Convert(jsonConfiguration);
            AddService(services, options);
        }

        public static void AddMail(this IServiceCollection services, Action<MailServiceOptionsBuilder> action)
        {
            MailServiceOptionsBuilder builder = new MailServiceOptionsBuilder();
            action.Invoke(builder);
            var options = builder.Build();
            AddService(services, options);
        }

        private static void AddService(IServiceCollection services, MailServiceOptions options)
        {
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IMailMessageFiller, MailMessageFiller>();
            services.AddScoped<ITemplateFactory, TemplateFactory>();
            services.AddScoped<IMailSender, MailSender>();
            services.AddSingleton<IMailMessageFillerOptions>(options.Filler);
            services.AddSingleton<IMailSenderOptions>(options.Sender);
            services.AddSingleton<ITemplateFactoryOptions>(options.Template);
        }
    }
}
