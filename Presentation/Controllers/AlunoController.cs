using Domain.Model.Interfaces.Services;
using Domain.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Presentation.Models;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoService _alunoService;
        private readonly IProfessorService _professorService;

        public AlunoController(IAlunoService alunoService, IProfessorService professorService)
        {

            _alunoService = alunoService;
            _professorService = professorService;
        }

        // GET: Aluno
        public async Task<IActionResult> Index(AlunoIndexViewModel alunoIndexRequest)
        {
            var alunoIndexViewModel = new AlunoIndexViewModel
            {
                Search = alunoIndexRequest.Search,
                OrderAscendant = alunoIndexRequest.OrderAscendant,
                Alunos = await _alunoService.GetAllAsync(alunoIndexRequest.OrderAscendant, alunoIndexRequest.Search)

            };

            return View(alunoIndexViewModel);
        }

        // GET: Aluno/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoModel = await _alunoService.GetByIdAsync(id.Value);

            if (alunoModel == null)
            {
                return NotFound();
            }

            var alunoViewModel = AlunoViewModel.From(alunoModel);
            return View(alunoViewModel);
        }

        // GET: Aluno/Create
        public async Task<IActionResult> Create()
        {
            await PreencherSelectProfessores();
            return View();
        }

        // POST: Aluno/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AlunoViewModel alunoViewModel)
        {
            if (!ModelState.IsValid)
            {
                await PreencherSelectProfessores(alunoViewModel.ProfessorId);
                
                return View(alunoViewModel);
            }
            var alunoModel = alunoViewModel.ToModel();
            var alunoCreated = await _alunoService.CreateAsync(alunoModel);
            return RedirectToAction(nameof(Details), new { id = alunoCreated.Id });
        }


        private async Task PreencherSelectProfessores(int? professorId = null)
        {
            var professores = await _professorService.GetAllAsync(true);

            ViewBag.Professores = new SelectList(
                professores,
                nameof(ProfessorModel.Id),
                nameof(ProfessorModel.Nome),
                professorId);
        }

        // GET: Aluno/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoModel = await _alunoService.GetByIdAsync(id.Value);
            if (alunoModel == null)
            {
                return NotFound();
            }
            
            await PreencherSelectProfessores(alunoModel.ProfessorId);

            var alunoViewModel = AlunoViewModel.From(alunoModel);
            return View(alunoViewModel);
        }

        // POST: Aluno/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AlunoViewModel alunoViewModel)
        {
            if (id != alunoViewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                
                await PreencherSelectProfessores(alunoViewModel.ProfessorId);

                return View(alunoViewModel);
            }
            var alunoModel = alunoViewModel.ToModel();
            try
            {
                await _alunoService.EditAsync(alunoModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await AlunoModelExists(alunoModel.Id)))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Aluno/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoModel = await _alunoService.GetByIdAsync(id.Value);
            if (alunoModel == null)
            {
                return NotFound();
            }

            var alunoViewModel = AlunoViewModel.From(alunoModel);
            return View(alunoViewModel);
        }

        // POST: Aluno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _alunoService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> AlunoModelExists(int id)
        {
            var aluno = await _alunoService.GetByIdAsync(id);

            var any = aluno != null;

            return any;
        }

        [AcceptVerbs("GET","POST")]
        public async Task<IActionResult> ValidarMatricula(string matricula, int id)
        {
            return await _alunoService.ValidarMatriculaAsync(matricula, id)
                ? Json(true)
                : Json($"Matricula {matricula} já está sendo utilizada.");
        }
    
    
    }


}

