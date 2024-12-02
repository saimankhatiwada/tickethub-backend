using System.Text.Json.Serialization;

namespace TicketHub.Api.Users;

public sealed record RegisterUserRequest(
    string Email,

    [property: JsonPropertyName("first_name")]
    string FirstName,

    [property: JsonPropertyName("last_name")]
    string LastName,
    string Password,

    [property: JsonPropertyName("mobile_number")]
    string MobileNumber,
    string Role,

    [property: JsonPropertyName("is_term_and_condition")]
    bool IsTermAndCondition);
