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
    public class AlunoRepository : IAlunoRepository
    {

        private readonly PresentationContext _presentationContext;

        public AlunoRepository(
            PresentationContext presentationContext)
        {
            _presentationContext = presentationContext;
        }

        public async Task<AlunoModel> CompararNumeroDeMatriculaAsync(string matricula, int id)
        {
            var alunoModel = await _presentationContext.Alunos.FirstOrDefaultAsync(x => x.Matricula == matricula && x.Id != id);

            return alunoModel;
        }

        public async Task<AlunoModel> CreateAsync(AlunoModel alunoModel)
        {
            var aluno = _presentationContext.Alunos.Add(alunoModel);

            await _presentationContext.SaveChangesAsync();

            return aluno.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var aluno = await GetByIdAsync(id);

            _presentationContext.Alunos.Remove(aluno);

            await _presentationContext.SaveChangesAsync();





        }

        public async Task<AlunoModel> EditAsync(AlunoModel alunoModel)
        {
            var aluno = _presentationContext.Alunos.Update(alunoModel);

            await _presentationContext.SaveChangesAsync();

            return aluno.Entity;
        }

        public async Task<IEnumerable<AlunoModel>> GetAllAsync(bool orderAscendant, string search = null)
        {
            var alunos = orderAscendant
                ? _presentationContext.Alunos.OrderBy(x => x.Nome)
                : _presentationContext.Alunos.OrderByDescending(x => x.Nome);


            if (string.IsNullOrWhiteSpace(search))
            {
                return await alunos.ToListAsync();
            }
            return await alunos
                .Where(x => x.Nome.Contains(search) || x.UltimoNome.Contains(search))
                .ToListAsync();
        }

        public async Task<AlunoModel> GetByIdAsync(int id)
        {
            var aluno = await _presentationContext
                .Alunos
                .Include(x => x.Professor)
                .FirstOrDefaultAsync(x => x.Id == id);

            return aluno;
        }
    }
}

