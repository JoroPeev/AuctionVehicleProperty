using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionVehicleProperty.Infrastructure.Migrations
{
    public partial class SeedingAuctions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f30a0b7-67f5-43b2-8fb8-de7e7b096c79", "AQAAAAEAACcQAAAAELfp9cXyd5HC3DzwZ8MPVMNqqIq2EBvrELBbT108uktzIYVQ0K45Nv9RP9Co7nzy+w==", "2bf4a022-16d8-45be-98cb-168b1e41dc40" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591s",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a848bd4a-97ae-46ea-b094-333005a2fc57", "09f62c49-8638-4331-982f-1da388aabd25" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd207847-e022-4786-9772-bc5ccc99b18d", "AQAAAAEAACcQAAAAEFIu2SUiaP0jKYk5RgKtHZ/Ha7V9HPkJ8QpoXqVDnsQ3KxM8TIdxhPVUVnF2knU41A==", "e27a609c-54ad-48eb-8e2d-5d72ba057088" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "491ca45b-b7a6-42b6-b06a-62d91ffb40b0", "AQAAAAEAACcQAAAAEL2nGgS7MmWkJGTh9O+umsg+S0KJe4wyTc3kcsT0LVJtb3I90W4vhpianjW1in7Ntw==", "a6b3db6b-42dc-4052-8ada-68a3152bba2c" });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartingTime" },
                values: new object[] { new DateTime(2024, 4, 28, 18, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 28, 16, 30, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartingTime" },
                values: new object[] { new DateTime(2024, 4, 25, 14, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 12, 30, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
