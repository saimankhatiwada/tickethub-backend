using TicketHub.Domain.Abstractions;

namespace TicketHub.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(UserId UserId) : IDomainEvent;
