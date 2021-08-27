using Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Models
{
    public class AlunoIndexViewModel
    {
        public string Search { get; set; }

        public bool OrderAscendant { get; set; }

        public IEnumerable<AlunoModel> Alunos { get; set; }
    }
}
