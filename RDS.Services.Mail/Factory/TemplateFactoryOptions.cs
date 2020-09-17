using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace RDS.Services.Mail.Factory
{
    public class TemplateFactoryOptions : ITemplateFactoryOptions
    {
        ConcurrentDictionary<string, IMailTemplate> _templates; 
        
        public TemplateFactoryOptions()
        {
            _templates = new ConcurrentDictionary<string, IMailTemplate>();
        }

        public TemplateFactoryOptions(ConcurrentDictionary<string, IMailTemplate> templates)
        {
            _templates = templates;
        }

        public IMailTemplate GetPrototype(string name)
        {
            if (_templates.ContainsKey(name))
                return _templates[name];

            return null;
        }

        public void AddPrototype(IMailTemplate template)
        {
            _templates[template.Name] = template;
        }
    }
}
