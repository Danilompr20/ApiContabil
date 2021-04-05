using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace MovcontabilClone.Context
{
    public class MovContext :DbContext
    {

        public MovContext(DbContextOptions<MovContext> options) : base(options)
        {

        }

        public DbSet<ClienteFornecedor> ClienteFornecedores { get; set; }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<ClienteFornecedorContato> ClienteFornecedorContatos { get; set; }
        public DbSet<Cnae> Cnaes { get; set; }
        public DbSet<CodigoDescricao> CodigoDescricaos { get; set; }
        public DbSet<ContaCorrente> ContaCorrentes{ get; set; }
        public DbSet<EmpresaEstabelecimento> EmpresaEstabelecimentos{ get; set; }
        public DbSet<ProdutoServico> ProdutoServicos{ get; set; }
        public DbSet<ReceitaDespesa> ReceitaDespesas{ get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
