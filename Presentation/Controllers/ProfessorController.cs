using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Data;
using Domain.Model.Models;
using Domain.Model.Interfaces.Services;

namespace Presentation.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly PresentationContext _context;
        private readonly IProfessorService _professorService;

        public ProfessorController(PresentationContext context, IProfessorService professorService)
        {
            _context = context;
        }

        // GET: Professor
        public async Task<IActionResult> Index()
        {
            return View(await _professorService.GetAllAsync(true, "Juli"));
        }

        // GET: Professor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professorModel = await _context
                .Professores
                .Include(x=>x.Alunos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professorModel == null)
            {
                return NotFound();
            }

            return View(professorModel);
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
        public async Task<IActionResult> Create([Bind("Id,Nome,UltimoNome,Contratacao,QntdDisciplinas")] ProfessorModel professorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(professorModel);
        }

        // GET: Professor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professorModel = await _context.Professores.FindAsync(id);
            if (professorModel == null)
            {
                return NotFound();
            }
            return View(professorModel);
        }

        // POST: Professor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,UltimoNome,Contratacao,QntdDisciplinas")] ProfessorModel professorModel)
        {
            if (id != professorModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorModelExists(professorModel.Id))
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
            return View(professorModel);
        }

        // GET: Professor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professorModel = await _context.Professores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professorModel == null)
            {
                return NotFound();
            }

            return View(professorModel);
        }

        // POST: Professor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professorModel = await _context.Professores.FindAsync(id);
            _context.Professores.Remove(professorModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessorModelExists(int id)
        {
            return _context.Professores.Any(e => e.Id == id);
        }
    }
}
