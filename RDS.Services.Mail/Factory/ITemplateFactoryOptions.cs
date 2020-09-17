using System.Collections.Concurrent;

namespace RDS.Services.Mail.Factory
{
    public interface ITemplateFactoryOptions
    {
        void AddPrototype(IMailTemplate template);
        IMailTemplate GetPrototype(string name);
    }
}