using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Professor
    {
        public Professor() 
        {
            ListaAulas = new List<Aula>();
        }  
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int EscolaId { get; set; }
        public virtual Escola? Escola { get; set; }
        public virtual ICollection<Aula> ListaAulas { get; set; }
    }
}
