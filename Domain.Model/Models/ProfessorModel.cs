using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Models
{
    public class ProfessorModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string UltimoNome { get; set; }

        public DateTime Contratacao { get; set; }

        public int QntdDisciplinas { get; set; }

        public List<AlunoModel> Alunos { get; set; }


    }
}
