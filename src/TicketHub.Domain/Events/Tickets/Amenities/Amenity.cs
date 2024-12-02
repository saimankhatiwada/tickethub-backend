using TicketHub.Domain.Abstractions;

namespace TicketHub.Domain.Events.Tickets.Amenities;

public sealed class Amenity : Entity<AmenityId>
{
    private Amenity(AmenityId id, TicketId ticketId, Name name, Description description) : base(id)
    {
        TicketId = ticketId;
        Name = name;
        Description = description;
    }

    private Amenity()
    {
    }

    public TicketId TicketId { get; private set; }

    public Name Name { get; private set; }

    public Description Description { get; private set; }

    public static Amenity Create(TicketId ticketId, Name name, Description description)
    {
        return new Amenity(AmenityId.New(), ticketId, name, description);
    }
}
