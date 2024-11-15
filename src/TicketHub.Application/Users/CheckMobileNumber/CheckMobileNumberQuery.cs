using TicketHub.Application.Abstractions.Messaging;

namespace TicketHub.Application.Users.CheckMobileNumber;

public sealed record CheckMobileNumberQuery(string MobileNumber): IQuery<bool>;
