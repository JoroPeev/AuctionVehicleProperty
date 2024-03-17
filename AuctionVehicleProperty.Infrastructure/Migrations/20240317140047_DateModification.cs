using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionVehicleProperty.Infrastructure.Migrations
{
    public partial class DateModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrls",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Vehicle Images");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "593ef71b-c9e6-4797-8403-3c55eb341886", "AQAAAAEAACcQAAAAEMMKWYgrdq7Mt3YzKFozt0BxIW4mJWmBRwgJ2SeeWQ5bzhP1r9LwXGt/CDG4VfGPug==", "b622d3c4-a4b6-4443-b025-c383dd73bbcc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591s",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "eac3f593-939d-44ec-847c-8c75b9c9b408", "d6b04661-d838-4880-8d46-589b034b174d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a19cbf34-a04b-4cdb-8770-d106626faec3", "AQAAAAEAACcQAAAAEGymioM5UPhO6N43EJ36jye7anzSn+L1N+72MFQ94m3dFQp1agotFT7JvrVwN+bK1Q==", "26c934dd-9a54-48e2-822d-cdfba6789581" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrls", "Year" },
                values: new object[] { "https://www.auto-data.net/images/f46/Renault-5-E-Tech_1.jpg", new DateTime(2024, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageUrls", "Year" },
                values: new object[] { "https://www.auto-data.net/en/ford-kuga-iii-facelift-2024-st-line-2.5-243hp-plug-in-hybrid-cvt-51008#image1", new DateTime(2024, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrls",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Vehicle Image");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "479cf994-ed51-4c12-bd19-0d7811a443c8", "AQAAAAEAACcQAAAAEHX5yHp3wtZJWUvzmifVr3tQbgpfp7+imcEbjFrzX7tu32MVx4FXWM9Z/8OOPaSU3w==", "13ea6805-48e2-46de-b20f-863641c36355" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591s",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fd6949c5-b4df-4d4d-a72e-359478fbafa8", "f9a9b5ab-5c49-4a9e-b6a9-657a872ef2d9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46299c4c-ebb2-4329-a169-c707ce43372b", "AQAAAAEAACcQAAAAEIYk4qGfGV5LeyT1sAOHi60pbT3n6MHHI5jv5hYIlUgI2xAO1h3xE+PxE6Ii+RMfsA==", "861bf044-a0ff-4158-aefc-5061ddce4c6c" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrl", "Year" },
                values: new object[] { "https://www.auto-data.net/images/f46/Renault-5-E-Tech_1.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2024) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageUrl", "Year" },
                values: new object[] { "https://www.auto-data.net/images/f76/Ford-Kuga-III-facelift-2024_1.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2024) });
        }
    }
}
