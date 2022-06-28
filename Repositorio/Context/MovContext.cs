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
        public DbSet<Papel> Papeis { get; set; }
        public DbSet<UsuarioPapel> UsuariosPapeis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioPapel>().HasKey(x => new { x.IdUsuario, x.IdPapel });

            modelBuilder.Entity<UsuarioPapel>().HasOne(x => x.Usuario).WithMany(x => x.UsuariosPapeis).HasForeignKey(x => x.IdUsuario);
            modelBuilder.Entity<UsuarioPapel>().HasOne(x => x.Papel).WithMany(x => x.UsuariosPapeis).HasForeignKey(x => x.IdPapel);
            modelBuilder.Entity<Usuario>().HasIndex(x => x.Email).IsUnique();
        }    
    }
}
