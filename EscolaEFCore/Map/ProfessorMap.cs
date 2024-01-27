using Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EscolaEFCore.Map
{
    public class ProfessorMap : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable("TB_Professor");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");

            builder.Property(x => x.Nome).HasColumnName("Nome");

            builder.Property(x => x.Email).HasColumnName("Email");

            builder.Property(x => x.Senha).HasColumnName("Senha");

            builder.HasOne(x => x.Escola).WithMany(x => x.ProfessoresLista).HasForeignKey(x => x.EscolaId);
            builder.Property(x => x.EscolaId).HasColumnName("Escola");
        }
    }
}
