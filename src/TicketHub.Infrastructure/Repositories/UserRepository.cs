using Microsoft.EntityFrameworkCore;
using TicketHub.Domain.Users;

namespace TicketHub.Infrastructure.Repositories;

internal sealed class UserRepository : Repository<User, UserId>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }

    public override void Add(User user)
    {
        foreach (Role role in user.Roles)
        {
            DbContext.Attach(role);
        }

        DbContext.Add(user);
    }

    public Task<bool> DoesMobileNumberExists(MobileNumber mobileNumber, CancellationToken cancellationToken = default)
    {
        return DbContext.Set<User>().AnyAsync(user => user.MobileNumber == mobileNumber, cancellationToken);
    }
}
