using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionVehicleProperty.Infrastructure.Migrations
{
    public partial class DeleteCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Auctions_AuctionId",
                table: "Bids");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "914d1b12-67ad-488f-bb86-d222f09da06f", "AQAAAAEAACcQAAAAEIFrbtanxfCGDAA/TDvvCrL9/CRSzHec0ZVZP0DULMNbXAEnvwFyk2yEWTR4XsEilA==", "28d3b349-2034-4448-9137-c517d8aa558d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591s",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fa0d03c7-e7ed-42df-b7a6-581ff5e2529c", "21b4d57c-1f20-444f-9b7d-337c561116dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1ed7d80-0864-407e-b83d-154ffb04c1f9", "AQAAAAEAACcQAAAAEKNqvJdgAM7SlOwe4vaHVKQWfNkoI57DmJKKTMsJA8bb6rRxK5JRulWg32ldJDvg/Q==", "576b43d9-00b3-4051-b55f-ae754d654ad9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c393889-55b0-4937-80ee-980a07dc17af", "AQAAAAEAACcQAAAAEAd9DdsHv5DmdXUI1eZHCkgmKfgERntWZAE+9TareiAKu4N81IQipMJnU+pLUFHo4w==", "4408fd20-cdd0-45f7-876c-cbebd4c6a712" });

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Auctions_AuctionId",
                table: "Bids",
                column: "AuctionId",
                principalTable: "Auctions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Auctions_AuctionId",
                table: "Bids");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Auctions_AuctionId",
                table: "Bids",
                column: "AuctionId",
                principalTable: "Auctions",
                principalColumn: "Id");
        }
    }
}
