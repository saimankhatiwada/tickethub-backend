namespace TicketHub.Domain.Events;

public sealed record Status
{
    internal static readonly Status None = new(string.Empty);

    public static readonly Status Draft = new("Draft");

    public static readonly Status Review = new("Review");

    public static readonly Status Accepted = new("Accepted");

    public static readonly Status Rejected = new("Rejected");

    private Status(string value) => Value = value;

    public string Value { get; init; }

    public static Status FromStatus(string value) => All.FirstOrDefault(c => c.Value == value) ??
        throw new ApplicationException("The status value is invalid");

    public static Status CheckStatus(string value) => All.FirstOrDefault(c => c.Value == value) ??
        None;
        
    public static readonly IReadOnlyCollection<Status> All =
    [
        Draft,
        Review,
        Accepted,
        Rejected
    ];
}
