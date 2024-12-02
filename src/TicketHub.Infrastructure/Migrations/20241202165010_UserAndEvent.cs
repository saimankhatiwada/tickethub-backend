using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketHub.Infrastructure.Migrations;

public partial class UserAndEvent : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "outbox_messages",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                occurred_on_utc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                type = table.Column<string>(type: "text", nullable: false),
                content = table.Column<string>(type: "jsonb", nullable: false),
                processed_on_utc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                error = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table => table.PrimaryKey("pk_outbox_messages", x => x.id));

        migrationBuilder.CreateTable(
            name: "permissions",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                name = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table => table.PrimaryKey("pk_permissions", x => x.id));

        migrationBuilder.CreateTable(
            name: "roles",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                name = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table => table.PrimaryKey("pk_roles", x => x.id));

        migrationBuilder.CreateTable(
            name: "users",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                first_name = table.Column<string>(type: "text", nullable: false),
                last_name = table.Column<string>(type: "text", nullable: false),
                email = table.Column<string>(type: "text", nullable: false),
                bio = table.Column<string>(type: "text", nullable: false),
                mobile_number = table.Column<string>(type: "text", nullable: false),
                image_url = table.Column<string>(type: "text", nullable: false),
                is_email_verified = table.Column<bool>(type: "boolean", nullable: false),
                is_mobile_number_verified = table.Column<bool>(type: "boolean", nullable: false),
                is_terms_and_condition = table.Column<bool>(type: "boolean", nullable: false),
                is_suspended = table.Column<bool>(type: "boolean", nullable: false),
                identity_id = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table => table.PrimaryKey("pk_users", x => x.id));

        migrationBuilder.CreateTable(
            name: "role_permissions",
            columns: table => new
            {
                role_id = table.Column<int>(type: "integer", nullable: false),
                permission_id = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_role_permissions", x => new { x.role_id, x.permission_id });
                table.ForeignKey(
                    name: "fk_role_permissions_permissions_permission_id",
                    column: x => x.permission_id,
                    principalTable: "permissions",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "fk_role_permissions_roles_role_id",
                    column: x => x.role_id,
                    principalTable: "roles",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "events",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                user_id = table.Column<Guid>(type: "uuid", nullable: false),
                banner_url = table.Column<string>(type: "text", nullable: false),
                name = table.Column<string>(type: "text", nullable: false),
                description = table.Column<string>(type: "text", nullable: false),
                address_country = table.Column<string>(type: "text", nullable: false),
                address_state = table.Column<string>(type: "text", nullable: false),
                address_city = table.Column<string>(type: "text", nullable: false),
                address_street = table.Column<string>(type: "text", nullable: false),
                venu = table.Column<string>(type: "text", nullable: false),
                type = table.Column<string>(type: "text", nullable: false),
                progress = table.Column<string>(type: "text", nullable: false),
                status = table.Column<string>(type: "text", nullable: false),
                tags = table.Column<List<string>>(type: "text[]", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_events", x => x.id);
                table.ForeignKey(
                    name: "fk_events_users_user_id",
                    column: x => x.user_id,
                    principalTable: "users",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "role_user",
            columns: table => new
            {
                roles_id = table.Column<int>(type: "integer", nullable: false),
                users_id = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_role_user", x => new { x.roles_id, x.users_id });
                table.ForeignKey(
                    name: "fk_role_user_role_roles_id",
                    column: x => x.roles_id,
                    principalTable: "roles",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "fk_role_user_users_users_id",
                    column: x => x.users_id,
                    principalTable: "users",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "tickets",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                event_id = table.Column<Guid>(type: "uuid", nullable: false),
                type = table.Column<string>(type: "text", nullable: false),
                supply = table.Column<string>(type: "text", nullable: false),
                status = table.Column<string>(type: "text", nullable: false),
                price_amount = table.Column<decimal>(type: "numeric", nullable: false),
                price_currency = table.Column<string>(type: "text", nullable: false),
                avilable = table.Column<int>(type: "integer", nullable: false),
                sold = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_tickets", x => x.id);
                table.ForeignKey(
                    name: "fk_tickets_events_event_id",
                    column: x => x.event_id,
                    principalTable: "events",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "amenities",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                ticket_id = table.Column<Guid>(type: "uuid", nullable: false),
                name = table.Column<string>(type: "text", nullable: false),
                description = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_amenities", x => x.id);
                table.ForeignKey(
                    name: "fk_amenities_tickets_ticket_id",
                    column: x => x.ticket_id,
                    principalTable: "tickets",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.InsertData(
            table: "permissions",
            columns: ["id", "name"],
            values: new object[,]
            {
                { 1, "users:readown" },
                { 2, "users:read" },
                { 3, "users:update" },
                { 4, "users:delete" },
                { 5, "events:read" },
                { 6, "events:read-single" },
                { 7, "events:update" },
                { 8, "users:delete" }
            });

        migrationBuilder.InsertData(
            table: "roles",
            columns: ["id", "name"],
            values: new object[,]
            {
                { 1, "Registered" },
                { 2, "Merchant" },
                { 3, "Support" },
                { 4, "Admin" },
                { 5, "SuperAdmin" }
            });

        migrationBuilder.InsertData(
            table: "role_permissions",
            columns: ["permission_id", "role_id"],
            values: new object[,]
            {
                { 1, 1 },
                { 5, 1 },
                { 6, 1 },
                { 1, 2 },
                { 5, 2 },
                { 6, 2 },
                { 7, 2 },
                { 1, 3 },
                { 2, 3 },
                { 5, 3 },
                { 6, 3 },
                { 7, 3 },
                { 1, 4 },
                { 2, 4 },
                { 3, 4 },
                { 5, 4 },
                { 6, 4 },
                { 7, 4 },
                { 1, 5 },
                { 2, 5 },
                { 3, 5 },
                { 4, 5 },
                { 5, 5 },
                { 6, 5 },
                { 7, 5 },
                { 8, 5 }
            });

        migrationBuilder.CreateIndex(
            name: "ix_amenities_ticket_id",
            table: "amenities",
            column: "ticket_id");

        migrationBuilder.CreateIndex(
            name: "ix_events_user_id",
            table: "events",
            column: "user_id");

        migrationBuilder.CreateIndex(
            name: "ix_role_permissions_permission_id",
            table: "role_permissions",
            column: "permission_id");

        migrationBuilder.CreateIndex(
            name: "ix_role_user_users_id",
            table: "role_user",
            column: "users_id");

        migrationBuilder.CreateIndex(
            name: "ix_tickets_event_id",
            table: "tickets",
            column: "event_id");

        migrationBuilder.CreateIndex(
            name: "ix_users_email",
            table: "users",
            column: "email",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "ix_users_identity_id",
            table: "users",
            column: "identity_id",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "ix_users_mobile_number",
            table: "users",
            column: "mobile_number",
            unique: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "amenities");

        migrationBuilder.DropTable(
            name: "outbox_messages");

        migrationBuilder.DropTable(
            name: "role_permissions");

        migrationBuilder.DropTable(
            name: "role_user");

        migrationBuilder.DropTable(
            name: "tickets");

        migrationBuilder.DropTable(
            name: "permissions");

        migrationBuilder.DropTable(
            name: "roles");

        migrationBuilder.DropTable(
            name: "events");

        migrationBuilder.DropTable(
            name: "users");
    }
}
