using MediatR;
using TicketHub.Domain.Abstractions;

namespace TicketHub.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
