using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Car_Mod_net.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModParts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModParts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Make = table.Column<string>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModParts",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "INTEGER", nullable: false),
                    ModPartId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModParts", x => new { x.VehicleId, x.ModPartId });
                    table.ForeignKey(
                        name: "FK_VehicleModParts_ModParts_ModPartId",
                        column: x => x.ModPartId,
                        principalTable: "ModParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleModParts_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ModParts",
                columns: new[] { "Id", "Category", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Body Kit", "/images/carbon-hood.webp", "Vented Carbon Fiber Hood", 1850.00m },
                    { 2, "Wheels", "/images/forged-wheels.webp", "Forged Monoblock Track Wheels", 4200.00m },
                    { 3, "Custom Paint", "/images/chrome-wrap.webp", "Satin Liquid Chrome Wrap", 3500.00m },
                    { 4, "Body Kit", "/images/rear-wing.webp", "Carbon Rear Wing Spoiler", 2200.00m },
                    { 5, "Window Tint", "/images/stealth-tint.webp", "Ceramic Infrared Stealth Tint", 650.00m },
                    { 6, "Exhaust", "/images/titanium-exhaust.webp", "Titanium Active Valve Exhaust", 3800.00m }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Make", "Model", "Year" },
                values: new object[,]
                {
                    { 1, "Honda", "Civic Type R", 2023 },
                    { 2, "Porsche", "911 GT3 RS", 2024 },
                    { 3, "Nissan", "GT-R (R35)", 2022 },
                    { 4, "Toyota", "GR Supra", 2023 }
                });

            migrationBuilder.InsertData(
                table: "VehicleModParts",
                columns: new[] { "ModPartId", "VehicleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 5, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 5, 2 },
                    { 6, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 3 },
                    { 4, 3 },
                    { 5, 3 },
                    { 6, 3 },
                    { 1, 4 },
                    { 2, 4 },
                    { 3, 4 },
                    { 4, 4 },
                    { 5, 4 },
                    { 6, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModParts_ModPartId",
                table: "VehicleModParts",
                column: "ModPartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleModParts");

            migrationBuilder.DropTable(
                name: "ModParts");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
