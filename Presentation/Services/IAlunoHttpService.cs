using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Services
{
    public interface IAlunoHttpService
    {

        Task<IEnumerable<AlunoViewModel>> GetAllAsync(
            bool orderAscendant,
            string search = null);

        Task<AlunoViewModel> GetByIdAsync(int id);
        Task<AlunoViewModel> CreateAsync(AlunoViewModel alunoViewModel);
        Task<AlunoViewModel> EditAsync(AlunoViewModel alunoViewModel);
        Task DeleteAsync(int id);
        Task<bool> ValidarMatriculaAsync(string matricula, int id);
    }
}
