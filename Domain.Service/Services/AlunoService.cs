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
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(
            IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }




        public async Task<AlunoModel> CreateAsync(AlunoModel alunoModel)
        {
            return await _alunoRepository.CreateAsync(alunoModel);
        }

        public async Task DeleteAsync(int id)
        {
            await _alunoRepository.DeleteAsync(id);
        }

        public async Task<AlunoModel> EditAsync(AlunoModel alunoModel)
        {
            return await _alunoRepository.EditAsync(alunoModel);
        }

        public async Task<IEnumerable<AlunoModel>> GetAllAsync(bool orderAscendant, string search = null)
        {
            return await _alunoRepository.GetAllAsync(orderAscendant, search);
        }

        public async Task<AlunoModel> GetByIdAsync(int id)
        {
            return await _alunoRepository.GetByIdAsync(id);
        }

        public async Task<bool> ValidarMatriculaAsync(string matricula, int id)
        {
            var alunoModel = await _alunoRepository.CompararNumeroDeMatriculaAsync(matricula, id);

            return alunoModel == null;
        }
    }
}

