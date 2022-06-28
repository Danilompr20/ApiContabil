using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositorio.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PapelUsuario");

            migrationBuilder.CreateTable(
                name: "UsuariosPapeis",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdPapel = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    PapelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosPapeis", x => new { x.IdUsuario, x.IdPapel });
                    table.ForeignKey(
                        name: "FK_UsuariosPapeis_Papeis_PapelId",
                        column: x => x.PapelId,
                        principalTable: "Papeis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuariosPapeis_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosPapeis_PapelId",
                table: "UsuariosPapeis",
                column: "PapelId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosPapeis_UsuarioId",
                table: "UsuariosPapeis",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuariosPapeis");

            migrationBuilder.CreateTable(
                name: "PapelUsuario",
                columns: table => new
                {
                    PapeisId = table.Column<int>(type: "int", nullable: false),
                    UsuariosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PapelUsuario", x => new { x.PapeisId, x.UsuariosId });
                    table.ForeignKey(
                        name: "FK_PapelUsuario_Papeis_PapeisId",
                        column: x => x.PapeisId,
                        principalTable: "Papeis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PapelUsuario_Usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PapelUsuario_UsuariosId",
                table: "PapelUsuario",
                column: "UsuariosId");
        }
    }
}
