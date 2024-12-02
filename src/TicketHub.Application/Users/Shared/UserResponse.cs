using System.Text.Json.Serialization;

namespace TicketHub.Application.Users.Shared;

public sealed class UserResponse
{
    public Guid Id { get; init; }

    public string Email { get; init; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; init; }

    [JsonPropertyName("last_name")]
    public string LastName { get; init; }
    
    public string Bio { get; init; }

    [JsonPropertyName("mobile_number")]
    public string MobileNumber { get; init; }

    public string Role { get; init; }

    [JsonPropertyName("is_email_verified")]
    public bool IsEmailVerified { get; init; }
    
    [JsonPropertyName("is_mobile_number_verified")]
    public bool IsMobileNumberVerified { get; init; }

    [JsonPropertyName("is_suspended")]
    public bool IsSuspended { get; init; }
    
    [JsonPropertyName("image_url")]
    public string ImageUrl { get; init; }
}
