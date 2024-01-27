using Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EscolaEFCore.Map
{
    public class AulaMap : IEntityTypeConfiguration<Aula>
    {
        public void Configure(EntityTypeBuilder<Aula> builder)
        {
            builder.ToTable("TB_Aula");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");

            builder.Property(x => x.Nome).HasColumnName("Nome");

            builder.HasOne(x => x.Professor).WithMany(x => x.ListaAulas).HasForeignKey(x => x.ProfessorId);
            builder.Property(x => x.ProfessorId).HasColumnName("ProfessorId");

            builder.Property(x => x.HorarioInicio).HasColumnName("HorarioInicio");

            builder.Property(x => x.HorarioTermino).HasColumnName("HorarioTermino");

            builder.HasOne(x => x.Classe).WithMany(x => x.AulaLista).HasForeignKey(x => x.ClasseId);
            builder.Property(x => x.ClasseId).HasColumnName("Classe");
        }
    }
}
