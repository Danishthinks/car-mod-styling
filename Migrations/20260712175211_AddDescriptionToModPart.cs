using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car_Mod_net.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionToModPart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ModParts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ModParts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Ultra-lightweight aerospace-grade carbon fiber hood with integrated aerodynamic vents. Optimizes engine cooling and reduces front-axle weight.");

            migrationBuilder.UpdateData(
                table: "ModParts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Track-ready monoblock forged aluminum wheels designed to withstand intense lateral load. Finished in raw matte obsidian.");

            migrationBuilder.UpdateData(
                table: "ModParts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Multi-layered premium vinyl wrap with a liquid chrome satin finish. Protects original paint while delivering an aggressive, reflective styling.");

            migrationBuilder.UpdateData(
                table: "ModParts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Adjustable dual-plane carbon fiber rear wing engineered to maximize downforce and stability at high speeds.");

            migrationBuilder.UpdateData(
                table: "ModParts",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Next-gen nano-ceramic film providing up to 99% infrared heat rejection and dark stealth styling without signal interference.");

            migrationBuilder.UpdateData(
                table: "ModParts",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "Titanium active-valve catback exhaust system with vacuum-controlled valves. Features blue-burnt tips and delivers a raw, unrestrained acoustic profile.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ModParts");
        }
    }
}
