using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionVehicleProperty.Infrastructure.Migrations
{
    public partial class SeedingAuctionsConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Auctions",
                columns: new[] { "Id", "CreatorId", "EndTime", "MinimumBidIncrement", "StartingPrice", "StartingTime", "VehicleId", "WinnerIdAgent", "WinnerIdUser" },
                values: new object[,]
                {
                    { 2, 1, new DateTime(2024, 4, 28, 18, 30, 0, 0, DateTimeKind.Unspecified), 300.00m, 122000.00m, new DateTime(2024, 4, 28, 16, 30, 0, 0, DateTimeKind.Unspecified), 3, null, null },
                    { 3, 1, new DateTime(2024, 4, 28, 18, 30, 0, 0, DateTimeKind.Unspecified), 200.00m, 73000.00m, new DateTime(2024, 4, 28, 16, 30, 0, 0, DateTimeKind.Unspecified), 2, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 3);

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
        }
    }
}
