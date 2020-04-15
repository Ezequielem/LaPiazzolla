using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaPiazzolla.Data;
using LaPiazzolla.Models;

namespace LaPiazzolla.Controllers
{
    public class ProfesoresController : Controller
    {
        private readonly LaPiazzollaContext _context;

        public ProfesoresController(LaPiazzollaContext context)
        {
            _context = context;
        }

        // GET: Profesores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Profesores.ToListAsync());
        }

        // GET: Profesores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesores
                .FirstOrDefaultAsync(m => m.ProfesorId == id);
            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }

        // GET: Profesores/Create
        public IActionResult Create()
        {
            listaDeSexos();
            listaDeProvincias();
            //listaDeDepartamentos();
            //listaDeLocalidades();
            return View();
        }

        // POST: Profesores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfesorId,Nombre,Apellido,Dni,FechaDeNacimiento,Email,SexoId,Direccion")] Profesor profesor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profesor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            listaDeSexos(profesor.SexoId);
            listaDeProvincias(profesor.Direccion.Localidad.Departamento.ProvinciaId);
            //listaDeDepartamentos(profesor.Direccion.Localidad.DepartamentoId);
            //listaDeLocalidades(profesor.Direccion.LocalidadId);
            return View(profesor);
        }

        // GET: Profesores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesores.FindAsync(id);
            if (profesor == null)
            {
                return NotFound();
            }
            return View(profesor);
        }

        // POST: Profesores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfesorId,Nombre,Apellido,Dni,FechaDeNacimiento,Email")] Profesor profesor)
        {
            if (id != profesor.ProfesorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesorExists(profesor.ProfesorId))
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
            return View(profesor);
        }

        // GET: Profesores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesores
                .FirstOrDefaultAsync(m => m.ProfesorId == id);
            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }

        // POST: Profesores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profesor = await _context.Profesores.FindAsync(id);
            _context.Profesores.Remove(profesor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesorExists(int id)
        {
            return _context.Profesores.Any(e => e.ProfesorId == id);
        }

        public void listaDeSexos(object sexoSeleccionado = null)
        {
            var consultaSexo = from s in _context.Sexo
                               select s;
            ViewBag.SexoId = new SelectList(consultaSexo.AsNoTracking(), "SexoId", "Descripcion", sexoSeleccionado);
        }

        public void listaDeProvincias(object provinciaSeleccionada = null)
        {
            var consultaProvincia = from p in _context.Provincias
                                    orderby p.Nombre
                                    select p;
            ViewBag.ProvinciaId = new SelectList(consultaProvincia.AsNoTracking(), "ProvinciaId", "Nombre", provinciaSeleccionada);
                                    
        }

        public JsonResult obtenerDepartamentos(int ProvinciaId)
        {
            var consultaDepartamento = from d in _context.Departamentos
                                       where d.ProvinciaId == ProvinciaId
                                       orderby d.Nombre
                                       select d;
            return Json(consultaDepartamento);
        }

        //public void listaDeDepartamentos(object departamentoSeleccionado = null)
        //{
        //    var consultaDepartamento = from d in _context.Departamentos
        //                               where d.ProvinciaId == 1
        //                               orderby d.Nombre
        //                               select d;
        //    ViewBag.DepartamentoId = new SelectList(consultaDepartamento.AsNoTracking(), "DepartamentoId", "Nombre", departamentoSeleccionado);
        //}

        //public void listaDeLocalidades(object localidadesSeleccionadas = null)
        //{
        //    var consultaLocalidad = from l in _context.Localidades
        //                            orderby l.Nombre
        //                            select l;
        //    ViewBag.LocalidadId = new SelectList(consultaLocalidad.AsNoTracking(), "LocalidadId", "Nombre", localidadesSeleccionadas);
        //}
    }
}
