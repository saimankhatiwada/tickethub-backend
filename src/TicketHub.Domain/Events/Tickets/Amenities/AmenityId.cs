namespace TicketHub.Domain.Events.Tickets.Amenities;

public record AmenityId(Guid Value)
{
    public static AmenityId New() => new(Guid.NewGuid());
}
