using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionVehicleProperty.Infrastructure.Migrations
{
    public partial class AddedAuctionOwnerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Auctions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Winner agent Identyfier");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85749043-accc-43c2-9766-b5ea7fec98bd", "AQAAAAEAACcQAAAAEKae+KnUITg/zKAhq06qhyzJZMRnOw0kjpqj60Jv1rSv5zum0hq9kCwwJfsvaJtSYQ==", "16c653fa-2592-4d2a-8963-efc6b3b4bce9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591s",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "10bca9bf-e44d-4961-be56-f6e7bf51490c", "85a04555-0801-4faf-83da-54d4a4b25a66" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46a495bf-6e61-42e7-877b-d674650fbc82", "AQAAAAEAACcQAAAAEHp9HsOFw6o+gX82IMO5/naLjULJPxe1sZCxk44EeBnQcCMKVr7kk5egRgM7kXPqgw==", "0ce5a63b-535d-4e07-8b3f-5c3109ab64aa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37370d3f-ba3e-4fe1-9f69-d1e93ab5b96e", "AQAAAAEAACcQAAAAECp2NKdZxetC8QcfniQNCJvFUUIsr60nJOXCtCp4pITabvOznQBd42Eq6z6N3BNITw==", "730c8598-9101-485a-af89-a7555d82d1f7" });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatorId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Auctions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd085a0b-0cc9-420b-bbeb-fd6a30182365", "AQAAAAEAACcQAAAAEC4RSJdBBJIGlrWnPK0IldwU7oDqrxnOAIGxecuQjwyKQKgE5AWGvbax4Xt/GwgIEA==", "7abd5d23-4481-421e-82d5-80b8df6c422e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591s",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2d73158f-5e30-4ba0-a0bb-7ab3dd3bafc0", "94e9f546-63a9-41be-9436-75c3cdbf6574" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f23b4a62-8279-499c-8966-ff833026be71", "AQAAAAEAACcQAAAAEL8yJpMNY076BEi4J6XFl2MJP9USnJiJY6XIYcoZuQKywE2xGY5HwNEO3K23ZbjARw==", "1462a438-c375-4c34-ba64-fb8f45d94684" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84e70ddb-9c75-46fc-b827-e6495d81a5a9", "AQAAAAEAACcQAAAAEAf0RVVmR6Mm452iMtrwajkEt75jZFhJ8UdTi3GyWgVK6ZLzfMboC67d7lHKS9p3AQ==", "777dbc6b-9900-44f3-a13a-b5fee8af1f4a" });
        }
    }
}
