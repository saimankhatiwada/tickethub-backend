using System.Data;
using Dapper;
using TicketHub.Application.Abstractions.Authentication;
using TicketHub.Application.Abstractions.Data;
using TicketHub.Application.Abstractions.Messaging;
using TicketHub.Application.Abstractions.Storage;
using TicketHub.Application.Users.Shared;
using TicketHub.Domain.Abstractions;

namespace TicketHub.Application.Users.GetLoggedInUser;

internal sealed class GetLoggedInUserQueryHandler : IQueryHandler<GetLoggedInUserQuery, UserResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly IUserContext _userContext;
    private readonly IBlobStorage _blobStorage;

    public GetLoggedInUserQueryHandler(
        ISqlConnectionFactory sqlConnectionFactory,
        IUserContext userContext,
        IBlobStorage blobStorage)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
        _userContext = userContext;
        _blobStorage = blobStorage;
    }

    public async Task<Result<UserResponse>> Handle(
        GetLoggedInUserQuery request,
        CancellationToken cancellationToken)
    {
        using IDbConnection connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                u.id AS Id,
                u.email AS Email,
                u.first_name AS FirstName,
                u.last_name AS LastName,
                u.bio AS Bio,
                u.mobile_number AS MobileNumber,
                r.name AS Role,
                u.is_email_verified AS IsEmailVerified,
                u.is_mobile_number_verified AS IsMobileNumberVerified,
                u.is_suspended AS IsSuspended,
                u.image_url AS ImageUrl
            FROM users u
            LEFT JOIN role_user ru ON u.id = ru.users_id
            LEFT JOIN roles r ON ru.roles_id = r.id
            WHERE u.identity_id = @IdentityId
            """;

        UserResponse userResponse = await connection.QuerySingleAsync<UserResponse>(
            sql,
            new
            {
                _userContext.IdentityId
            });

        Result<string> result = await _blobStorage.GetPresignedUrlAsync(userResponse.ImageUrl, cancellationToken);

        return new UserResponse
        {
            Id = userResponse.Id,
            Email = userResponse.Email,
            FirstName = userResponse.FirstName,
            LastName = userResponse.LastName,
            Bio = userResponse.Bio,
            MobileNumber = userResponse.MobileNumber,
            Role = userResponse.Role,
            IsEmailVerified = userResponse.IsEmailVerified,
            IsMobileNumberVerified = userResponse.IsMobileNumberVerified,
            IsSuspended = userResponse.IsSuspended,
            ImageUrl = result.Value
        };
    }
}
