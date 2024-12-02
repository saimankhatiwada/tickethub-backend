using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketHub.Infrastructure.Migrations;

[DbContext(typeof(ApplicationDbContext))]
[Migration("20241202165010_UserAndEvent")]
partial class UserAndEvent
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

        modelBuilder.Entity("TicketHub.Domain.Events.Event", b =>
            {
                b.Property<Guid>("Id")
                    .HasColumnType("uuid")
                    .HasColumnName("id");

                b.Property<string>("BannerUrl")
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("banner_url");

                b.Property<string>("Description")
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("name");

                b.Property<string>("Progress")
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("progress");

                b.Property<string>("Status")
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("status");

                b.Property<List<string>>("Tags")
                    .IsRequired()
                    .HasColumnType("text[]")
                    .HasColumnName("tags");

                b.Property<string>("Type")
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("type");

                b.Property<Guid>("UserId")
                    .HasColumnType("uuid")
                    .HasColumnName("user_id");

                b.Property<string>("Venu")
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("venu");

                b.HasKey("Id")
                    .HasName("pk_events");

                b.HasIndex("UserId")
                    .HasDatabaseName("ix_events_user_id");

                b.ToTable("events", (string)null);
            });

        modelBuilder.Entity("TicketHub.Domain.Events.Tickets.Amenities.Amenity", b =>
            {
                b.Property<Guid>("Id")
                    .HasColumnType("uuid")
                    .HasColumnName("id");

                b.Property<string>("Description")
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("name");

                b.Property<Guid>("TicketId")
                    .HasColumnType("uuid")
                    .HasColumnName("ticket_id");

                b.HasKey("Id")
                    .HasName("pk_amenities");

                b.HasIndex("TicketId")
                    .HasDatabaseName("ix_amenities_ticket_id");

                b.ToTable("amenities", (string)null);
            });

        modelBuilder.Entity("TicketHub.Domain.Events.Tickets.Ticket", b =>
            {
                b.Property<Guid>("Id")
                    .HasColumnType("uuid")
                    .HasColumnName("id");

                b.Property<int>("Avilable")
                    .HasColumnType("integer")
                    .HasColumnName("avilable");

                b.Property<Guid>("EventId")
                    .HasColumnType("uuid")
                    .HasColumnName("event_id");

                b.Property<int>("Sold")
                    .HasColumnType("integer")
                    .HasColumnName("sold");

                b.Property<string>("Status")
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("status");

                b.Property<string>("Supply")
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("supply");

                b.Property<string>("Type")
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("type");

                b.HasKey("Id")
                    .HasName("pk_tickets");

                b.HasIndex("EventId")
                    .HasDatabaseName("ix_tickets_event_id");

                b.ToTable("tickets", (string)null);
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
                    },
                    new
                    {
                        Id = 5,
                        Name = "events:read"
                    },
                    new
                    {
                        Id = 6,
                        Name = "events:read-single"
                    },
                    new
                    {
                        Id = 7,
                        Name = "events:update"
                    },
                    new
                    {
                        Id = 8,
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
                        RoleId = 1,
                        PermissionId = 5
                    },
                    new
                    {
                        RoleId = 1,
                        PermissionId = 6
                    },
                    new
                    {
                        RoleId = 2,
                        PermissionId = 1
                    },
                    new
                    {
                        RoleId = 2,
                        PermissionId = 5
                    },
                    new
                    {
                        RoleId = 2,
                        PermissionId = 6
                    },
                    new
                    {
                        RoleId = 2,
                        PermissionId = 7
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
                        RoleId = 3,
                        PermissionId = 5
                    },
                    new
                    {
                        RoleId = 3,
                        PermissionId = 6
                    },
                    new
                    {
                        RoleId = 3,
                        PermissionId = 7
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
                        RoleId = 4,
                        PermissionId = 5
                    },
                    new
                    {
                        RoleId = 4,
                        PermissionId = 6
                    },
                    new
                    {
                        RoleId = 4,
                        PermissionId = 7
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
                    },
                    new
                    {
                        RoleId = 5,
                        PermissionId = 5
                    },
                    new
                    {
                        RoleId = 5,
                        PermissionId = 6
                    },
                    new
                    {
                        RoleId = 5,
                        PermissionId = 7
                    },
                    new
                    {
                        RoleId = 5,
                        PermissionId = 8
                    });
            });

        modelBuilder.Entity("TicketHub.Domain.Users.User", b =>
            {
                b.Property<Guid>("Id")
                    .HasColumnType("uuid")
                    .HasColumnName("id");

                b.Property<string>("Bio")
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("bio");

                b.Property<string>("Email")
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("email");

                b.Property<string>("FirstName")
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("first_name");

                b.Property<string>("IdentityId")
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("identity_id");

                b.Property<string>("ImageUrl")
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("image_url");

                b.Property<bool>("IsEmailVerified")
                    .HasColumnType("boolean")
                    .HasColumnName("is_email_verified");

                b.Property<bool>("IsMobileNumberVerified")
                    .HasColumnType("boolean")
                    .HasColumnName("is_mobile_number_verified");

                b.Property<bool>("IsSuspended")
                    .HasColumnType("boolean")
                    .HasColumnName("is_suspended");

                b.Property<bool>("IsTermsAndCondition")
                    .HasColumnType("boolean")
                    .HasColumnName("is_terms_and_condition");

                b.Property<string>("LastName")
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("last_name");

                b.Property<string>("MobileNumber")
                    .IsRequired()
                    .HasColumnType("text")
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

        modelBuilder.Entity("TicketHub.Domain.Events.Event", b =>
            {
                b.HasOne("TicketHub.Domain.Users.User", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired()
                    .HasConstraintName("fk_events_users_user_id");

                b.OwnsOne("TicketHub.Domain.Events.Address", "Address", b1 =>
                    {
                        b1.Property<Guid>("EventId")
                            .HasColumnType("uuid")
                            .HasColumnName("id");

                        b1.Property<string>("City")
                            .IsRequired()
                            .HasColumnType("text")
                            .HasColumnName("address_city");

                        b1.Property<string>("Country")
                            .IsRequired()
                            .HasColumnType("text")
                            .HasColumnName("address_country");

                        b1.Property<string>("State")
                            .IsRequired()
                            .HasColumnType("text")
                            .HasColumnName("address_state");

                        b1.Property<string>("Street")
                            .IsRequired()
                            .HasColumnType("text")
                            .HasColumnName("address_street");

                        b1.HasKey("EventId");

                        b1.ToTable("events");

                        b1.WithOwner()
                            .HasForeignKey("EventId")
                            .HasConstraintName("fk_events_events_id");
                    });

                b.Navigation("Address")
                    .IsRequired();
            });

        modelBuilder.Entity("TicketHub.Domain.Events.Tickets.Amenities.Amenity", b =>
            {
                b.HasOne("TicketHub.Domain.Events.Tickets.Ticket", null)
                    .WithMany()
                    .HasForeignKey("TicketId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired()
                    .HasConstraintName("fk_amenities_tickets_ticket_id");
            });

        modelBuilder.Entity("TicketHub.Domain.Events.Tickets.Ticket", b =>
            {
                b.HasOne("TicketHub.Domain.Events.Event", null)
                    .WithMany()
                    .HasForeignKey("EventId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired()
                    .HasConstraintName("fk_tickets_events_event_id");

                b.OwnsOne("TicketHub.Domain.Shared.Money", "Price", b1 =>
                    {
                        b1.Property<Guid>("TicketId")
                            .HasColumnType("uuid")
                            .HasColumnName("id");

                        b1.Property<decimal>("Amount")
                            .HasColumnType("numeric")
                            .HasColumnName("price_amount");

                        b1.Property<string>("Currency")
                            .IsRequired()
                            .HasColumnType("text")
                            .HasColumnName("price_currency");

                        b1.HasKey("TicketId");

                        b1.ToTable("tickets");

                        b1.WithOwner()
                            .HasForeignKey("TicketId")
                            .HasConstraintName("fk_tickets_tickets_id");
                    });

                b.Navigation("Price")
                    .IsRequired();
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
