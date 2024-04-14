using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionVehicleProperty.Infrastructure.Migrations
{
    public partial class RoleAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agents_UserId",
                table: "Agents");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd085a0b-0cc9-420b-bbeb-fd6a30182365", "Guest", "Guestov", "AQAAAAEAACcQAAAAEC4RSJdBBJIGlrWnPK0IldwU7oDqrxnOAIGxecuQjwyKQKgE5AWGvbax4Xt/GwgIEA==", "7abd5d23-4481-421e-82d5-80b8df6c422e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591s",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "SecurityStamp" },
                values: new object[] { "2d73158f-5e30-4ba0-a0bb-7ab3dd3bafc0", "", "", "94e9f546-63a9-41be-9436-75c3cdbf6574" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f23b4a62-8279-499c-8966-ff833026be71", "Agent", "Agentov", "AQAAAAEAACcQAAAAEL8yJpMNY076BEi4J6XFl2MJP9USnJiJY6XIYcoZuQKywE2xGY5HwNEO3K23ZbjARw==", "1462a438-c375-4c34-ba64-fb8f45d94684" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BidId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e43ce836-997d-4927-ac59-74e8c41bbfd3", 0, null, "84e70ddb-9c75-46fc-b827-e6495d81a5a9", "admin@mail.com", false, "Great", "Admin", false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAEAf0RVVmR6Mm452iMtrwajkEt75jZFhJ8UdTi3GyWgVK6ZLzfMboC67d7lHKS9p3AQ==", null, false, "777dbc6b-9900-44f3-a13a-b5fee8af1f4a", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "Email", "IsAdmin", "Location", "UserId" },
                values: new object[] { 123, "Kolio@gmail.com", false, "", "e43ce836-997d-4927-ac59-74e8c41bbfd3" });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_UserId",
                table: "Agents",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agents_UserId",
                table: "Agents");

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81e53a7e-8595-4f53-9c04-16f3a0dbd3f9", "AQAAAAEAACcQAAAAEGVXkU4+a/5dlGQIKetKTSWq3f30999rcEGMc8tuDNrLRlkSUymJ7F7KksozsvzFYA==", "666359ee-9a11-4ede-aea7-05f8b83d2048" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591s",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ff73b4a1-645b-43a1-9967-e3302f1c4c45", "6fa7be79-7989-45db-8317-7dc9391dbb7e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b0cfa7e-6259-4738-ba2b-ee80b736ecd5", "AQAAAAEAACcQAAAAEBys7QwuBuo9vdTKbZh+Hy4gAIZ9KEtuB0/aWfvK6LqmuxaOYVgzPx085n5e02Z+QA==", "8e6737b0-a2f2-48e7-93bf-15fda600a62b" });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_UserId",
                table: "Agents",
                column: "UserId");
        }
    }
}
