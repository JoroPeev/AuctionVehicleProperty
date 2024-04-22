using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionVehicleProperty.Infrastructure.Migrations
{
    public partial class Inishalizing : Migration
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
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
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agents_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    ImageUrls = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Vehicle Images"),
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
                    OwnerId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Vehicles_Agents_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Agents",
                        principalColumn: "Id");
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
                    WinnerIdUser = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Winner user Identyfier"),
                    WinnerIdAgent = table.Column<int>(type: "int", nullable: true, comment: "Winner agent Identyfier"),
                    CreatorId = table.Column<int>(type: "int", nullable: false, comment: "Creator agent Identyfier"),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuctionId = table.Column<int>(type: "int", nullable: false, comment: "Auction identifier"),
                    AgentId = table.Column<int>(type: "int", nullable: false, comment: "Agent Identifier"),
                    Amount = table.Column<decimal>(type: "decimal(12,2)", nullable: false, comment: "Bid Amount"),
                    BidTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Bid Date and Time")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bids_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bids_Auctions_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "Auctions",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "4c55ac48-1324-45f3-a3bf-4d4653cf5908", "guest@mail.com", false, "Guest", "Guestov", false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAELJ9gQRgdlaOQLPy4EqpKJ1fHmS8CPO4lI201FPEhQErqdjzK2lWPYPZQbFSVFv3oQ==", null, false, "fe135a08-2aa2-4acf-9fbd-924207b136d8", false, "guest@mail.com" },
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591s", 0, "d3855109-7bcb-485c-960b-efef4334a4be", "Secondguest@mail.com", false, "", "", false, null, "Secondguest@mail.com", "Secondguest@mail.com", null, null, false, "2826b42c-9c4e-41a7-92e2-d63b245030df", false, "Secondguest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "0ef1bdcd-8a58-4a90-a49d-d7b1ed8d3882", "agent@mail.com", false, "Agent", "Agentov", false, null, "agent@mail.com", "agent@mail.com", "AQAAAAEAACcQAAAAEPqo+8qmdLSYgqHbbKi6TWDbhwx2Fqydrz9SZmTtJZ2q5tLXxdftotajPCrEtoo1xg==", null, false, "27318305-7411-45eb-aa66-3199e19f4af2", false, "agent@mail.com" },
                    { "e43ce836-997d-4927-ac59-74e8c41bbfd3", 0, "18c8c8c3-c7f8-4d12-813a-8b92e94785e5", "admin@mail.com", false, "Great", "Admin", false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAECR409kbNTP6h1nvcVxalM3QDxIFAS6a9PjfKuBB4mPrQCOYBhXxdpzxas9tyt4c8w==", null, false, "f76f72fe-ee73-416e-b9b8-682f186bb8e2", false, "admin@mail.com" }
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
                columns: new[] { "Id", "Email", "IsAdmin", "Location", "UserId" },
                values: new object[] { 1, "Kolio@gmail.com", false, "", "e43ce836-997d-4927-ac59-74e8c41bbfd3" });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "Email", "IsAdmin", "Location", "UserId" },
                values: new object[] { 2, "yuliusap@pertoys.shop", true, "San Jose 3118 Thunder Road", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "AgentId", "AverageDivingRange", "Color", "Details", "ImageUrls", "Location", "Make", "Mileage", "Model", "OwnerId", "Power", "Price", "Title", "VehicleTypeId", "Year" },
                values: new object[] { 1, null, 330, "Yellow", "Fuel Type: Electricity, Acceleration: 0 - 100 km/h: 8 sec, Maximum speed: 150 km/h (93.21 mph), Weight-to-power ratio: 9.7 kg/Hp, 103.4 Hp/tonne, Weight-to-torque ratio: 5.9 kg/Nm, 169 Nm", "https://www.auto-data.net/images/f46/Renault-5-E-Tech_1.jpg", "3118 Thunder Road, San Jose, CA, 95134", "Renault", 0, "5 E-Tech", 1, 150, 32000.00m, "2024 Renault 5 E-Tech 52 kWh (150 hp) Electric", 3, new DateTime(2024, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Auctions",
                columns: new[] { "Id", "CreatorId", "EndTime", "MinimumBidIncrement", "StartingPrice", "StartingTime", "VehicleId", "WinnerIdAgent", "WinnerIdUser" },
                values: new object[] { 1, 1, new DateTime(2024, 4, 25, 14, 30, 0, 0, DateTimeKind.Unspecified), 500.00m, 25000.00m, new DateTime(2024, 4, 25, 12, 30, 0, 0, DateTimeKind.Unspecified), 1, null, null });

            migrationBuilder.InsertData(
                table: "Bids",
                columns: new[] { "Id", "AgentId", "Amount", "AuctionId", "BidTime" },
                values: new object[] { 1, 1, 26000.00m, 1, new DateTime(2024, 4, 25, 12, 42, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Bids",
                columns: new[] { "Id", "AgentId", "Amount", "AuctionId", "BidTime" },
                values: new object[] { 2, 2, 27000.00m, 1, new DateTime(2024, 4, 25, 12, 43, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_Email",
                table: "Agents",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agents_UserId",
                table: "Agents",
                column: "UserId",
                unique: true);

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
                name: "IX_Bids_AgentId",
                table: "Bids",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_AuctionId",
                table: "Bids",
                column: "AuctionId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Bids");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Auctions");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
