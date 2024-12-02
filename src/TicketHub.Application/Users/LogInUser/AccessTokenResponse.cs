using System.Text.Json.Serialization;

namespace TicketHub.Application.Users.LogInUser;


public sealed record AccessTokenResponse(
    [property: JsonPropertyName("access_token")]
    string AccessToken);
