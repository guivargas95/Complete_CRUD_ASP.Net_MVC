using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Presentation.Models;

namespace Presentation.Services.Implementations
{
    public class ProfessorFakeService : IProfessorHttpService
    {
        private static List<ProfessorViewModel> Professores { get; } = new List<ProfessorViewModel>
        {
            new ProfessorViewModel
            {
                Id = 0,
                Nome = "Felipe",
                UltimoNome = "Andrade",
                Contratacao = new DateTime(1988, 02, 23),
                QntdDisciplinas = 5,
                
                
            },
            new ProfessorViewModel
            {
                Id = 1,
                Nome = "Felipe2",
                UltimoNome = "Andrade2",
                Contratacao = new DateTime(1988, 02, 23),
                QntdDisciplinas = 6,


            },
        };

        public async Task<IEnumerable<ProfessorViewModel>> GetAllAsync(bool orderAscendant, string search = null)
        {
            if (search == null)
            {
                return Professores;
            }

            var resultByLinq = Professores
                .Where(x =>
                    x.Nome.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    x.UltimoNome.Contains(search, StringComparison.OrdinalIgnoreCase));

            resultByLinq = orderAscendant
                ? resultByLinq.OrderBy(x => x.Nome).ThenBy(x => x.UltimoNome)
                : resultByLinq.OrderByDescending(x => x.Nome).ThenByDescending(x => x.UltimoNome);

            return resultByLinq;
        }

        public async Task<ProfessorViewModel> GetByIdAsync(int id)
        {
            foreach (var professor in Professores)
            {
                if (professor.Id == id)
                {
                    return professor;
                }
            }

            return null;
        }

        private static int _id = Professores.Max(x => x.Id);
        private int Id => Interlocked.Increment(ref _id);
        public async Task<ProfessorViewModel> CreateAsync(ProfessorViewModel professorViewModel)
        {
            professorViewModel.Id = Id;

            Professores.Add(professorViewModel);

            //TODO: auto-increment Id e atualizar para o retorno
            return professorViewModel;
        }

        public async Task<ProfessorViewModel> EditAsync(ProfessorViewModel professorViewModel)
        {
            foreach (var professor in Professores)
            {
                if (professor.Id == professorViewModel.Id)
                {
                    professor.Nome = professorViewModel.Nome;
                    professor.UltimoNome = professorViewModel.UltimoNome;
                    professor.UltimoNome = professorViewModel.UltimoNome;
                    professor.Contratacao = professorViewModel.Contratacao;
                    professor.QntdDisciplinas = professorViewModel.QntdDisciplinas;

                    return professor;
                }
            }

            return null;
        }

        public async Task DeleteAsync(int id)
        {
            ProfessorViewModel professorEncontrado = null;
            foreach (var professor in Professores)
            {
                if (professor.Id == id)
                {
                    professorEncontrado = professor;
                }
            }

            if (professorEncontrado != null)
            {
                Professores.Remove(professorEncontrado);
            }
        }
    }
}