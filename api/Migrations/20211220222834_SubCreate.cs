using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportSystemAPI.Migrations
{
    public partial class SubCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Start = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    End = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stopped = table.Column<bool>(type: "bit", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subs");
        }
    }
}
