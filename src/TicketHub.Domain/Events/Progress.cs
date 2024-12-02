namespace TicketHub.Domain.Events;

public sealed record Progress
{
    public static readonly Progress None = new(string.Empty);

    public static readonly Progress Upcoming = new("Upcoming");

    public static readonly Progress Ongoing = new("Ongoing");

    public static readonly Progress Completed = new("Completed");

    public static readonly Progress Cancled = new("Cancled");

    public static readonly Progress Paused = new("Paused");

    private Progress(string value) => Value = value;

    public string Value { get; init; }

    public static Progress FromProgress(string value) => All.FirstOrDefault(c => c.Value == value) ??
        throw new ApplicationException("The status value is invalid");

    public static Progress CheckProgress(string value) => All.FirstOrDefault(c => c.Value == value) ??
        None;
        
    public static readonly IReadOnlyCollection<Progress> All =
    [
        Upcoming,
        Ongoing,
        Completed,
        Cancled,
        Paused
    ];
}
