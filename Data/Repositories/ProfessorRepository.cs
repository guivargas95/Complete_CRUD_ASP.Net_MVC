using Data.Data;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly PresentationContext _presentationContext;

        public ProfessorRepository(
            PresentationContext presentationContext)
        {
            _presentationContext = presentationContext;
        }

        public async Task<ProfessorModel> CreateAsync(ProfessorModel professorModel)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProfessorModel> EditAsync(ProfessorModel professorModel)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProfessorModel>> GetAllAsync(bool orderAscendant, string search = null)
        {
            var professores = orderAscendant
                ? _presentationContext.Professores.OrderBy(x => x.Nome)
                : _presentationContext.Professores.OrderByDescending(x => x.Nome);
            
            
            if (string.IsNullOrWhiteSpace(search))
            {
                return await professores.ToListAsync();
            }
            return await professores
                .Where(x => x.Nome.Contains(search) || x.UltimoNome.Contains(search))
                .ToListAsync();
        }

        public async Task<ProfessorModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
