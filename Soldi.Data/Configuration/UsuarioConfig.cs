using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soldi.Core.Entities;

namespace Soldi.Data.Configuration
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(60);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(60);
            builder.Property(p => p.Senha).IsRequired().HasMaxLength(30);


            builder.HasMany(c=>c.Cartoes).WithOne(u=>u.Usuario).HasForeignKey(u => u.UsuarioId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(c=>c.Faturas).WithOne(u=>u.Usuario).HasForeignKey(u => u.UsuarioId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(c=>c.LancamentoRecorrentes).WithOne(u=>u.Usuario).HasForeignKey(u => u.UsuarioId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(c=>c.Lancamentos).WithOne(u=>u.Usuario).HasForeignKey(u => u.UsuarioId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(c=>c.Contas).WithOne(u=>u.Usuario).HasForeignKey(u => u.UsuarioId).OnDelete(DeleteBehavior.Restrict);

        }


    }
}
