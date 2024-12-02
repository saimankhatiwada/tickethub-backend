using TicketHub.Domain.Abstractions;
using TicketHub.Domain.Users;

namespace TicketHub.Domain.Events;

public sealed class Event : Entity<EventId>
{
    private Event(EventId id, UserId userId, BannerUrl bannerUrl, Name name, Description description, Address address, Venu venu, Type type, Progress progress, Status status, List<Tag> tags)
        : base(id)
    {
        UserId = userId;
        BannerUrl = bannerUrl;
        Name = name;
        Description = description;
        Address = address;
        Venu = venu;
        Type = type;
        Progress = progress;
        Status = status;
        Tags = tags;
    }

    private Event()
    {
    }

    public UserId UserId { get; private set; }

    public BannerUrl BannerUrl { get; private set; }

    public Name Name { get; private set; }

    public Description Description { get; private set; }

    public Address Address { get; private set; }

    public Venu Venu { get; private set; }

    public Type Type { get; private set; }

    public Progress Progress { get; private set; }

    public Status Status { get; private set; }

    public List<Tag> Tags { get; private set; } = [];

    public static Event Create(UserId userId, BannerUrl bannerUrl, Name name, Description description, Address address, Venu venu, Type type, Progress progress, Status status, Tag[] tags)
    {
        return new Event(EventId.New(), userId, bannerUrl, name, description, address, venu, type, progress, status, [.. tags]);
    }
}
