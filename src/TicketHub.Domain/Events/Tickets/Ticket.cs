using TicketHub.Domain.Abstractions;
using TicketHub.Domain.Shared;

namespace TicketHub.Domain.Events.Tickets;

public sealed class Ticket : Entity<TicketId>
{
    private Ticket(TicketId id, EventId eventId, Type type, Supply supply, Status status, Money price, Avilable avilable, Sold sold)
        : base(id)
    {
        EventId = eventId;
        Type = type;
        Supply = supply;
        Status = status;
        Price = price;
        Avilable= avilable;
        Sold = sold;
    }

    private Ticket()
    {
    }

    public EventId EventId { get; private set; }

    public Type Type { get; private set; }

    public Supply Supply { get; private set; }

    public Status Status { get; private set; }

    public Money Price { get; private set; }

    public Avilable Avilable { get; private set; }

    public Sold Sold { get; private set; }

    public static Ticket Create(EventId eventId, Type type, Supply supply, Status status, Money price, Avilable avilable, Sold sold)
    {
        return new Ticket(TicketId.New(), eventId, type, supply, status, price, avilable, sold);
    }
}
