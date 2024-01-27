using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Classe
    {
        public Classe() 
        {
            AlunosLista = new List<Aluno>();
            AulaLista = new List<Aula>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Aluno> AlunosLista { get; set; }
        public virtual ICollection<Aula> AulaLista { get; set;}
    }
}
