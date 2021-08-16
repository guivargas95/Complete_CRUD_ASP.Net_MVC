using Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Interfaces.Services
{
    public interface IProfessorService
    {
        Task<IEnumerable<ProfessorModel>> GetAllAsync(
            bool orderAscendant,
            string search = null);

        Task<ProfessorModel> GetByIdAsync(int id);
        Task<ProfessorModel> CreateAsync(ProfessorModel professorModel);
        Task<ProfessorModel> EditAsync(ProfessorModel professorModel);
        Task DeleteAsync(int id);
    }
}
