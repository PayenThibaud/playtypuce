using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.Migrations
{
    public partial class MigrationTodo1 : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "todoListClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatutEnCours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_todoListClasses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "todoListClasses",
                columns: new[] { "Id", "Description", "StatutEnCours", "Titre" },
                values: new object[] { 1, "Préparer la venue de belle-maman", 1, "Rangement" });

            migrationBuilder.InsertData(
                table: "todoListClasses",
                columns: new[] { "Id", "Description", "StatutEnCours", "Titre" },
                values: new object[] { 2, "Promener Médor et faire attention au chien de la voisine", 0, "Promenade" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "todoListClasses");
        }
    }
}
