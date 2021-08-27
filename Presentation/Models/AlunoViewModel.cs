using System;
using System.ComponentModel.DataAnnotations;
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

        
    }
}
