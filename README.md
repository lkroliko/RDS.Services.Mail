# MailService
Library to send emails using templates

```c#
_mailService
      .LoadTemplate("Template name")
      .FillTemplate(object)
      .AddRecipient("recipient@host.local")
      .SendTemplate();
