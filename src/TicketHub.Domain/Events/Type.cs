namespace TicketHub.Domain.Events;

public sealed record Type
{
    internal static readonly Type None = new(string.Empty);

    public static readonly Type Concert = new("Concert");

    public static readonly Type Festival = new("Festival");

    public static readonly Type Tournament = new("Tournament");

    public static readonly Type Workshop = new("Workshop");

    private Type(string value) => Value = value;

    public string Value { get; init; }

    public static Type FromType(string value) => All.FirstOrDefault(c => c.Value == value) ??
        throw new ApplicationException("The status value is invalid");

    public static Type CheckType(string value) => All.FirstOrDefault(c => c.Value == value) ??
        None;
        
    public static readonly IReadOnlyCollection<Type> All =
    [
        Concert,
        Festival,
        Tournament,
        Workshop
    ];
}
