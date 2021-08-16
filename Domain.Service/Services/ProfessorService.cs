using Domain.Model.Interfaces.Repositories;
using Domain.Model.Interfaces.Services;
using Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Services
{
    public class ProfessorService : IProfessorService
    {

        private readonly IProfessorRepository _professorRepository;

        public ProfessorService(
            IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }




        public async Task<ProfessorModel> CreateAsync(ProfessorModel professorModel)
        {
            return await _professorRepository.CreateAsync(professorModel);
        }

        public async Task DeleteAsync(int id)
        {
            await _professorRepository.DeleteAsync(id);
        }

        public async Task<ProfessorModel> EditAsync(ProfessorModel professorModel)
        {
            return await _professorRepository.EditAsync(professorModel);
        }

        public async Task<IEnumerable<ProfessorModel>> GetAllAsync(bool orderAscendant, string search = null)
        {
            return await _professorRepository.GetAllAsync(orderAscendant, search);
        }

        public async Task<ProfessorModel> GetByIdAsync(int id)
        {
            return await _professorRepository.GetByIdAsync(id);
        }
    }
}
