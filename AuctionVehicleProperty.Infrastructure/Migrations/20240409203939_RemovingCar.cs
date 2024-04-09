using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionVehicleProperty.Infrastructure.Migrations
{
    public partial class RemovingCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2fc1cf8-00fb-412f-a643-9ffe295e6c48", "AQAAAAEAACcQAAAAEBS3WhQZEM+DBHsumwaeLCmoDDKWiJbedVIabJiKveRo+6ROKhCYkyQtYKFn3rQrGA==", "7602393c-5543-4ac5-895d-954f124fdd42" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591s",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b78eda4f-d566-482b-bb9c-e0ef8bb48ef0", "b437e63a-9727-4cbc-9f86-68eaaac3e0c8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aacc9d70-953a-4967-b96b-59060f2a88fc", "AQAAAAEAACcQAAAAEDQh5cUNaO9hNvnyfm2NCnMx1Vk0j3TrL9yOzvqjNqb7/O7Ije5vR41yEtpTA0EOgQ==", "5378d9a2-4824-42a6-97bd-ce38e5e9d753" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "AgentId", "AverageDivingRange", "Color", "Details", "ImageUrls", "Location", "Make", "Mileage", "Model", "OwnerId", "Power", "Price", "Title", "VehicleTypeId", "Year" },
                values: new object[] { 2, null, 330, "Yellow", "Fuel Type: Electricity, Acceleration: 0 - 100 km/h: 8 sec, Maximum speed: 150 km/h (93.21 mph), Weight-to-power ratio: 9.7 kg/Hp, 103.4 Hp/tonne, Weight-to-torque ratio: 5.9 kg/Nm, 169 Nm", "https://www.auto-data.net/images/f46/Renault-5-E-Tech_1.jpg", "3118 Thunder Road, San Jose, CA, 95134", "Renault", 0, "5 E-Tech", 1, 150, 32000.00m, "2024 Renault 5 E-Tech 52 kWh (150 hp) Electric", 3, new DateTime(2024, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
