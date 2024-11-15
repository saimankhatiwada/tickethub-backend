namespace TicketHub.Application.Abstractions.Mail;

public class MailMetaData
{
    private MailMetaData(string mailAddress, string subject)
    {
        MailAddress = mailAddress;
        Subject = subject;
    }

    private MailMetaData()
    {
    }

    public string MailAddress { get; private set; }
    public string Subject { get; private set; }

    public static MailMetaData Create(string mailAddress, string subject)
    {
        var mailMetaData = new MailMetaData(mailAddress, subject);

        return mailMetaData;
    }
}
