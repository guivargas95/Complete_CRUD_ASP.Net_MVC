using Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Models
{
    public class ProfessorIndexViewModel
    {
        public string Search { get; set; }
        
        public bool OrderAscendant { get; set; }

        public IEnumerable<ProfessorModel> Professores { get; set; }


    }
}
