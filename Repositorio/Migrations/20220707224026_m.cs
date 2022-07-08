using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositorio.Migrations
{
    public partial class m : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PapelUsuario",
                table: "PapelUsuario");

            migrationBuilder.DropIndex(
                name: "IX_PapelUsuario_UsuarioId",
                table: "PapelUsuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PapelUsuario",
                table: "PapelUsuario",
                columns: new[] { "UsuarioId", "PapelId" });

            migrationBuilder.CreateIndex(
                name: "IX_PapelUsuario_PapelId",
                table: "PapelUsuario",
                column: "PapelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PapelUsuario",
                table: "PapelUsuario");

            migrationBuilder.DropIndex(
                name: "IX_PapelUsuario_PapelId",
                table: "PapelUsuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PapelUsuario",
                table: "PapelUsuario",
                columns: new[] { "PapelId", "UsuarioId" });

            migrationBuilder.CreateIndex(
                name: "IX_PapelUsuario_UsuarioId",
                table: "PapelUsuario",
                column: "UsuarioId");
        }
    }
}
