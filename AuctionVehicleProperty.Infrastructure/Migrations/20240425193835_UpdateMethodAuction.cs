using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionVehicleProperty.Infrastructure.Migrations
{
    public partial class UpdateMethodAuction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f66a3bc-90b3-405a-ba9d-29f1b6120b5c", "AQAAAAEAACcQAAAAEGocuEkLdBzNo+gpu+3Y+HPhMI4X8Fvb04Ca33ea1QCWVNZvvcm/c+4PCFol8QeapQ==", "76b8525b-6142-4b0c-92d5-094cc1a54912" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591s",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8df7d955-7db9-4cfe-805d-3cc85c6a3fd2", "ccf49863-85b3-4a92-a4f8-fb5b2bd3e926" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d86d650c-482b-412d-ba7b-fee11e77f399", "AQAAAAEAACcQAAAAEKTS/K53ownToiVARMEoiftW+YEB/7X53A51+THL2tIC14Z1gxHAQBd/+Hc3LgqaiA==", "689c9137-1a31-4cb8-bba6-ae9825934683" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cae30748-e8a7-4ad9-9269-f4ead894a8b0", "AQAAAAEAACcQAAAAECkbRvYUD1XD2fQSp0e6vCwzGTwwU7PLu4xUsqAbnA3mP+ZF8hDSC7Sn9DbsUQcCDw==", "b71d5285-27aa-4749-8320-e271a5e644cf" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0fe4bc24-f820-4ec2-bd8e-087f18df5c3f", "AQAAAAEAACcQAAAAEKUoFpj/AgxVChnplT3YskJzG9v+gxjIfSXYswArG07D4bjIPpR//a1ujtIiXSPzyw==", "391f9252-d349-49bb-a96b-caf89e1edd1f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591s",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ed112d35-31b1-4958-96e6-a3f184611de7", "7ab73de1-f332-492a-9139-bcc8db3894da" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "947ac064-6d16-4f09-982e-e2b6f5128d2a", "AQAAAAEAACcQAAAAEM/rXY8M3aoaPoQt1cK+QUqQ0RTARbKw4y5GaGESMSyKAGgbOQhvR77MSEAiq4u/lg==", "ce752bdd-42c1-4feb-9d3a-08f77ea592e9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4534eac1-ab05-49b4-ba8f-73f158113186", "AQAAAAEAACcQAAAAEBYvlnMtNWrEiSjEW3ikVhq/rezxyR9jCeDmV5bqVMuO4adByCIK21augNtMd30W4A==", "6f74d6df-242d-4886-9995-e8142f8acc44" });
        }
    }
}
