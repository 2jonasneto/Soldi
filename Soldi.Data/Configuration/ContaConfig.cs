using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soldi.Core.Entities;

namespace Soldi.Data.Configuration
{
    public class ContaConfig : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(60);
            builder.Property(p => p.Imagem).IsRequired().HasMaxLength(1000);
            builder.Property(p=>p.Saldo).HasColumnType<decimal>("decimal(15,2)");

        }


    }






}
