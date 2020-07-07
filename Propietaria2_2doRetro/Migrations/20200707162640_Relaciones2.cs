using Microsoft.EntityFrameworkCore.Migrations;

namespace Propietaria2_2doRetro.Migrations
{
    public partial class Relaciones2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cast_MovieId",
                table: "Cast",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cast_Movie_MovieId",
                table: "Cast",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cast_Movie_MovieId",
                table: "Cast");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropIndex(
                name: "IX_Cast_MovieId",
                table: "Cast");
        }
    }
}
