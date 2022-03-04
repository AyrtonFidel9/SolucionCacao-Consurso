using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SolucionCacao.Models;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace SolucionCacao.Controllers
{
    [Authorize]
    public class FichaController : Controller
    {
        private readonly db_concursoContext _context;

        public FichaController(db_concursoContext context)
        {
            _context = context;
        }

        // GET: Ficha
        [Authorize(Roles ="Admin, Tecnico, Propietario")]
        public async Task<IActionResult> Index()
        {
            var db_concursoContext = _context.Fichas.Include(f => f.IdTecnicoNavigation).Include(f => f.IdZonaNavigation);
            return View(await db_concursoContext.ToListAsync());
        }

        // GET: Ficha/Details/5
        [Authorize(Roles ="Admin, Tecnico, Propietario")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ficha = await _context.Fichas
                .Include(f => f.IdTecnicoNavigation)
                .Include(f => f.IdZonaNavigation)
                .FirstOrDefaultAsync(m => m.Id.Equals(id));
            if (ficha == null)
            {
                return NotFound();
            }

            return View(ficha);
        }

        // GET: Ficha/Create
        [Authorize(Roles = "Admin, Tecnico")]
        public IActionResult Create()
        {
            ViewData["IdTecnico"] = new SelectList(_context.Tecnicos, "Id", "Nombres");
            ViewData["IdZona"] = new SelectList(_context.ZonaEstudios, "Id", "Lugar");
            return View();
        }

        // POST: Ficha/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Tecnico")]
        public async Task<IActionResult> Create( [Bind("Id,IdTecnico,IdZona,idLineaFichasNavigation,Fecha, NombreFicha")] Ficha ficha)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //validacion de que los selects se encuentren con asignados
                    if (ficha.IdZona.Equals("Seleccione una Zona"))
                    {
                        TempData["mensaje"] = "<div class='alert alert-danger' role='alert'>Por favor, seleccione una zona de estudio</div>";
                        ViewData["IdTecnico"] = new SelectList(_context.Tecnicos, "Id", "Nombres", ficha.IdTecnico);
                        ViewData["IdZona"] = new SelectList(_context.ZonaEstudios, "Id", "Lugar", ficha.IdZona);
                        return View(ficha);
                    }

                    if(ficha.IdTecnico.Equals("Seleccione un técnico"))
                    {
                        TempData["mensaje"] = "<div class='alert alert-danger' role='alert'>Por favor, seleccione un técnico responsable de la zona de estudio</div>";
                        ViewData["IdTecnico"] = new SelectList(_context.Tecnicos, "Id", "Nombres", ficha.IdTecnico);
                        ViewData["IdZona"] = new SelectList(_context.ZonaEstudios, "Id", "Lugar", ficha.IdZona);
                        return View(ficha);
                    }

                    ficha.Id = Guid.NewGuid().ToString();
                    _context.Add(ficha);
                    await _context.SaveChangesAsync();
                    TempData["mensaje"] = "<div class='alert alert-success' role='alert'>La Ficha ha sido generada correctamente</div>";
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    TempData["mensaje"] = "<div class='alert alert-danger' role='alert'>Error al intentar generar la ficha</div>";
                    ViewData["IdTecnico"] = new SelectList(_context.Tecnicos, "Id", "Nombres", ficha.IdTecnico);
                    ViewData["IdZona"] = new SelectList(_context.ZonaEstudios, "Id", "Lugar", ficha.IdZona);
                    return View(ficha);
                }
            }
            ViewData["IdTecnico"] = new SelectList(_context.Tecnicos, "Id", "Nombres", ficha.IdTecnico);
            ViewData["IdZona"] = new SelectList(_context.ZonaEstudios, "Id", "Lugar", ficha.IdZona);
            return View(ficha);
        }

        // GET: Ficha/Edit/5
        [Authorize(Roles = "Admin, Tecnico")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var ficha = await _context.Fichas.FindAsync(id);
            if (ficha == null)
            {
                return NotFound();
            }
            ViewData["IdTecnico"] = new SelectList(_context.Tecnicos, "Id", "Nombres", ficha.IdTecnico);
            ViewData["IdZona"] = new SelectList(_context.ZonaEstudios, "Id", "Lugar", ficha.IdZona);
            return View(ficha);
        }

        // POST: Ficha/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Tecnico")]
        public async Task<IActionResult> Edit(string id, [Bind("Id,IdTecnico,IdZona,idLineaFichasNavigation,Fecha, NombreFicha")] Ficha ficha)
        {
            if (id != ficha.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                     //validacion de que los selects se encuentren con asignados
                    if (ficha.IdZona.Equals("Seleccione una Zona"))
                    {
                        TempData["mensaje"] = "<div class='alert alert-danger' role='alert'>Por favor, seleccione una zona de estudio</div>";
                        ViewData["IdTecnico"] = new SelectList(_context.Tecnicos, "Id", "Nombres", ficha.IdTecnico);
                        ViewData["IdZona"] = new SelectList(_context.ZonaEstudios, "Id", "Lugar", ficha.IdZona);
                        return View(ficha);
                    }

                    if(ficha.IdTecnico.Equals("Seleccione un técnico"))
                    {
                        TempData["mensaje"] = "<div class='alert alert-danger' role='alert'>Por favor, seleccione un técnico responsable de la zona de estudio</div>";
                        ViewData["IdTecnico"] = new SelectList(_context.Tecnicos, "Id", "Nombres", ficha.IdTecnico);
                        ViewData["IdZona"] = new SelectList(_context.ZonaEstudios, "Id", "Lugar", ficha.IdZona);    
                        return View(ficha);
                    }
                    _context.Update(ficha);
                    TempData["mensaje"] = "<div class='alert alert-success' role='alert'>La Ficha ha sido modificada correctamente</div>";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    TempData["mensaje"] = "<div class='alert alert-danger' role='alert'>Error al intentar modificar la ficha</div>";
                    if (!FichaExists(ficha.Id))
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
            ViewData["IdTecnico"] = new SelectList(_context.Tecnicos, "Id", "Nombres", ficha.IdTecnico);
            ViewData["IdZona"] = new SelectList(_context.ZonaEstudios, "Id", "Lugar", ficha.IdZona);
            return View(ficha);
        }

        // GET: Ficha/Delete/5
        [Authorize(Roles = "Admin, Tecnico")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ficha = await _context.Fichas
                .Include(f => f.IdTecnicoNavigation)
                .Include(f => f.IdZonaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ficha == null)
            {
                return NotFound();
            }

            return View(ficha);
        }

        // POST: Ficha/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var ficha = await _context.Fichas.FindAsync(id);
            try
            {
                _context.Fichas.Remove(ficha);
                await _context.SaveChangesAsync();
                TempData["mensaje"] = "<div class='alert alert-success' role='alert'>La Ficha ha sido eliminada correctamente</div>";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["mensaje"] = "<div class='alert alert-danger' role='alert'>Error al intentar modificar la ficha</div>";
                return View(ficha);
            }
        }
        private bool FichaExists(string id)
        {
            return _context.Fichas.Any(e => e.Id.Equals(id));
        }
    }
}
