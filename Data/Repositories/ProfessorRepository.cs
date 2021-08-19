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
           var professor = _presentationContext.Professores.Add(professorModel);

            await _presentationContext.SaveChangesAsync();

            return professor.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var professor = await GetByIdAsync(id);

            _presentationContext.Professores.Remove(professor);

            await _presentationContext.SaveChangesAsync();


               


        }

        public async Task<ProfessorModel> EditAsync(ProfessorModel professorModel)
        {
            var professor = _presentationContext.Professores.Update(professorModel);

            await _presentationContext.SaveChangesAsync();

            return professor.Entity;
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
            var professor = await _presentationContext
                .Professores
                .Include(x => x.Alunos)
                .FirstOrDefaultAsync(x => x.Id == id);

            return professor;
        }
    }
}
