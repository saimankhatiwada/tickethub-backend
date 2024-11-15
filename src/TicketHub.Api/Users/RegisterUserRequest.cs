namespace TicketHub.Api.Users;

public sealed record RegisterUserRequest(
    string Email,
    string FirstName,
    string LastName,
    string Password,
    string MobileNumber,
    string Role,
    bool IsTermAndCondition);
