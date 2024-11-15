using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketHub.Api.Utils;
using TicketHub.Application.Users.CheckEmail;
using TicketHub.Application.Users.CheckMobileNumber;
using TicketHub.Application.Users.GetLoggedInUser;
using TicketHub.Application.Users.LogInUser;
using TicketHub.Application.Users.RegisterUser;
using TicketHub.Application.Users.Shared;
using TicketHub.Domain.Abstractions;
using TicketHub.Infrastructure.Authorization;

namespace TicketHub.Api.Users;

[ApiController]
[ApiVersion(ApiVersions.V1)]
[Route("api/v{version:apiVersion}/users")]
public class UserController : ControllerBase
{
    private readonly ISender _sender;

    public UserController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("me")]
    [HasPermission(Permissions.UsersReadOwn)]
    public async Task<IActionResult> GetLoggedInUser(CancellationToken cancellationToken)
    {
        var query = new GetLoggedInUserQuery();

        Result<UserResponse> result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register(
        [FromBody]RegisterUserRequest request,
        CancellationToken cancellationToken)
    {
        var command = new RegisterUserCommand(
            request.Email,
            request.FirstName,
            request.LastName,
            request.Password,
            request.MobileNumber,
            request.Role,
            request.IsTermAndCondition);

        Result<Guid> result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> LogIn(
        [FromBody]LogInUserRequest request,
        CancellationToken cancellationToken)
    {
        var command = new LogInUserCommand(request.Email, request.Password);

        Result<AccessTokenResponse> result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : Unauthorized(result.Error);
    }

    [AllowAnonymous]
    [HttpGet("email-exists/{email}")]
    public async Task<IActionResult> EmailExits(
        string email,
        CancellationToken cancellationToken)
    {
        var query = new CheckEmailQuery(email);

        Result<bool> result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : Unauthorized(result.Error);
    }

    [AllowAnonymous]
    [HttpGet("mobile-number-exists/{number}")]
    public async Task<IActionResult> MobileNumberExists(
        string number,
        CancellationToken cancellationToken)
    {
        var query = new CheckMobileNumberQuery(number);

        Result<bool> result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : Unauthorized(result.Error);
    }
}
