using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaisseEnregistreuse.NET.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeDeCartes",
                columns: table => new
                {
                    TypeDeCarteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeDeCartes", x => x.TypeDeCarteId);
                });

            migrationBuilder.CreateTable(
                name: "Cartes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Prix = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    QuantiteEnStock = table.Column<int>(type: "int", nullable: false),
                    TypeDeCarteId = table.Column<int>(type: "int", nullable: false),
                    ImageCarte = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cartes_TypeDeCartes_TypeDeCarteId",
                        column: x => x.TypeDeCarteId,
                        principalTable: "TypeDeCartes",
                        principalColumn: "TypeDeCarteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cartes_TypeDeCarteId",
                table: "Cartes",
                column: "TypeDeCarteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cartes");

            migrationBuilder.DropTable(
                name: "TypeDeCartes");
        }
    }
}
