using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionVehicleProperty.Infrastructure.Migrations
{
    public partial class AddingWinnerInAution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WinnerID",
                table: "Auctions");

            migrationBuilder.AddColumn<string>(
                name: "WinnerIdAgent",
                table: "Auctions",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Winner agent Identyfier");

            migrationBuilder.AddColumn<int>(
                name: "WinnerIdUser",
                table: "Auctions",
                type: "int",
                nullable: true,
                comment: "Winner user Identyfier");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8993df7-ea92-4caa-b2ec-065d6991ad1a", "AQAAAAEAACcQAAAAEKIQVLr5hcIuDZwSwuzkiVXbiaSalcfQh+iiDLT439CMb+dwaKNi8NFCtoVJU+zg4w==", "781ae882-fa11-47fd-bf79-5607ba9eeb28" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591s",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "68771807-5be3-4e75-ad1a-e3616431c6cb", "57797835-3946-4c13-988f-97d987252e91" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a63a14fa-cf8b-46f2-985a-a8cd8965d505", "AQAAAAEAACcQAAAAEAoNthGyZZ8o6JGDt2dt+GbauqZVzsu6asCCOnSMkPvJkahSDNxqbmwi+9y/W27PCA==", "33a45a9f-d0c9-4c1e-b375-281c5007e2fd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WinnerIdAgent",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "WinnerIdUser",
                table: "Auctions");

            migrationBuilder.AddColumn<int>(
                name: "WinnerID",
                table: "Auctions",
                type: "int",
                nullable: true,
                comment: "Winner Identyfier");

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
        }
    }
}
