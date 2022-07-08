using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositorio.Migrations
{
    public partial class l : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpresaEstabelecimentos_Usuarios_UsuarioId",
                table: "EmpresaEstabelecimentos");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "EmpresaEstabelecimentos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CnaePreponderanteId",
                table: "EmpresaEstabelecimentos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpresaEstabelecimentos_Usuarios_UsuarioId",
                table: "EmpresaEstabelecimentos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpresaEstabelecimentos_Usuarios_UsuarioId",
                table: "EmpresaEstabelecimentos");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "EmpresaEstabelecimentos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CnaePreponderanteId",
                table: "EmpresaEstabelecimentos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpresaEstabelecimentos_Usuarios_UsuarioId",
                table: "EmpresaEstabelecimentos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
