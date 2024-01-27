using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Escola
    {
        public Escola()
        {
            AlunosLista = new List<Aluno>();
            ProfessoresLista = new List<Professor>();
        }

        public int UnidadeId { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public virtual ICollection<Aluno> AlunosLista { get; set; }
        public virtual ICollection<Professor> ProfessoresLista { get; set; }
    }
}
