namespace TicketHub.Domain.Events;

public record EventId(Guid Value)
{
    public static EventId New() => new(Guid.NewGuid());
}
