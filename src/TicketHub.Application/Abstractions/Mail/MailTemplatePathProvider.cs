namespace TicketHub.Application.Abstractions.Mail;

public static class MailTemplatePathProvider
{
    private static readonly Dictionary<MailTemplateFolder, string> FolderNames = new()
    {
        { MailTemplateFolder.MailTemplates, "MailTemplates" },
        { MailTemplateFolder.PdfTemplates, "PdfTemplates" }
    };
    
    private static readonly Dictionary<MailTemplate, string> TemplateFiles = new()
    {
        { MailTemplate.Welcome, "WelcomeMailTemplate.cshtml" },
        { MailTemplate.PasswordReset, "PasswordResetMailTemplate.cshtml" },
        { MailTemplate.OrderConfirmation, "OrderConfirmationMailTemplate.cshtml" }
    };

    public static string GetTemplatePath(MailTemplateFolder mailTemplateFolder, MailTemplate template)
    {
        if (!FolderNames.TryGetValue(mailTemplateFolder, out string? folderName))
        {
            throw new InvalidOperationException($"Folder not found for {mailTemplateFolder}");
        }

        if (!TemplateFiles.TryGetValue(template, out string? fileName))
        {
            throw new InvalidOperationException($"Template file not found for {template}");
        }

        return Path.Combine(AppContext.BaseDirectory, "View", folderName, fileName);
    }
}
