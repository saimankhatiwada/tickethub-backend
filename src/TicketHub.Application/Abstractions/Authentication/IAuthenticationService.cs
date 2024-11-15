using TicketHub.Domain.Abstractions;
using TicketHub.Domain.Users;

namespace TicketHub.Application.Abstractions.Authentication;

public interface IAuthenticationService
{
    Task<Result<string>> RegisterAsync(
        User user,
        string password,
        CancellationToken cancellationToken = default);
}
