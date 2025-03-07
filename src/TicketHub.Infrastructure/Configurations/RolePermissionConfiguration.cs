using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketHub.Domain.Users;

namespace TicketHub.Infrastructure.Configurations;

internal sealed class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.ToTable("role_permissions");

        builder.HasKey(rp => new { rp.RoleId, rp.PermissionId });

        builder.HasData(
            new RolePermission
            {
                RoleId = Role.Registered.Id,
                PermissionId = Permission.UsersReadOwn.Id
            },
            new RolePermission
            {
                RoleId = Role.Registered.Id,
                PermissionId = Permission.EventsRead.Id
            },
            new RolePermission
            {
                RoleId = Role.Registered.Id,
                PermissionId = Permission.EventsReadSingle.Id
            },
            new RolePermission
            {
                RoleId = Role.Merchant.Id,
                PermissionId = Permission.UsersReadOwn.Id
            },
            new RolePermission
            {
                RoleId = Role.Merchant.Id,
                PermissionId = Permission.EventsRead.Id
            },
            new RolePermission
            {
                RoleId = Role.Merchant.Id,
                PermissionId = Permission.EventsReadSingle.Id
            },
            new RolePermission
            {
                RoleId = Role.Merchant.Id,
                PermissionId = Permission.EventsUpdate.Id
            },
            new RolePermission
            {
                RoleId = Role.Support.Id,
                PermissionId = Permission.UsersReadOwn.Id
            },
            new RolePermission
            {
                RoleId = Role.Support.Id,
                PermissionId = Permission.UsersRead.Id
            },
            new RolePermission
            {
                RoleId = Role.Support.Id,
                PermissionId = Permission.EventsRead.Id
            },
            new RolePermission
            {
                RoleId = Role.Support.Id,
                PermissionId = Permission.EventsReadSingle.Id
            },
            new RolePermission
            {
                RoleId = Role.Support.Id,
                PermissionId = Permission.EventsUpdate.Id
            },
            new RolePermission
            {
                RoleId = Role.Admin.Id,
                PermissionId = Permission.UsersReadOwn.Id
            },
            new RolePermission
            {
                RoleId = Role.Admin.Id,
                PermissionId = Permission.UsersRead.Id
            },
            new RolePermission
            {
                RoleId = Role.Admin.Id,
                PermissionId = Permission.UsersUpdate.Id
            },
            new RolePermission
            {
                RoleId = Role.Admin.Id,
                PermissionId = Permission.EventsRead.Id
            },
            new RolePermission
            {
                RoleId = Role.Admin.Id,
                PermissionId = Permission.EventsReadSingle.Id
            },
            new RolePermission
            {
                RoleId = Role.Admin.Id,
                PermissionId = Permission.EventsUpdate.Id
            },
            new RolePermission
            {
                RoleId = Role.SuperAdmin.Id,
                PermissionId = Permission.UsersReadOwn.Id
            },
            new RolePermission
            {
                RoleId = Role.SuperAdmin.Id,
                PermissionId = Permission.UsersRead.Id
            },
            new RolePermission
            {
                RoleId = Role.SuperAdmin.Id,
                PermissionId = Permission.UsersUpdate.Id
            },
            new RolePermission
            {
                RoleId = Role.SuperAdmin.Id,
                PermissionId = Permission.UsersDelete.Id
            },
            new RolePermission
            {
                RoleId = Role.SuperAdmin.Id,
                PermissionId = Permission.EventsRead.Id
            },
            new RolePermission
            {
                RoleId = Role.SuperAdmin.Id,
                PermissionId = Permission.EventsReadSingle.Id
            },
            new RolePermission
            {
                RoleId = Role.SuperAdmin.Id,
                PermissionId = Permission.EventsUpdate.Id
            },
             new RolePermission
            {
                RoleId = Role.SuperAdmin.Id,
                PermissionId = Permission.EventsDelete.Id
            });
    }
}
