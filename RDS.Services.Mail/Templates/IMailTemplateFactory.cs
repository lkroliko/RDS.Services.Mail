namespace RDS.Services.Mail.Templates
{
    internal interface IMailTemplateFactory
    {
        IFileMailTemplate GetFileMailTemplate();
        IMailTemplate GetMailTemplate();
    }
}