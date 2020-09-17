namespace RDS.Services.Mail
{
    public interface IMailTemplate
    {
        string Body { get; }
        string Name { get; }
        string Subject { get; }
        bool IsBodyHtml { get; }
    }
}