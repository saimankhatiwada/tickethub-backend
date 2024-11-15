namespace TicketHub.Application.Users.Shared;

public sealed class UserResponse
{
    public Guid Id { get; init; }

    public string Email { get; init; }

    public string FirstName { get; init; }

    public string LastName { get; init; }
    
    public string Bio { get; init; }
    
    public string MobileNumber { get; init; }

    public string Role { get; init; }

    public bool IsEmailVerified { get; init; }
    
    public bool IsMobileNumberVerified { get; init; }

    public bool IsSuspended { get; init; }
    
    public string ImageUrl { get; init; }
}
