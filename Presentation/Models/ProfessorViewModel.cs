using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    public class ProfessorViewModel
    {

        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Nome { get; set; }

        [Required]
        [StringLength(25)]
        public string UltimoNome { get; set; }

        [Required]
        public DateTime Contratacao { get; set; }

        [Required]
        public int QntdDisciplinas { get; set; }

        [Required]
        public List<AlunoViewModel> Alunos { get; set; }

        
    }
}
