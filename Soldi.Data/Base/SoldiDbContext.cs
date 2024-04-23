﻿global using Microsoft.EntityFrameworkCore;
global using Soldi.Core.Entities;
global using Soldi.Data.Base;

namespace Soldi.Data.Base
{
    public class SoldiDbContext : DbContext
    {

        public SoldiDbContext(DbContextOptions<SoldiDbContext> options):base(options) { }
      

        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Fatura> Faturas { get; set; }
        public DbSet<Lancamento> Lancamentos { get; set; }
        public DbSet<LancamentoRecorrente> LancamentoRecorrentes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
