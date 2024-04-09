using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionVehicleProperty.Infrastructure.Migrations
{
    public partial class RemovingHybrid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a341eada-d236-4bba-a5e9-0a7e8ee82939", "AQAAAAEAACcQAAAAEAqyK+h/3PFA1eSlGKwjKLlYtlBoW8QirWW0PP+h2MGZqCcExhqZsyj3rR1bOzVpMA==", "661e0913-0c0c-46ea-8ef9-dfb3827a3af6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591s",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2edafac7-2e1f-4edb-9ef2-900dc13ee541", "6be1a72c-f80b-40a4-a13a-71ac9fa99d40" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f39e004-970c-4af2-87ca-051f2c211a76", "AQAAAAEAACcQAAAAEPd4d9mOBHmJcRPT5Ybu4ZRqT46p8NL7/o7idFq1+f8XfuMppLhY864H/erDY4c4GQ==", "4e37be84-f297-4062-8bb7-34735016cc26" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AverageDivingRange", "Color", "Details", "ImageUrls", "Make", "Model", "Power", "Title", "VehicleTypeId" },
                values: new object[] { 290, "Green", "The e-208 comes with various features for comfort, convenience, and safety, similar to other Peugeot models. These may include:Advanced infotainment system with touchscreen interfaceDriver assistance technologies such as adaptive cruise control and lane-keeping assistComfort features like climate control and heated seats Safety features including multiple airbags, anti-lock braking system (ABS), and electronic stability control (ESC)", "https://ev-database.org/img/auto/Peugeot_e-208_2024/Peugeot_e-208_2024-01.jpg", "Peugeot", "e-208", 134, "Peugeot e-208 50 kWh", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b82cfbd-32f3-4670-b231-4b78b5f19a18", "AQAAAAEAACcQAAAAEAyxqUe+1fWt1DLTXofpIlaEHL+I9xQ5fnnM6L4vIt8yo+GTn5mck+SJpBJ6YQHLtA==", "6ffc8bd1-3272-44ce-a693-afc6caca080c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591s",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b5fe9ca7-a5b2-44e4-a499-9d1c9497ec37", "d1f86e1a-7256-458b-b13f-46acb7253b15" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77b681eb-b04d-4092-adbe-a40ed959925d", "AQAAAAEAACcQAAAAEDFy5U0jq/cIGnwUjs0rY2Xb7RDm+vgx5CQLNZKzAu34ZVabTitB51KqJl8W9ytuZQ==", "91d436ef-ba48-4e6e-bd09-4b2deb4ad474" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AverageDivingRange", "Color", "Details", "ImageUrls", "Make", "Model", "Power", "Title", "VehicleTypeId" },
                values: new object[] { null, "Blue", "Modification (Engine): ST-Line 2.5 (243 Hp) Plug-in Hybrid CVT, Powertrain Architecture: PHEV (Plug-in Hybrid Electric Vehicle), Combined fuel consumption: 0.9-1.2 l/100 km, CO2 emissions: 20-28 g/km, Fuel Type: Petrol / electricity, Acceleration 0 - 100 km/h: 7.3 sec, Acceleration 0 - 62 mph: 7.3 sec, Maximum speed: 200 km/h (124.27 mph), Emission standard: Euro 6d.", "https://www.auto-data.net/en/ford-kuga-iii-facelift-2024-st-line-2.5-243hp-plug-in-hybrid-cvt-51008#image1", "Ford", "Kuga III facelift", 243, "2024 Ford Kuga III ST-Line 2.5 (243 кс) Plug-in Hybrid CVT", 1 });
        }
    }
}
