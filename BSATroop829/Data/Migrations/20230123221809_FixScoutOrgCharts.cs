using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSATroop829.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixScoutOrgCharts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Intructor",
                table: "GirlTroopOrgChart",
                newName: "Instructor");

            migrationBuilder.RenameColumn(
                name: "Intructor",
                table: "BoyTroopOrgChart",
                newName: "Instructor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Instructor",
                table: "GirlTroopOrgChart",
                newName: "Intructor");

            migrationBuilder.RenameColumn(
                name: "Instructor",
                table: "BoyTroopOrgChart",
                newName: "Intructor");
        }
    }
}
