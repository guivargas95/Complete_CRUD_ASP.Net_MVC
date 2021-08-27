using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Presentation.Models;

namespace Presentation.Services.Implementations
{
    public class AlunoFakeService : IAlunoHttpService
    {
        private static List<AlunoViewModel> Alunos { get; } = new List<AlunoViewModel>
        {
            new AlunoViewModel
            {
                Id = 0,
                Nome = "Nathan",
                UltimoNome = "Seilça",
                Curso = "Atrologia",
                Matricula = "2223315",
                DataMatricula = new DateTime(2015, 02, 05)

            },
            new AlunoViewModel
            {
                Id = 1,
                Nome = "Nathan12",
                UltimoNome = "Seilç12a",
                Curso = "Atrologia12",
                Matricula = "2223315",
                DataMatricula = new DateTime(2016, 02, 05)
            }
        };

        public async Task<IEnumerable<AlunoViewModel>> GetAllAsync(bool orderAscendant, string search = null)
        {
            if (search == null)
            {
                return Alunos;
            }

            var resultByLinq = Alunos
                .Where(x => x.Nome.Contains(search, StringComparison.OrdinalIgnoreCase));

            resultByLinq = orderAscendant
                ? resultByLinq.OrderBy(x => x.Nome)
                : resultByLinq.OrderByDescending(x => x.Nome);

            return resultByLinq;
        }

        public async Task<AlunoViewModel> GetByIdAsync(int id)
        {
            foreach (var aluno in Alunos)
            {
                if (aluno.Id == id)
                {
                    return aluno;
                }
            }

            return null;
        }

        private static int _id = Alunos.Max(x => x.Id);
        private int Id => Interlocked.Increment(ref _id);
        public async Task<AlunoViewModel> CreateAsync(AlunoViewModel AlunoViewModel)
        {
            AlunoViewModel.Id = Id;

            Alunos.Add(AlunoViewModel);

            //TODO: auto-increment Id e atualizar para o retorno
            return AlunoViewModel;
        }

        public async Task<AlunoViewModel> EditAsync(AlunoViewModel AlunoViewModel)
        {
            foreach (var aluno in Alunos)
            {
                if (aluno.Id == AlunoViewModel.Id)
                {
                    aluno.Matricula = AlunoViewModel.Matricula;
                    aluno.Curso = AlunoViewModel.Curso;
                    aluno.Nome = AlunoViewModel.Nome;
                    aluno.UltimoNome = AlunoViewModel.UltimoNome;
                    aluno.DataMatricula = AlunoViewModel.DataMatricula;
                    aluno.ProfessorId = AlunoViewModel.ProfessorId;
                    

                    return aluno;
                }
            }

            return null;
        }

        public async Task DeleteAsync(int id)
        {
            AlunoViewModel alunoEncontrado = null;
            foreach (var aluno in Alunos)
            {
                if (aluno.Id == id)
                {
                    alunoEncontrado = aluno;
                }
            }

            if (alunoEncontrado != null)
            {
                Alunos.Remove(alunoEncontrado);
            }
        }

        public async Task<bool> ValidarMatriculaAsync(string isbn, int id)
        {
            throw new NotImplementedException();
        }
    }
}