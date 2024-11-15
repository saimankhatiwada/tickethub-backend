using FluentEmail.Core;
using FluentEmail.Core.Models;
using TicketHub.Application.Abstractions.Mail;
using TicketHub.Domain.Abstractions;

namespace TicketHub.Infrastructure.Mail;

internal sealed class MailService : IMailService
{
    private static readonly Error MailSendingFailed = new(
        "Mail.SendingFailed",
        "Failed to send mail to user.");
    private readonly IFluentEmail _fluentEmail;

    public MailService(IFluentEmail fluentEmail)
    {
        _fluentEmail = fluentEmail;
    }

    public async Task<Result> SendMailAsync<T>(T model, MailMetaData mailMetaData, string templateFile, CancellationToken cancellationToken = default)
    {
        SendResponse result = await _fluentEmail
            .To(mailMetaData.MailAddress)
            .Subject(mailMetaData.Subject)
            .UsingTemplateFromFile(templateFile, model)
            .SendAsync(cancellationToken);

        return result.Successful ? Result.Success() : Result.Failure(MailSendingFailed);
    }

}
