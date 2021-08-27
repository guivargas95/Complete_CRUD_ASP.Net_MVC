using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presentation.Models;
using Presentation.Services;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class ProfessorController : Controller
    {
        
     
        private readonly IProfessorHttpService _professorHttpService;

        public ProfessorController(IProfessorHttpService professorHttpService)
        {
            
            
            _professorHttpService = professorHttpService;
        }

        // GET: Professor
        public async Task<IActionResult> Index(ProfessorIndexViewModel professorIndexRequest)
        {
            var professorIndexViewModel = new ProfessorIndexViewModel
            {
                Search = professorIndexRequest.Search,
                OrderAscendant = professorIndexRequest.OrderAscendant,
                Professores = await _professorHttpService.GetAllAsync(professorIndexRequest.OrderAscendant, professorIndexRequest.Search)

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

            var professorViewModel = await _professorHttpService.GetByIdAsync(id.Value);
                
            if (professorViewModel == null)
            {
                return NotFound();
            }

            

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

            var professorCreated = await _professorHttpService.CreateAsync(professorViewModel);

            return RedirectToAction(nameof(Details), new { id = professorCreated.Id });
        }

        // GET: Professor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professorViewModel = await _professorHttpService.GetByIdAsync(id.Value);
            if (professorViewModel == null)
            {
                return NotFound();
            }
            
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

            
            try
            {
                await _professorHttpService.EditAsync(professorViewModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await ProfessorModelExists(professorViewModel.Id)))
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

            var professorViewModel = await _professorHttpService.GetByIdAsync(id.Value);
            if (professorViewModel == null)
            {
                return NotFound();
            }

            
            return View(professorViewModel);
        }

        // POST: Professor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _professorHttpService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProfessorModelExists(int id)
        {
            var professor = await _professorHttpService.GetByIdAsync(id);

            var any = professor != null;

            return any;
        }
    }
}
