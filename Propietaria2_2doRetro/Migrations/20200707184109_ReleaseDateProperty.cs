using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Propietaria2_2doRetro.Migrations
{
    public partial class ReleaseDateProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Estreno",
                table: "Movie",
                nullable: false,
                defaultValue: DateTime.Now,
                defaultValueSql: "getdate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estreno",
                table: "Movie");
        }
    }
}
