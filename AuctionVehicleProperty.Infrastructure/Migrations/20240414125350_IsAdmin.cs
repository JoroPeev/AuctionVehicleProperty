using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionVehicleProperty.Infrastructure.Migrations
{
    public partial class IsAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Agents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsAdmin",
                value: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Agents");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12cde8f1-b0f3-4bce-be91-21858132472d", "AQAAAAEAACcQAAAAECSrZ9pf8FHjBmJ3pLavUTyeRL7iGz8TBmLtnXOsMnTouKyTNJZFLIuuMqcR16AlWQ==", "c38754c4-2947-4321-9a38-0bc2f00d7088" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591s",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d1df227c-fe8c-4430-a658-f845aba26a4f", "c769b517-bd92-406f-ae76-18152f15a7aa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06dbe20c-85be-4693-8324-2c737d6cdba4", "AQAAAAEAACcQAAAAEK1rEEDxV4Oxok9LLfq1uGfapG1LnAcUOMj6xh9BwFQEcv9baYmNwxRkLaENdSBZ5A==", "b6feec5c-1a8d-4364-9c34-8fdeb464fba4" });
        }
    }
}
