namespace TicketHub.Domain.Events.Tickets;

public record TicketId(Guid Value)
{
    public static TicketId New() => new(Guid.NewGuid());
}
