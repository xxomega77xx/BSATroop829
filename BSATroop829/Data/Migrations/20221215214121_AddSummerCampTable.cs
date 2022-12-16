using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSATroop829.Data.Migrations
{
    public partial class AddSummerCampTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SummerCamp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScoutName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeritBadge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeofDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EagleRequired = table.Column<bool>(type: "bit", nullable: false),
                    Prerequisites = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummerCamp", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SummerCamp");
        }
    }
}
