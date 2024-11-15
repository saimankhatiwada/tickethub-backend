namespace TicketHub.Infrastructure.Mail;

public sealed class MailOptions
{
    public const string Name = "Mail";

    public string MailSender { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string Host { get; set; }

    public int Port { get; set; }
}
