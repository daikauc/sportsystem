using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportSystemAPI.Migrations
{
    public partial class Workouts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diff = table.Column<double>(type: "float", nullable: false),
                    Max = table.Column<int>(type: "int", nullable: false),
                    CurrCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Workouts");
        }
    }
}
