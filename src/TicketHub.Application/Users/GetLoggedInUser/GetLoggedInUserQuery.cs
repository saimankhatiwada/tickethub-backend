using TicketHub.Application.Abstractions.Messaging;
using TicketHub.Application.Users.Shared;

namespace TicketHub.Application.Users.GetLoggedInUser;


public sealed record GetLoggedInUserQuery : IQuery<UserResponse>;
