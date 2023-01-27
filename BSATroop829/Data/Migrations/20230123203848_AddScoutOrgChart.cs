using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSATroop829.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddScoutOrgChart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoyTroopOrgChart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScoutMaster = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssistantScoutMaster = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssistantScoutMaster2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssistantScoutMaster3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeniorPatrolLeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssistantSeniorPatrolLeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatrolLeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatrolLeader2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatrolLeader3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssistantPatrolLeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssistantPatrolLeader2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssistantPatrolLeader3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Intructor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bugler = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quartermaster = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChaplainAide = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Librarian = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Historian = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Scribe = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoyTroopOrgChart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GirlTroopOrgChart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScoutMaster = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssistantScoutMaster = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssistantScoutMaster2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssistantScoutMaster3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeniorPatrolLeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssistantSeniorPatrolLeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatrolLeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatrolLeader2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatrolLeader3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssistantPatrolLeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssistantPatrolLeader2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssistantPatrolLeader3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Intructor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bugler = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quartermaster = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChaplainAide = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Librarian = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Historian = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Scribe = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GirlTroopOrgChart", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoyTroopOrgChart");

            migrationBuilder.DropTable(
                name: "GirlTroopOrgChart");
        }
    }
}
