using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Services.Implementations
{
    public class AlunoHttpService : IAlunoHttpService
    {
        public Task<AlunoViewModel> CreateAsync(AlunoViewModel alunoViewModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AlunoViewModel> EditAsync(AlunoViewModel alunoViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AlunoViewModel>> GetAllAsync(bool orderAscendant, string search = null)
        {
            throw new NotImplementedException();
        }

        public Task<AlunoViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidarMatriculaAsync(string matricula, int id)
        {
            throw new NotImplementedException();
        }
    }
}
