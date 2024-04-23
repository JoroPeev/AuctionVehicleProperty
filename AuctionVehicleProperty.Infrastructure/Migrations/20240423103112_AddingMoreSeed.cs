using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionVehicleProperty.Infrastructure.Migrations
{
    public partial class AddingMoreSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "990984a5-ac81-41c7-bb8a-a86b3c6d5cd5", "AQAAAAEAACcQAAAAEFfh68V/GC6BALuuwaEuOASdZa9KeM0Kmd5l59SBDtWMfgsLlktvF9V+d+KorzLY/A==", "057400a5-999e-4517-a54e-f92386ecd7c9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591s",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e99b7f89-69c9-4453-9567-60631f8ff16d", "84d3068a-a295-4fc8-9593-cd00dba062cf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "180162a7-e8cd-4a6f-8c7f-01c24926897c", "AQAAAAEAACcQAAAAEGwqThX/atnPVlKSbm46gxp07u4hUu74ra4Sxmf7UeWlMeyxAPHNG5ZccLT/wUul/g==", "c9bd38f1-9730-4807-99c3-472f2d34c6d0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d47d9fd7-9623-4593-baba-099b903a79c7", "AQAAAAEAACcQAAAAEGwc1FGxSDSYBVYltEJO4i4spvYsDanba7rSE7DhnnllI0mmd6wxuon/hok2BI3CXA==", "fe5fe5b2-ff15-4b8d-b972-5f00188e6bc8" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "AgentId", "AverageDivingRange", "Color", "Details", "ImageUrls", "Location", "Make", "Mileage", "Model", "OwnerId", "Power", "Price", "Title", "VehicleTypeId", "Year" },
                values: new object[,]
                {
                    { 2, null, 209, "Green", "This is the electric version of Peugeot’s 208 supermini. It looks very much like the combustion-engined alternative: this isn’t a car for anyone who wants to show off their zero-emission, planet-saving credentials.", "https://ev-database.org/img/auto/Peugeot_e-208_2024/Peugeot_e-208_2024-01.jpg", "679 Grandrose Rd.,Somerset, NJ 08873", "Peugeot", 0, "e-208", 1, 130, 73000.00m, "Peugeot e-208 50 kWh", 3, new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, null, 350, "Red", "The model shown on this page is the successor of the Ford Mustang Mach-E ER AWD, which was available to order from April 2022 until November 2022. The previous model had 40 km less range, 17% faster acceleration and was 9% less energy efficient.", "https://ev-database.org/img/auto/Ford_Mustang_Mach-E/Ford_Mustang_Mach-E-01.jpg", "44 Willow Street, Piqua, OH 45356", "Ford ", 10000, " Mustang Mach-E", 1, 280, 122000.00m, "Ford Mustang Mach-E ER RWD", 1, new DateTime(2023, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c55ac48-1324-45f3-a3bf-4d4653cf5908", "AQAAAAEAACcQAAAAELJ9gQRgdlaOQLPy4EqpKJ1fHmS8CPO4lI201FPEhQErqdjzK2lWPYPZQbFSVFv3oQ==", "fe135a08-2aa2-4acf-9fbd-924207b136d8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591s",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d3855109-7bcb-485c-960b-efef4334a4be", "2826b42c-9c4e-41a7-92e2-d63b245030df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ef1bdcd-8a58-4a90-a49d-d7b1ed8d3882", "AQAAAAEAACcQAAAAEPqo+8qmdLSYgqHbbKi6TWDbhwx2Fqydrz9SZmTtJZ2q5tLXxdftotajPCrEtoo1xg==", "27318305-7411-45eb-aa66-3199e19f4af2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18c8c8c3-c7f8-4d12-813a-8b92e94785e5", "AQAAAAEAACcQAAAAECR409kbNTP6h1nvcVxalM3QDxIFAS6a9PjfKuBB4mPrQCOYBhXxdpzxas9tyt4c8w==", "f76f72fe-ee73-416e-b9b8-682f186bb8e2" });
        }
    }
}
