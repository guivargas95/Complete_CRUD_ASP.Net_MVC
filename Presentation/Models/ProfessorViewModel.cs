using Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Models
{
    public class ProfessorViewModel
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public string UltimoNome { get; set; }

        public DateTime Contratacao { get; set; }

        public int QntdDisciplinas { get; set; }

        public List<AlunoViewModel> Alunos { get; set; }

        public static ProfessorViewModel From(ProfessorModel professorModel)
        {
            var professorViewModel = new ProfessorViewModel
            {
                Id = professorModel.Id,
                Nome = professorModel.Nome,
                UltimoNome = professorModel.UltimoNome,
                Contratacao = professorModel.Contratacao,
                QntdDisciplinas = professorModel.QntdDisciplinas,
                
                Alunos = professorModel?.Alunos.Select(x => AlunoViewModel.From(x, false)).ToList(),


            };

            return professorViewModel;
        }

        public ProfessorModel ToModel()
        {
            var professorModel = new ProfessorModel
            {
                Id = Id,
                Nome = Nome,
                UltimoNome = UltimoNome,
                Contratacao = Contratacao,
                QntdDisciplinas = QntdDisciplinas,
                Alunos = Alunos?.Select(x => x.ToModel(false)).ToList(),
            };





            return professorModel;
        }
    }
}
