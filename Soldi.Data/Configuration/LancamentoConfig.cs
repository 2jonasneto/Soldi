using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soldi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soldi.Data.Configuration
{
    public class LancamentoConfig : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Descricao).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Parcela).IsRequired().HasMaxLength(60);
            builder.Property(p => p.Observacoes).IsRequired().HasMaxLength(300);
            builder.Property(p => p.Valor).HasColumnType<decimal>("decimal(15,2)");


        }


    }
    public class LancamentoRecorrenteConfig : IEntityTypeConfiguration<LancamentoRecorrente>
    {
        public void Configure(EntityTypeBuilder<LancamentoRecorrente> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Descricao).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Observacoes).IsRequired().HasMaxLength(300);
            builder.Property(p => p.Valor).HasColumnType<decimal>("decimal(15,2)");


        }


    }
}
