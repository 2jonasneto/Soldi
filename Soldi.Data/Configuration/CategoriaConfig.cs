using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soldi.Core.Entities;

namespace Soldi.Data.Configuration
{
    public class CategoriaConfig : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(60);
            builder.Property(p => p.Imagem).IsRequired().HasMaxLength(300);
            builder.Property(p => p.Cor).IsRequired().HasMaxLength(20);


        }
    }
}
