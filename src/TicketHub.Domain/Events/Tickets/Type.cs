namespace TicketHub.Domain.Events.Tickets;

public sealed record Type
{
    internal static readonly Type None = new(string.Empty);

    public static readonly Type Standard = new("Standard");

    public static readonly Type Premium = new("Premium");

    public static readonly Type Vip = new("Vip");

    private Type(string value) => Value = value;

    public string Value { get; init; }

    public static Type FromType(string value) => All.FirstOrDefault(c => c.Value == value) ??
        throw new ApplicationException("The status value is invalid");

    public static Type CheckType(string value) => All.FirstOrDefault(c => c.Value == value) ??
        None;
        
    public static readonly IReadOnlyCollection<Type> All =
    [
        Standard,
        Premium,
        Vip
    ];
}
