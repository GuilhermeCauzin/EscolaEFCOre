using Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EscolaEFCore.Map
{
    public class EscolaMap : IEntityTypeConfiguration<Escola>
    {
        public void Configure(EntityTypeBuilder<Escola> builder)
        {
            builder.ToTable("TB_Escola");
            builder.HasKey(x => x.UnidadeId);
            builder.Property(x => x.UnidadeId).HasColumnName("Id");

            builder.Property(x => x.Nome).HasColumnName("Nome");

            builder.Property(x => x.Cidade).HasColumnName("Cidade");
        }
    }
}
