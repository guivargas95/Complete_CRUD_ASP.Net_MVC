﻿using Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Interfaces.Repositories
{
    public interface IAlunoRepository
    {
        

        Task<IEnumerable<AlunoModel>> GetAllAsync(
            bool orderAscendant,
            string search = null);

        Task<AlunoModel> GetByIdAsync(int id);
        Task<AlunoModel> CreateAsync(AlunoModel alunoModel);
        Task<AlunoModel> EditAsync(AlunoModel alunoModel);
        Task DeleteAsync(int id);
        Task <AlunoModel> CompararNumeroDeMatriculaAsync(string matricula, int id);
    }
}

