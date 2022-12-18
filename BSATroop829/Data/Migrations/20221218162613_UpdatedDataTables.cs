using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSATroop829.Data.Migrations
{
    public partial class UpdatedDataTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeofDay",
                table: "SummerCamp");

            migrationBuilder.AlterColumn<string>(
                name: "Priority",
                table: "SummerCamp",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Prerequisites",
                table: "SummerCamp",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MeritBadge",
                table: "SummerCamp",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "TimeSlot",
                table: "SummerCamp",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeSlot",
                table: "SummerCamp");

            migrationBuilder.AlterColumn<string>(
                name: "Priority",
                table: "SummerCamp",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Prerequisites",
                table: "SummerCamp",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MeritBadge",
                table: "SummerCamp",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeofDay",
                table: "SummerCamp",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
