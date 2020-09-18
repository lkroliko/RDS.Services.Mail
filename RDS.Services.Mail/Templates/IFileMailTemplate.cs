namespace RDS.Services.Mail
{
    public interface IFileMailTemplate : IMailTemplate
    {
        string Path { get; set; }
        bool StoreInMemory { get; set; }
    }
}