using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Aula
    {
        public int Id { get; set; }
        public int ProfessorId { get; set; }    
        public virtual Professor? Professor { get; set; }
        public string Nome { get; set; }
        public TimeSpan HorarioInicio { get; set; }
        public TimeSpan HorarioTermino { get; set; }
        public int ClasseId { get; set; }
        public virtual Classe? Classe { get; set; }
    }
}
