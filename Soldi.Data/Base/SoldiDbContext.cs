global using Microsoft.EntityFrameworkCore;
global using Soldi.Core.Entities;
global using Soldi.Data.Base;

namespace Soldi.Data.Base
{
    public class SoldiDbContext : DbContext
    {

        public SoldiDbContext(DbContextOptions<SoldiDbContext> options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SoldiDbContext).Assembly);
           
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Fatura> Faturas { get; set; }
        public DbSet<Lancamento> Lancamentos { get; set; }
        public DbSet<LancamentoRecorrente> LancamentoRecorrentes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
