using TicketHub.Application.Abstractions.Messaging;

namespace TicketHub.Application.Users.RegisterUser;


public sealed record RegisterUserCommand(
    string Email,
    string FirstName,
    string LastName,
    string Password,
    string MobileNumber,
    string Role,
    bool IsTermsAndConditions) : ICommand<Guid>;
