using Microsoft.AspNetCore.Authorization;

namespace TicketHub.Infrastructure.Authorization;


public sealed class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(string permission)
        : base(permission)
    {
    }
}
