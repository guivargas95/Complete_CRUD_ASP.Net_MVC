using Presentation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Services
{
    public interface IProfessorHttpService
    {
        Task<IEnumerable<ProfessorViewModel>> GetAllAsync(
           bool orderAscendant,
           string search = null);

        Task<ProfessorViewModel> GetByIdAsync(int id);
        Task<ProfessorViewModel> CreateAsync(ProfessorViewModel professorModel);
        Task<ProfessorViewModel> EditAsync(ProfessorViewModel professorModel);
        Task DeleteAsync(int id);
    }
}
