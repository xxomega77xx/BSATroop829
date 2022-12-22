using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSATroop829.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMeritBadgePriorities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "SummerCamp",
                newName: "Priority9");

            migrationBuilder.AddColumn<string>(
                name: "Priority1",
                table: "SummerCamp",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Priority10",
                table: "SummerCamp",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Priority11",
                table: "SummerCamp",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Priority12",
                table: "SummerCamp",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Priority2",
                table: "SummerCamp",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Priority3",
                table: "SummerCamp",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Priority4",
                table: "SummerCamp",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Priority5",
                table: "SummerCamp",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Priority6",
                table: "SummerCamp",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Priority7",
                table: "SummerCamp",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Priority8",
                table: "SummerCamp",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority1",
                table: "SummerCamp");

            migrationBuilder.DropColumn(
                name: "Priority10",
                table: "SummerCamp");

            migrationBuilder.DropColumn(
                name: "Priority11",
                table: "SummerCamp");

            migrationBuilder.DropColumn(
                name: "Priority12",
                table: "SummerCamp");

            migrationBuilder.DropColumn(
                name: "Priority2",
                table: "SummerCamp");

            migrationBuilder.DropColumn(
                name: "Priority3",
                table: "SummerCamp");

            migrationBuilder.DropColumn(
                name: "Priority4",
                table: "SummerCamp");

            migrationBuilder.DropColumn(
                name: "Priority5",
                table: "SummerCamp");

            migrationBuilder.DropColumn(
                name: "Priority6",
                table: "SummerCamp");

            migrationBuilder.DropColumn(
                name: "Priority7",
                table: "SummerCamp");

            migrationBuilder.DropColumn(
                name: "Priority8",
                table: "SummerCamp");

            migrationBuilder.RenameColumn(
                name: "Priority9",
                table: "SummerCamp",
                newName: "Priority");
        }
    }
}
