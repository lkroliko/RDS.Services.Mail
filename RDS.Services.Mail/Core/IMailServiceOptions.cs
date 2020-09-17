using RDS.Services.Mail.Factory;
using RDS.Services.Mail.Filler;
using RDS.Services.Mail.Sender;

namespace RDS.Services.Mail
{
    public interface IMailServiceOptions
    {
        IMailSenderOptions Sender { get;  }
        ITemplateFactoryOptions Template { get;  }
        IMailMessageFillerOptions Filler { get; }
    }
}