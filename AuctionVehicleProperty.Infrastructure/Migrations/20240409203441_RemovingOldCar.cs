using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionVehicleProperty.Infrastructure.Migrations
{
    public partial class RemovingOldCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AverageDivingRange", "Color", "Details", "ImageUrls", "Location", "Make", "Model", "Power", "Price", "Title" },
                values: new object[] { 330, "Yellow", "Fuel Type: Electricity, Acceleration: 0 - 100 km/h: 8 sec, Maximum speed: 150 km/h (93.21 mph), Weight-to-power ratio: 9.7 kg/Hp, 103.4 Hp/tonne, Weight-to-torque ratio: 5.9 kg/Nm, 169 Nm", "https://www.auto-data.net/images/f46/Renault-5-E-Tech_1.jpg", "3118 Thunder Road, San Jose, CA, 95134", "Renault", "5 E-Tech", 150, 32000.00m, "2024 Renault 5 E-Tech 52 kWh (150 hp) Electric" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "375c5eb0-43c6-4797-be96-806b36863acb", "AQAAAAEAACcQAAAAEN2PAVHeI2qxWv75NUAuQwM5MTwXSnzsTWgDpcx//kRcMvg9M/It+B122nK8uDDkFQ==", "006ffdad-abc6-4d81-9b0e-934d2d479e63" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591s",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4764c925-3a01-42b8-bcd6-4da13e2ab3d2", "41fa3b10-e310-46ec-838a-4b39546dcd4c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a02cd3cd-8eb3-48fe-88d5-e9fcdbb6abb6", "AQAAAAEAACcQAAAAECO/qbJdD36RfBs0jktYkf3T3ZFrsa39p1X2WI/ooKutFiQ8kPiexr7Qi7USbeVU8w==", "845ba8ef-0cc0-4ce0-b0e4-d044e5fbfab3" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AverageDivingRange", "Color", "Details", "ImageUrls", "Location", "Make", "Model", "Power", "Price", "Title" },
                values: new object[] { 290, "Green", "The e-208 comes with various features for comfort, convenience, and safety, similar to other Peugeot models. These may include:Advanced infotainment system with touchscreen interfaceDriver assistance technologies such as adaptive cruise control and lane-keeping assistComfort features like climate control and heated seats Safety features including multiple airbags, anti-lock braking system (ABS), and electronic stability control (ESC)", "https://ev-database.org/img/auto/Peugeot_e-208_2024/Peugeot_e-208_2024-01.jpg", "3189 Duke Lane, Newark, NJ, 07102", "Peugeot", "e-208", 134, 37610.00m, "Peugeot e-208 50 kWh" });
        }
    }
}
