using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car_Mod_net.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageSeedExtensions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ModParts",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/images/carbon-hood.jpg");

            migrationBuilder.UpdateData(
                table: "ModParts",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/images/forged-wheels.jpg");

            migrationBuilder.UpdateData(
                table: "ModParts",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/images/chrome-wrap.jpg");

            migrationBuilder.UpdateData(
                table: "ModParts",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/images/rear-wing.jpg");

            migrationBuilder.UpdateData(
                table: "ModParts",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/images/stealth-tint.jpg");

            migrationBuilder.UpdateData(
                table: "ModParts",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "/images/titanium-exhaust.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ModParts",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/images/carbon-hood.webp");

            migrationBuilder.UpdateData(
                table: "ModParts",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/images/forged-wheels.webp");

            migrationBuilder.UpdateData(
                table: "ModParts",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/images/chrome-wrap.webp");

            migrationBuilder.UpdateData(
                table: "ModParts",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/images/rear-wing.webp");

            migrationBuilder.UpdateData(
                table: "ModParts",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/images/stealth-tint.webp");

            migrationBuilder.UpdateData(
                table: "ModParts",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "/images/titanium-exhaust.webp");
        }
    }
}
