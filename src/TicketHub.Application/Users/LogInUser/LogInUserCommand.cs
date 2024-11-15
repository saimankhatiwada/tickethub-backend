using TicketHub.Application.Abstractions.Messaging;

namespace TicketHub.Application.Users.LogInUser;


public sealed record LogInUserCommand(string Email, string Password) : ICommand<AccessTokenResponse>;
