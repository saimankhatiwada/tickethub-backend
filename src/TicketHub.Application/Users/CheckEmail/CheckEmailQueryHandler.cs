using System.Data;
using Dapper;
using TicketHub.Application.Abstractions.Data;
using TicketHub.Application.Abstractions.Messaging;
using TicketHub.Domain.Abstractions;

namespace TicketHub.Application.Users.CheckEmail;

internal sealed class CheckEmailQueryHandler : IQueryHandler<CheckEmailQuery, bool>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public CheckEmailQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<bool>> Handle(CheckEmailQuery request, CancellationToken cancellationToken)
    {
        using IDbConnection connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT EXISTS (
                SELECT 1 
                FROM users 
                WHERE email = @Email
            )
            """;

        return await connection.QuerySingleAsync<bool>(sql, new { request.Email });
    }

}
