using Microsoft.EntityFrameworkCore.Migrations;

namespace Propietaria2_2doRetro.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "BoxOffice",
                table: "Movie",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Budget",
                table: "Movie",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ClasificacionId",
                table: "Movie",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DirectorId",
                table: "Movie",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LenguajeId",
                table: "Movie",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Movie",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NominacionesOscar",
                table: "Movie",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OscarGanados",
                table: "Movie",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaisId",
                table: "Movie",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Sipnosis",
                table: "Movie",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StudioId",
                table: "Movie",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Lenguaje",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lenguaje", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_ClasificacionId",
                table: "Movie",
                column: "ClasificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_DirectorId",
                table: "Movie",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_LenguajeId",
                table: "Movie",
                column: "LenguajeId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_PaisId",
                table: "Movie",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_StudioId",
                table: "Movie",
                column: "StudioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Clasificacion_ClasificacionId",
                table: "Movie",
                column: "ClasificacionId",
                principalTable: "Clasificacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Director_DirectorId",
                table: "Movie",
                column: "DirectorId",
                principalTable: "Director",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Lenguaje_LenguajeId",
                table: "Movie",
                column: "LenguajeId",
                principalTable: "Lenguaje",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Pais_PaisId",
                table: "Movie",
                column: "PaisId",
                principalTable: "Pais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Estudio_StudioId",
                table: "Movie",
                column: "StudioId",
                principalTable: "Estudio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Clasificacion_ClasificacionId",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Director_DirectorId",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Lenguaje_LenguajeId",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Pais_PaisId",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Estudio_StudioId",
                table: "Movie");

            migrationBuilder.DropTable(
                name: "Lenguaje");

            migrationBuilder.DropIndex(
                name: "IX_Movie_ClasificacionId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_DirectorId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_LenguajeId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_PaisId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_StudioId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "BoxOffice",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Budget",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "ClasificacionId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "DirectorId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "LenguajeId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "NominacionesOscar",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "OscarGanados",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "PaisId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Sipnosis",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "StudioId",
                table: "Movie");
        }
    }
}
