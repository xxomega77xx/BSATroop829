using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSATroop829.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTrooptoData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Troop",
                table: "TroopEagles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Troop",
                table: "TroopEagles");
        }
    }
}
