namespace RDS.Services.Mail
{
    public interface IMailTemplate
    {
        string Body { get; set; }
        string Name { get; set; }
        string Subject { get; set; }
        bool IsBodyHtml { get; set; }
    }
}