﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable

namespace TicketHub.Infrastructure.Migrations;

[DbContext(typeof(ApplicationDbContext))]
[Migration("20241015141523_UserToDb")]
partial class UserToDb
{
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasAnnotation("ProductVersion", "8.0.10")
            .HasAnnotation("Relational:MaxIdentifierLength", 63);

        NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

        modelBuilder.Entity("RoleUser", b =>
            {
                b.Property<int>("RolesId")
                    .HasColumnType("integer")
                    .HasColumnName("roles_id");

                b.Property<Guid>("UsersId")
                    .HasColumnType("uuid")
                    .HasColumnName("users_id");

                b.HasKey("RolesId", "UsersId")
                    .HasName("pk_role_user");

                b.HasIndex("UsersId")
                    .HasDatabaseName("ix_role_user_users_id");

                b.ToTable("role_user", (string)null);
            });

        modelBuilder.Entity("TicketHub.Domain.Users.Permission", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer")
                    .HasColumnName("id");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("name");

                b.HasKey("Id")
                    .HasName("pk_permissions");

                b.ToTable("permissions", (string)null);

                b.HasData(
                    new
                    {
                        Id = 1,
                        Name = "users:readown"
                    },
                    new
                    {
                        Id = 2,
                        Name = "users:read"
                    },
                    new
                    {
                        Id = 3,
                        Name = "users:update"
                    },
                    new
                    {
                        Id = 4,
                        Name = "users:delete"
                    });
            });

        modelBuilder.Entity("TicketHub.Domain.Users.Role", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer")
                    .HasColumnName("id");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("name");

                b.HasKey("Id")
                    .HasName("pk_roles");

                b.ToTable("roles", (string)null);

                b.HasData(
                    new
                    {
                        Id = 1,
                        Name = "Registered"
                    },
                    new
                    {
                        Id = 2,
                        Name = "Merchant"
                    },
                    new
                    {
                        Id = 3,
                        Name = "Support"
                    },
                    new
                    {
                        Id = 4,
                        Name = "Admin"
                    },
                    new
                    {
                        Id = 5,
                        Name = "SuperAdmin"
                    });
            });

        modelBuilder.Entity("TicketHub.Domain.Users.RolePermission", b =>
            {
                b.Property<int>("RoleId")
                    .HasColumnType("integer")
                    .HasColumnName("role_id");

                b.Property<int>("PermissionId")
                    .HasColumnType("integer")
                    .HasColumnName("permission_id");

                b.HasKey("RoleId", "PermissionId")
                    .HasName("pk_role_permissions");

                b.HasIndex("PermissionId")
                    .HasDatabaseName("ix_role_permissions_permission_id");

                b.ToTable("role_permissions", (string)null);

                b.HasData(
                    new
                    {
                        RoleId = 1,
                        PermissionId = 1
                    },
                    new
                    {
                        RoleId = 2,
                        PermissionId = 1
                    },
                    new
                    {
                        RoleId = 3,
                        PermissionId = 1
                    },
                    new
                    {
                        RoleId = 3,
                        PermissionId = 2
                    },
                    new
                    {
                        RoleId = 4,
                        PermissionId = 1
                    },
                    new
                    {
                        RoleId = 4,
                        PermissionId = 2
                    },
                    new
                    {
                        RoleId = 4,
                        PermissionId = 3
                    },
                    new
                    {
                        RoleId = 5,
                        PermissionId = 1
                    },
                    new
                    {
                        RoleId = 5,
                        PermissionId = 2
                    },
                    new
                    {
                        RoleId = 5,
                        PermissionId = 3
                    },
                    new
                    {
                        RoleId = 5,
                        PermissionId = 4
                    });
            });

        modelBuilder.Entity("TicketHub.Domain.Users.User", b =>
            {
                b.Property<Guid>("Id")
                    .HasColumnType("uuid")
                    .HasColumnName("id");

                b.Property<string>("Email")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("character varying(100)")
                    .HasColumnName("email");

                b.Property<string>("FirstName")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("character varying(100)")
                    .HasColumnName("first_name");

                b.Property<string>("IdentityId")
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("identity_id");

                b.Property<string>("ImageName")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("character varying(100)")
                    .HasColumnName("image_name");

                b.Property<bool>("IsEmailVerified")
                    .HasColumnType("boolean")
                    .HasColumnName("is_email_verified");

                b.Property<bool>("IsMobileNumberVerified")
                    .HasColumnType("boolean")
                    .HasColumnName("is_mobile_number_verified");

                b.Property<bool>("IsSuspended")
                    .HasColumnType("boolean")
                    .HasColumnName("is_suspended");

                b.Property<string>("LastName")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("character varying(100)")
                    .HasColumnName("last_name");

                b.Property<string>("MobileNumber")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("character varying(100)")
                    .HasColumnName("mobile_number");

                b.HasKey("Id")
                    .HasName("pk_users");

                b.HasIndex("Email")
                    .IsUnique()
                    .HasDatabaseName("ix_users_email");

                b.HasIndex("IdentityId")
                    .IsUnique()
                    .HasDatabaseName("ix_users_identity_id");

                b.HasIndex("MobileNumber")
                    .IsUnique()
                    .HasDatabaseName("ix_users_mobile_number");

                b.ToTable("users", (string)null);
            });

        modelBuilder.Entity("TicketHub.Infrastructure.Outbox.OutboxMessage", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid")
                    .HasColumnName("id");

                b.Property<string>("Content")
                    .IsRequired()
                    .HasColumnType("jsonb")
                    .HasColumnName("content");

                b.Property<string>("Error")
                    .HasColumnType("text")
                    .HasColumnName("error");

                b.Property<DateTime>("OccurredOnUtc")
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("occurred_on_utc");

                b.Property<DateTime?>("ProcessedOnUtc")
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("processed_on_utc");

                b.Property<string>("Type")
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("type");

                b.HasKey("Id")
                    .HasName("pk_outbox_messages");

                b.ToTable("outbox_messages", (string)null);
            });

        modelBuilder.Entity("RoleUser", b =>
            {
                b.HasOne("TicketHub.Domain.Users.Role", null)
                    .WithMany()
                    .HasForeignKey("RolesId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired()
                    .HasConstraintName("fk_role_user_role_roles_id");

                b.HasOne("TicketHub.Domain.Users.User", null)
                    .WithMany()
                    .HasForeignKey("UsersId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired()
                    .HasConstraintName("fk_role_user_users_users_id");
            });

        modelBuilder.Entity("TicketHub.Domain.Users.RolePermission", b =>
            {
                b.HasOne("TicketHub.Domain.Users.Permission", null)
                    .WithMany()
                    .HasForeignKey("PermissionId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired()
                    .HasConstraintName("fk_role_permissions_permissions_permission_id");

                b.HasOne("TicketHub.Domain.Users.Role", null)
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired()
                    .HasConstraintName("fk_role_permissions_roles_role_id");
            });
    }
}
