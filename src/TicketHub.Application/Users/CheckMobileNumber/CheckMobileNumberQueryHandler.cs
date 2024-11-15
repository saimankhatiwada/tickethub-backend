using System.Data;
using Dapper;
using TicketHub.Application.Abstractions.Data;
using TicketHub.Application.Abstractions.Messaging;
using TicketHub.Domain.Abstractions;

namespace TicketHub.Application.Users.CheckMobileNumber;

internal sealed class CheckMobileNumberQueryHandler : IQueryHandler<CheckMobileNumberQuery, bool>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public CheckMobileNumberQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    
    public async Task<Result<bool>> Handle(CheckMobileNumberQuery request, CancellationToken cancellationToken)
    {
        using IDbConnection connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT EXISTS (
                SELECT 1 
                FROM users 
                WHERE mobile_number = @MobileNumber
            )
            """;

        return await connection.QuerySingleAsync<bool>(sql, new { request.MobileNumber });
    }

}
