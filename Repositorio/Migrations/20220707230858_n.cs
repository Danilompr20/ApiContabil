using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositorio.Migrations
{
    public partial class n : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PapelId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PapelId",
                table: "Usuarios",
                column: "PapelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Papeis_PapelId",
                table: "Usuarios",
                column: "PapelId",
                principalTable: "Papeis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Papeis_PapelId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_PapelId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "PapelId",
                table: "Usuarios");
        }
    }
}
