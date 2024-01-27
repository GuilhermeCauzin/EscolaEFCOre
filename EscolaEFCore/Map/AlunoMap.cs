using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaEFCore.Map
{
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("TB_Aluno");

            builder.HasKey(x => x.RM);
            builder.Property(x => x.RM).HasColumnName("RM");

            builder.Property(x => x.Nome).HasColumnName("Nome");

            builder.Property(x => x.Email).HasColumnName("Email");

            builder.Property(x => x.Senha).HasColumnName("Senha");

            builder.HasOne(x => x.Classe).WithMany(x => x.AlunosLista).HasForeignKey(x => x.ClasseId);
            builder.Property(x => x.ClasseId).HasColumnName("Classe");

            builder.HasOne(x => x.Escola).WithMany(x => x.AlunosLista).HasForeignKey(x => x.EscolaId);
            builder.Property(x => x.EscolaId).HasColumnName("Escola");
        }
    }
}