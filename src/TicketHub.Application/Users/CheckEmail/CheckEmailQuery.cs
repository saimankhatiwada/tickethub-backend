using TicketHub.Application.Abstractions.Messaging;

namespace TicketHub.Application.Users.CheckEmail;

public sealed record CheckEmailQuery(string Email) : IQuery<bool>;
