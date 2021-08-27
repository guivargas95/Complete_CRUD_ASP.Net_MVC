using Domain.Model.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Models
{
    public class AlunoViewModel
    {

        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Ultimo Nome")]
        [StringLength(maximumLength:25, MinimumLength =3)]
        public string UltimoNome { get; set; }

        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 6)]
        public string Curso { get; set; }

        [Required]
        public DateTime DataMatricula { get; set; }

        [Required]
        [StringLength(10)]
        [Remote(action: "ValidarMatricula", controller: "Aluno", AdditionalFields = "Id")]
        public string Matricula { get; set; }

        [Required]
        public int ProfessorId { get; set; }

        [Required]
        public ProfessorViewModel Professor { get; set; }

        public static AlunoViewModel From(AlunoModel alunoModel, bool firstMap = true)
        {
            if (!firstMap)
            {
                return null;
            }
            
            var professor = firstMap
                ? ProfessorViewModel.From(alunoModel.Professor)
                : null;


            var alunoViewModel = new AlunoViewModel
            {

                Id = alunoModel.Id,
                Nome = alunoModel.Nome,
                UltimoNome = alunoModel.UltimoNome,
                Curso = alunoModel.Curso,
                DataMatricula = alunoModel.DataMatricula,
                Matricula = alunoModel.Matricula,
                ProfessorId = alunoModel.ProfessorId,
                Professor = professor,


            };

            return alunoViewModel;
            
        }

        public AlunoModel ToModel(bool firstMap = true)
        {
            var professor = firstMap //para interromper recursão
                ? Professor?.ToModel()
                : null;


            var alunoModel = new AlunoModel
            {

                Id = Id,
                Nome = Nome,
                UltimoNome = UltimoNome,
                Curso = Curso,
                DataMatricula = DataMatricula,
                Matricula = Matricula,
                ProfessorId = ProfessorId,
                Professor = Professor?.ToModel()


            };

            return alunoModel;
        }
    }
}
