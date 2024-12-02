namespace TicketHub.Domain.Events.Tickets;

public sealed record Supply
{
    internal static readonly Supply None = new(string.Empty);

    public static readonly Supply Limited = new("Limited");

    public static readonly Supply Unlimited = new("Unlimited");

    private Supply(string value) => Value = value;

    public string Value { get; init; }

    public static Supply FromSupply(string value) => All.FirstOrDefault(c => c.Value == value) ??
        throw new ApplicationException("The status value is invalid");

    public static Supply CheckSupply(string value) => All.FirstOrDefault(c => c.Value == value) ??
        None;
        
    public static readonly IReadOnlyCollection<Supply> All =
    [
        Limited,
        Unlimited
    ];
}
