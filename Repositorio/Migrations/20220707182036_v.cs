using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositorio.Migrations
{
    public partial class v : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosPapeis_Papeis_IdPapel",
                table: "UsuariosPapeis");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosPapeis_Usuarios_IdUsuario",
                table: "UsuariosPapeis");

            migrationBuilder.DropIndex(
                name: "IX_UsuariosPapeis_IdPapel",
                table: "UsuariosPapeis");

            migrationBuilder.AddColumn<int>(
                name: "PapelId",
                table: "UsuariosPapeis",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "UsuariosPapeis",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosPapeis_PapelId",
                table: "UsuariosPapeis",
                column: "PapelId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosPapeis_UsuarioId",
                table: "UsuariosPapeis",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosPapeis_Papeis_PapelId",
                table: "UsuariosPapeis",
                column: "PapelId",
                principalTable: "Papeis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosPapeis_Usuarios_UsuarioId",
                table: "UsuariosPapeis",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosPapeis_Papeis_PapelId",
                table: "UsuariosPapeis");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosPapeis_Usuarios_UsuarioId",
                table: "UsuariosPapeis");

            migrationBuilder.DropIndex(
                name: "IX_UsuariosPapeis_PapelId",
                table: "UsuariosPapeis");

            migrationBuilder.DropIndex(
                name: "IX_UsuariosPapeis_UsuarioId",
                table: "UsuariosPapeis");

            migrationBuilder.DropColumn(
                name: "PapelId",
                table: "UsuariosPapeis");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "UsuariosPapeis");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosPapeis_IdPapel",
                table: "UsuariosPapeis",
                column: "IdPapel");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosPapeis_Papeis_IdPapel",
                table: "UsuariosPapeis",
                column: "IdPapel",
                principalTable: "Papeis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosPapeis_Usuarios_IdUsuario",
                table: "UsuariosPapeis",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
