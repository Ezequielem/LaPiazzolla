using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaPiazzolla.Data;
using LaPiazzolla.Models;
using LaPiazzolla.Models.LaPiazzollaViewModels;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LaPiazzolla.Controllers
{
    public class CursosController : Controller
    {
        private readonly LaPiazzollaContext _context;

        public CursosController(LaPiazzollaContext context)
        {
            _context = context;
        }

        // GET: Cursos
        public async Task<IActionResult> Index()
        {
            var cursos = _context.Cursos.Include(c=>c.Profesor).AsNoTracking();
            return View(await _context.Cursos.ToListAsync());
        }

        // GET: Cursos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos.Include(p=>p.Profesor).AsNoTracking()
                .FirstOrDefaultAsync(m => m.CursoId == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        public IActionResult Create()
        {
            listadoDeProfesores();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CursoId,Nombre,PrecioMensual,Descripcion,ProfesorId")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            listadoDeProfesores(curso.Profesor);
            return View(curso);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var curso = await _context.Cursos.AsNoTracking().FirstOrDefaultAsync(c=>c.CursoId==id);
            if (curso==null)
            {
                return NotFound();
            }
            listadoDeProfesores(curso.Profesor);
            return View(curso);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var cursoAModdificar = await _context.Cursos.FirstOrDefaultAsync(c=>c.CursoId==id);
            if (await TryUpdateModelAsync<Curso>(cursoAModdificar, "", c=>c.Nombre, c=>c.PrecioMensual, c=>c.Descripcion, c=>c.Profesor))
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists, " +
                "see your system administrator.");
                }
                return RedirectToAction(nameof(Index));
            }
            listadoDeProfesores(cursoAModdificar.Profesor);
            return View(cursoAModdificar);
        }

        public void listadoDeProfesores(object departamentoSeleccionado = null)
        {
            var consultaProfesores = from p in _context.Profesores
                                     orderby p.Nombre
                                     select p;
            ViewBag.Profesor = new SelectList(consultaProfesores.AsNoTracking(), "ProfesorId", "Nombre", departamentoSeleccionado);
        }

        // GET: Cursos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos.Include(p=>p.Profesor).AsNoTracking()
                .FirstOrDefaultAsync(m => m.CursoId == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoExists(int id)
        {
            return _context.Cursos.Any(e => e.CursoId == id);
        }
    }
}
