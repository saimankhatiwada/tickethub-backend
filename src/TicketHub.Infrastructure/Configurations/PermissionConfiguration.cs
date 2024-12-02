using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketHub.Domain.Users;

namespace TicketHub.Infrastructure.Configurations;

internal sealed class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("permissions");

        builder.HasKey(permission => permission.Id);

        builder.HasData(
            Permission.UsersReadOwn, 
            Permission.UsersRead,
            Permission.UsersUpdate,
            Permission.UsersDelete,
            Permission.EventsRead,
            Permission.EventsReadSingle,
            Permission.EventsUpdate,
            Permission.EventsDelete);
    }
}
