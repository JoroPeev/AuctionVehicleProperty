using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionVehicleProperty.Infrastructure.Migrations
{
    public partial class AddingType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
