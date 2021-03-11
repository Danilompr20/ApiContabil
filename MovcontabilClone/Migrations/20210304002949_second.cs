using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovcontabilClone.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bancos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bancos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClienteFornecedorContatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefoneComercial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteFornecedorContatos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClienteFornecedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoPessoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cliente = table.Column<bool>(type: "bit", nullable: true),
                    Fornecedor = table.Column<bool>(type: "bit", nullable: true),
                    Transportadora = table.Column<bool>(type: "bit", nullable: true),
                    NomeFantasia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    CpfCnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimplesNacional = table.Column<bool>(type: "bit", nullable: true),
                    RgInscricaoEstadual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RgInscricaoMunicipal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Regiao = table.Column<short>(type: "smallint", nullable: true),
                    Segmento = table.Column<byte>(type: "tinyint", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroLogradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplementoLogradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PisRetido = table.Column<bool>(type: "bit", nullable: true),
                    CofinsRetido = table.Column<bool>(type: "bit", nullable: true),
                    CsllRetido = table.Column<bool>(type: "bit", nullable: true),
                    InssRetido = table.Column<bool>(type: "bit", nullable: true),
                    IssRetido = table.Column<bool>(type: "bit", nullable: true),
                    IrRetido = table.Column<bool>(type: "bit", nullable: true),
                    Cnae = table.Column<int>(type: "int", nullable: true),
                    ContribuinteIcms = table.Column<bool>(type: "bit", nullable: false),
                    Classificacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Banco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Agencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContaCorrente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailNfe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoPix = table.Column<short>(type: "smallint", nullable: true),
                    ChavePix = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteFornecedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cnaes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cnaes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodigoDescricaos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodigoDescricaos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoServicos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    CodigoInterno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoFabricante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoItem = table.Column<byte>(type: "tinyint", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    DescricaoReduzido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescricaoCompleta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnidadeMedida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gtin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ncm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PisRetido = table.Column<bool>(type: "bit", nullable: true),
                    CofinsRetido = table.Column<bool>(type: "bit", nullable: true),
                    CsllRetido = table.Column<bool>(type: "bit", nullable: true),
                    InssRetido = table.Column<bool>(type: "bit", nullable: true),
                    InssAutonomoRetido = table.Column<bool>(type: "bit", nullable: true),
                    IssRetido = table.Column<bool>(type: "bit", nullable: true),
                    IrRetido = table.Column<bool>(type: "bit", nullable: true),
                    AliquotaIpiEntrada = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AliquotaIcmsEntrada = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AliquotaIpiSaida = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AliquotaIcmsSaida = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AliquotaReducaoIpi = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AliquotaReducaoIcms = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AliquotaInssEntrada = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AliquotaInssSaida = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AliquotaIr = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AliquotaPis = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AliquotaCofins = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoServicos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ReceitaDespesas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    ContaContabil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceitaDespesas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContaCorrentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BancoId = table.Column<int>(type: "int", nullable: false),
                    Agencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Conta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContaContabil = table.Column<int>(type: "int", nullable: false),
                    Aplicacao = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaCorrentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContaCorrentes_Bancos_BancoId",
                        column: x => x.BancoId,
                        principalTable: "Bancos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaEstabelecimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InscricaoEstadual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroComplemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeFantasia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataAbertura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fap = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CnaePreponderanteId = table.Column<int>(type: "int", nullable: false),
                    CnaeId = table.Column<int>(type: "int", nullable: true),
                    CnaeEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NaturezaJuridica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoTerceiros = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PercentualTerceiros = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PercentualEmpresa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rat = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaEstabelecimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpresaEstabelecimentos_Cnaes_CnaeId",
                        column: x => x.CnaeId,
                        principalTable: "Cnaes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmpresaEstabelecimentos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContaCorrentes_BancoId",
                table: "ContaCorrentes",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaEstabelecimentos_CnaeId",
                table: "EmpresaEstabelecimentos",
                column: "CnaeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaEstabelecimentos_UsuarioId",
                table: "EmpresaEstabelecimentos",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteFornecedorContatos");

            migrationBuilder.DropTable(
                name: "ClienteFornecedores");

            migrationBuilder.DropTable(
                name: "CodigoDescricaos");

            migrationBuilder.DropTable(
                name: "ContaCorrentes");

            migrationBuilder.DropTable(
                name: "EmpresaEstabelecimentos");

            migrationBuilder.DropTable(
                name: "ProdutoServicos");

            migrationBuilder.DropTable(
                name: "ReceitaDespesas");

            migrationBuilder.DropTable(
                name: "Bancos");

            migrationBuilder.DropTable(
                name: "Cnaes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
