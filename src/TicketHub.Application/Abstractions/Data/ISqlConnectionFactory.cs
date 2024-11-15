using System.Data;

namespace TicketHub.Application.Abstractions.Data;


public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}
