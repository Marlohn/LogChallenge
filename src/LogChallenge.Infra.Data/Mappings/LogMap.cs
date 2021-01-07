using LogChallenge.Domain.Entities;
using LogChallenge.Infra.Data.Mappings.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogChallenge.Infra.Data.Mappings
{
    public class LogMap : BaseMap<Log>
    {
        public override void Configure(EntityTypeBuilder<Log> builder)
        {
            base.Configure(builder);
            //builder.ToTable("CalculadoraOperacao");
            //builder.Property(c => c.opcao).IsRequired().HasColumnName("Opcao").HasMaxLength(100);
            //builder.Property(c => c.valores).IsRequired().HasColumnName("ValoresEntrada").HasMaxLength(100);
            //builder.Property(c => c.resposta).IsRequired().HasColumnName("RespostaSaida").HasMaxLength(100);
        }
    }
}
