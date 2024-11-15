using TicketHub.Domain.Abstractions;

namespace TicketHub.Application.Abstractions.Mail;

public interface IMailService
{
    Task<Result> SendMailAsync<T>(T model, MailMetaData mailMetaData, string templateFile, CancellationToken cancellationToken = default);
}
