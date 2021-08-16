using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Models
{
    public class AlunoModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string UltimoNome { get; set; }

        public string Curso { get; set; }

        public DateTime DataMatricula { get; set; }

        public string Matricula { get; set; }

        public int ProfessorId { get; set; }

        public ProfessorModel Professor { get; set; }

    }
}
