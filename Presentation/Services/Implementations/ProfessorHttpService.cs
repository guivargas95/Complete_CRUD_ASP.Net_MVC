using Presentation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Services.Implementations
{
    public class ProfessorHttpService : IProfessorHttpService
    {
        public Task<ProfessorViewModel> CreateAsync(ProfessorViewModel professorViewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProfessorViewModel> EditAsync(ProfessorViewModel professorViewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ProfessorViewModel>> GetAllAsync(bool orderAscendant, string search = null)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProfessorViewModel> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
