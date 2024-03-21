using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionVehicleProperty.Infrastructure.Migrations
{
    public partial class SwichingProperiesType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WinnerIdUser",
                table: "Auctions",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Winner user Identyfier",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Winner user Identyfier");

            migrationBuilder.AlterColumn<int>(
                name: "WinnerIdAgent",
                table: "Auctions",
                type: "int",
                nullable: true,
                comment: "Winner agent Identyfier",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Winner agent Identyfier");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "WinnerIdUser",
                table: "Auctions",
                type: "int",
                nullable: true,
                comment: "Winner user Identyfier",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Winner user Identyfier");

            migrationBuilder.AlterColumn<string>(
                name: "WinnerIdAgent",
                table: "Auctions",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Winner agent Identyfier",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Winner agent Identyfier");

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
    }
}
