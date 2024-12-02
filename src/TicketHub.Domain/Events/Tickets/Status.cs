namespace TicketHub.Domain.Events.Tickets;

public sealed record Status
{
    internal static readonly Status None = new(string.Empty);

    public static readonly Status Avilable = new("Avilable");

    public static readonly Status Sold = new("Sold");

    private Status(string value) => Value = value;

    public string Value { get; init; }

    public static Status FromStatus(string value) => All.FirstOrDefault(c => c.Value == value) ??
        throw new ApplicationException("The status value is invalid");

    public static Status CheckStatus(string value) => All.FirstOrDefault(c => c.Value == value) ??
        None;
        
    public static readonly IReadOnlyCollection<Status> All =
    [
        Avilable,
        Sold
    ];
}
