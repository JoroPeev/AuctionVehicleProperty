using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionVehicleProperty.Infrastructure.Migrations
{
    public partial class Initializing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "VehicleType Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "VehicleType Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Agent identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Agent's Email"),
                    Location = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, comment: "Agent's Location"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BidAuctionId = table.Column<int>(type: "int", nullable: true),
                    BidCustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Vehicle Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Vehicle Title"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Vehicle Image"),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false, comment: "VehicleType Identyfier"),
                    Make = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Vehicle Make"),
                    Model = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, comment: "Vehicle Model"),
                    Year = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Vehicle year of production"),
                    Mileage = table.Column<int>(type: "int", nullable: false, comment: "Vehicle Milage in kilometers"),
                    AverageDivingRange = table.Column<int>(type: "int", nullable: true, comment: "If is electric range of driving in kilometers"),
                    Power = table.Column<int>(type: "int", nullable: false, comment: "Vehicle Power in horse power or in Kw"),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Vehicle Collor"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Vehicle Price"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Location of the Vehicle"),
                    Details = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Vehicle Details"),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AgentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehicles_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_Categories_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Vehicle to sell or buy in auction");

            migrationBuilder.CreateTable(
                name: "Auctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Auction Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartingTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Starting Time"),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Ending Time"),
                    StartingPrice = table.Column<decimal>(type: "decimal(12,2)", nullable: false, comment: "Starting price for auction"),
                    MinimumBidIncrement = table.Column<decimal>(type: "decimal(12,2)", nullable: false, comment: "Auction Min bid incrementing"),
                    WinnerID = table.Column<int>(type: "int", nullable: true, comment: "Winner Identyfier"),
                    VehicleId = table.Column<int>(type: "int", nullable: false, comment: "Vehicle Identyfier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auctions_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    AuctionId = table.Column<int>(type: "int", nullable: false, comment: "Auction identifier"),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Customer Identifier"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(12,2)", nullable: false, comment: "Bid Amount"),
                    BidTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Bid Date and Time")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => new { x.AuctionId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_Bids_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bids_Auctions_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "Auctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BidAuctionId", "BidCustomerId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, null, null, "2339d6da-2405-482c-a66d-1e39ca0223c7", "guest@mail.com", false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEDZUI6KOHKS3uvF8dbKcv5pn2RCsaiyRfTRetxFE9E4HxSIXdRIQEh6Kw/HT+3FCzw==", null, false, "5bd06271-b4fc-4364-a4ee-e903f11700b3", false, "guest@mail.com" },
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591s", 0, null, null, "9424b354-529d-4fe1-a3c2-6ff3c098292f", "Secondguest@mail.com", false, false, null, "Secondguest@mail.com", "Secondguest@mail.com", null, null, false, "f20da5b3-3994-4026-b02b-f5ff169d3a84", false, "Secondguest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, null, null, "97499dc2-c988-4235-9906-0326f8a59a46", "agent@mail.com", false, false, null, "agent@mail.com", "agent@mail.com", "AQAAAAEAACcQAAAAECzbjMgVuY7Zr6CWYkWfOTzLmEM/LaDiTob6FXjK6WLA9PVXboSPIZgsjkAoNOcWQg==", null, false, "bf4ffc13-755f-44ac-9401-f25ec7231db2", false, "agent@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sport utility vehicle (SUV)" },
                    { 2, "Coupe" },
                    { 3, "Hatchback" },
                    { 4, "Convertible" },
                    { 5, "Pickup Truck" },
                    { 6, "Sedan" }
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "Email", "Location", "UserId" },
                values: new object[] { 1, "yuliusap@pertoys.shop", "San Jose 3118 Thunder Road", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "AgentId", "AverageDivingRange", "Color", "Details", "ImageUrl", "Location", "Make", "Mileage", "Model", "OwnerId", "Power", "Price", "Title", "VehicleTypeId", "Year" },
                values: new object[] { 1, null, 330, "Yellow", "Fuel Type: Electricity, Acceleration: 0 - 100 km/h: 8 sec, Maximum speed: 150 km/h (93.21 mph), Weight-to-power ratio: 9.7 kg/Hp, 103.4 Hp/tonne, Weight-to-torque ratio: 5.9 kg/Nm, 169 Nm", "https://www.auto-data.net/images/f46/Renault-5-E-Tech_1.jpg", "3118 Thunder Road, San Jose, CA, 95134", "Renault", 0, "5 E-Tech", "dea12856-c198-4129-b3f3-b893d8395082", 150, 32000.00m, "2024 Renault 5 E-Tech 52 kWh (150 hp) Electric", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2024) });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "AgentId", "AverageDivingRange", "Color", "Details", "ImageUrl", "Location", "Make", "Mileage", "Model", "OwnerId", "Power", "Price", "Title", "VehicleTypeId", "Year" },
                values: new object[] { 2, null, null, "Blue", "Modification (Engine): ST-Line 2.5 (243 Hp) Plug-in Hybrid CVT, Powertrain Architecture: PHEV (Plug-in Hybrid Electric Vehicle), Combined fuel consumption: 0.9-1.2 l/100 km, CO2 emissions: 20-28 g/km, Fuel Type: Petrol / electricity, Acceleration 0 - 100 km/h: 7.3 sec, Acceleration 0 - 62 mph: 7.3 sec, Maximum speed: 200 km/h (124.27 mph), Emission standard: Euro 6d.", "https://www.auto-data.net/images/f76/Ford-Kuga-III-facelift-2024_1.jpg", "3189 Duke Lane, Newark, NJ, 07102", "Ford", 0, "Kuga III facelift", "dea12856-c198-4129-b3f3-b893d83950", 243, 37610.00m, "2024 Ford Kuga III ST-Line 2.5 (243 кс) Plug-in Hybrid CVT", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2024) });

            migrationBuilder.InsertData(
                table: "Auctions",
                columns: new[] { "Id", "EndTime", "MinimumBidIncrement", "StartingPrice", "StartingTime", "VehicleId", "WinnerID" },
                values: new object[] { 1, new DateTime(2024, 4, 25, 14, 30, 0, 0, DateTimeKind.Unspecified), 500.00m, 25000.00m, new DateTime(2024, 4, 25, 12, 30, 0, 0, DateTimeKind.Unspecified), 1, null });

            migrationBuilder.InsertData(
                table: "Bids",
                columns: new[] { "AuctionId", "CustomerId", "Amount", "BidTime", "Id" },
                values: new object[] { 1, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 26000.00m, new DateTime(2024, 4, 25, 12, 42, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Bids",
                columns: new[] { "AuctionId", "CustomerId", "Amount", "BidTime", "Id" },
                values: new object[] { 1, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591s", 27000.00m, new DateTime(2024, 4, 25, 12, 43, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_Email",
                table: "Agents",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agents_UserId",
                table: "Agents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BidAuctionId_BidCustomerId",
                table: "AspNetUsers",
                columns: new[] { "BidAuctionId", "BidCustomerId" });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_VehicleId",
                table: "Auctions",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_CustomerId",
                table: "Bids",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_AgentId",
                table: "Vehicles",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_OwnerId",
                table: "Vehicles",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleTypeId",
                table: "Vehicles",
                column: "VehicleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_AspNetUsers_UserId",
                table: "Agents",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Bids_BidAuctionId_BidCustomerId",
                table: "AspNetUsers",
                columns: new[] { "BidAuctionId", "BidCustomerId" },
                principalTable: "Bids",
                principalColumns: new[] { "AuctionId", "CustomerId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_AspNetUsers_UserId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Bids_AspNetUsers_CustomerId",
                table: "Bids");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_AspNetUsers_OwnerId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Bids");

            migrationBuilder.DropTable(
                name: "Auctions");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
