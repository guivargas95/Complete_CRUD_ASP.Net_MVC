using Domain.Model.Interfaces.Services;
using Domain.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presentation.Models;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class ProfessorController : Controller
    {
        
        private readonly IProfessorService _professorService;

        public ProfessorController(IProfessorService professorService)
        {
            
            _professorService = professorService;
        }

        // GET: Professor
        public async Task<IActionResult> Index(ProfessorIndexViewModel professorIndexRequest)
        {
            var professorIndexViewModel = new ProfessorIndexViewModel
            {
                Search = professorIndexRequest.Search,
                OrderAscendant = professorIndexRequest.OrderAscendant,
                Professores = await _professorService.GetAllAsync(professorIndexRequest.OrderAscendant, professorIndexRequest.Search)

            };
            
            
            return View(professorIndexViewModel);
        }

        // GET: Professor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professorModel = await _professorService.GetByIdAsync(id.Value);
                
            if (professorModel == null)
            {
                return NotFound();
            }

            var professorViewModel = ProfessorViewModel.From(professorModel);

            return View(professorViewModel);
        }

        // GET: Professor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Professor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProfessorViewModel professorViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(professorViewModel);
            }

            var professorModel = professorViewModel.ToModel();
            var professorCreated = await _professorService.CreateAsync(professorModel);

            return RedirectToAction(nameof(Details), new { id = professorCreated.Id });
        }

        // GET: Professor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professorModel = await _professorService.GetByIdAsync(id.Value);
            if (professorModel == null)
            {
                return NotFound();
            }
            var professorViewModel = ProfessorViewModel.From(professorModel);
            return View(professorViewModel);
        }

        // POST: Professor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProfessorViewModel professorViewModel)
        {
            if (id != professorViewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(professorViewModel);
            }

            var professorModel = professorViewModel.ToModel();
            try
            {
                await _professorService.EditAsync(professorModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await ProfessorModelExists(professorModel.Id)))
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

        // GET: Professor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professorModel = await _professorService.GetByIdAsync(id.Value);
            if (professorModel == null)
            {
                return NotFound();
            }

            var professorViewModel = ProfessorViewModel.From(professorModel);
            return View(professorViewModel);
        }

        // POST: Professor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _professorService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProfessorModelExists(int id)
        {
            var professor = await _professorService.GetByIdAsync(id);

            var any = professor != null;

            return any;
        }
    }
}
