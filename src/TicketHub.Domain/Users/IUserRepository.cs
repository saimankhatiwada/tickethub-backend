namespace TicketHub.Domain.Users;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(UserId id, CancellationToken cancellationToken = default);

    Task<bool> DoesMobileNumberExists(MobileNumber mobileNumber, CancellationToken cancellationToken = default);

    void Add(User user);
}
