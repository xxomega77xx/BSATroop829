using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSATroop829.Data.Migrations
{
    /// <inheritdoc />
    public partial class MeritBadgeCouselorModKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeritBadgeCounselors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeritBadgeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CounselorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CounselorPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeritBadgeCounselors", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeritBadgeCounselors");
        }
    }
}
