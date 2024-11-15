using TicketHub.Application.Abstractions.Clock;

namespace TicketHub.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
