using Entidades;
using EscolaEFCore.Map;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;



namespace EscolaEFCore.Context
{
    public class EscolaContext : DbContext 
    {
        public EscolaContext(DbContextOptions<EscolaContext> options) : base(options)
        {

        }
        
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Classe> Classes { get; set; }
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Escola> Escolas { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new AlunoMap().Configure(modelBuilder.Entity<Aluno>());
            new ClasseMap().Configure(modelBuilder.Entity<Classe>());
            new AulaMap().Configure(modelBuilder.Entity<Aula>());
            new EscolaMap().Configure(modelBuilder.Entity<Escola>());
            new ProfessorMap().Configure(modelBuilder.Entity<Professor>());
        }

    }
}
