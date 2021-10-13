using Microsoft.EntityFrameworkCore.Migrations;

namespace Play.Migrations
{
    public partial class AddModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nintendo",
                columns: table => new
                {
                    nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    autor = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    letra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nintendo", x => x.nombre);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nintendo");
        }
    }
}
