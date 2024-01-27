using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Aluno
    {
        public int RM { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int ClasseId { get; set; }
        public virtual Classe? Classe { get; set; }
        public int EscolaId { get; set; }
        public virtual Escola? Escola { get; set; }
    }
}
