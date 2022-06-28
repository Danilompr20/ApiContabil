﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovcontabilClone.Context;

namespace Repositorio.Migrations
{
    [DbContext(typeof(MovContext))]
    partial class MovContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entity.Banco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bancos");
                });

            modelBuilder.Entity("Domain.Entity.ClienteFornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Agencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Banco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChavePix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Classificacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Cliente")
                        .HasColumnType("bit");

                    b.Property<int?>("Cnae")
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("CofinsRetido")
                        .HasColumnType("bit");

                    b.Property<string>("ComplementoLogradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContaCorrente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ContribuinteIcms")
                        .HasColumnType("bit");

                    b.Property<string>("CpfCnpj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("CsllRetido")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailNfe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Fornecedor")
                        .HasColumnType("bit");

                    b.Property<bool?>("InssRetido")
                        .HasColumnType("bit");

                    b.Property<bool?>("IrRetido")
                        .HasColumnType("bit");

                    b.Property<bool?>("IssRetido")
                        .HasColumnType("bit");

                    b.Property<string>("Logradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeFantasia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroLogradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("PisRetido")
                        .HasColumnType("bit");

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short?>("Regiao")
                        .HasColumnType("smallint");

                    b.Property<string>("RgInscricaoEstadual")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RgInscricaoMunicipal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Segmento")
                        .HasColumnType("tinyint");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("SimplesNacional")
                        .HasColumnType("bit");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoPessoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short?>("TipoPix")
                        .HasColumnType("smallint");

                    b.Property<bool?>("Transportadora")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("ClienteFornecedores");
                });

            modelBuilder.Entity("Domain.Entity.ClienteFornecedorContato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Departamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefoneComercial")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClienteFornecedorContatos");
                });

            modelBuilder.Entity("Domain.Entity.Cnae", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cnaes");
                });

            modelBuilder.Entity("Domain.Entity.CodigoDescricao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CodigoDescricaos");
                });

            modelBuilder.Entity("Domain.Entity.ContaCorrente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Agencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Aplicacao")
                        .HasColumnType("bit");

                    b.Property<int>("BancoId")
                        .HasColumnType("int");

                    b.Property<string>("Conta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContaContabil")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BancoId");

                    b.ToTable("ContaCorrentes");
                });

            modelBuilder.Entity("Domain.Entity.EmpresaEstabelecimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CnaeEmpresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CnaeId")
                        .HasColumnType("int");

                    b.Property<int>("CnaePreponderanteId")
                        .HasColumnType("int");

                    b.Property<string>("Cnpj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoTerceiros")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataAbertura")
                        .HasColumnType("datetime2");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Fap")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("InscricaoEstadual")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NaturezaJuridica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeFantasia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroComplemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PercentualEmpresa")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PercentualTerceiros")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Rat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CnaeId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("EmpresaEstabelecimentos");
                });

            modelBuilder.Entity("Domain.Entity.Papel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Papeis");
                });

            modelBuilder.Entity("Domain.Entity.ProdutoServico", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("AliquotaCofins")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("AliquotaIcmsEntrada")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("AliquotaIcmsSaida")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("AliquotaInssEntrada")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("AliquotaInssSaida")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("AliquotaIpiEntrada")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("AliquotaIpiSaida")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("AliquotaIr")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("AliquotaPis")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("AliquotaReducaoIcms")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("AliquotaReducaoIpi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool?>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<string>("CodigoFabricante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoInterno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("CofinsRetido")
                        .HasColumnType("bit");

                    b.Property<bool?>("CsllRetido")
                        .HasColumnType("bit");

                    b.Property<string>("DescricaoCompleta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescricaoReduzido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gtin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("InssAutonomoRetido")
                        .HasColumnType("bit");

                    b.Property<bool?>("InssRetido")
                        .HasColumnType("bit");

                    b.Property<bool?>("IrRetido")
                        .HasColumnType("bit");

                    b.Property<bool?>("IssRetido")
                        .HasColumnType("bit");

                    b.Property<string>("Ncm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("PisRetido")
                        .HasColumnType("bit");

                    b.Property<byte?>("TipoItem")
                        .HasColumnType("tinyint");

                    b.Property<string>("UnidadeMedida")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("ProdutoServicos");
                });

            modelBuilder.Entity("Domain.Entity.ReceitaDespesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("ContaContabil")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ReceitaDespesas");
                });

            modelBuilder.Entity("Domain.Entity.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Domain.Entity.UsuarioPapel", b =>
                {
                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int>("IdPapel")
                        .HasColumnType("int");

                    b.HasKey("IdUsuario", "IdPapel");

                    b.HasIndex("IdPapel");

                    b.ToTable("UsuariosPapeis");
                });

            modelBuilder.Entity("PapelUsuario", b =>
                {
                    b.Property<int>("PapelId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("PapelId", "UsuarioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("PapelUsuario");
                });

            modelBuilder.Entity("Domain.Entity.ContaCorrente", b =>
                {
                    b.HasOne("Domain.Entity.Banco", "Banco")
                        .WithMany()
                        .HasForeignKey("BancoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Banco");
                });

            modelBuilder.Entity("Domain.Entity.EmpresaEstabelecimento", b =>
                {
                    b.HasOne("Domain.Entity.Cnae", "Cnae")
                        .WithMany()
                        .HasForeignKey("CnaeId");

                    b.HasOne("Domain.Entity.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cnae");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Entity.UsuarioPapel", b =>
                {
                    b.HasOne("Domain.Entity.Papel", "Papel")
                        .WithMany("UsuariosPapeis")
                        .HasForeignKey("IdPapel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.Usuario", "Usuario")
                        .WithMany("UsuariosPapeis")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Papel");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PapelUsuario", b =>
                {
                    b.HasOne("Domain.Entity.Papel", null)
                        .WithMany()
                        .HasForeignKey("PapelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.Papel", b =>
                {
                    b.Navigation("UsuariosPapeis");
                });

            modelBuilder.Entity("Domain.Entity.Usuario", b =>
                {
                    b.Navigation("UsuariosPapeis");
                });
#pragma warning restore 612, 618
        }
    }
}
