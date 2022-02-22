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
    public class TecnicoController : Controller
    {
        private readonly db_concursoContext _context;

        public TecnicoController(db_concursoContext context)
        {
            _context = context;
        }

        // GET: Tecnico
        [Authorize(Roles ="Admin, Tecnico, Propietario")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tecnicos.ToListAsync());
        }

        // GET: Tecnico/Details/5
        [Authorize(Roles ="Admin, Tecnico, Propietario")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnico = await _context.Tecnicos
                .FirstOrDefaultAsync(m => m.Id.Equals(id));
            if (tecnico == null)
            {
                return NotFound();
            }

            return View(tecnico);
        }

        // GET: Tecnico/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tecnico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Nombres,Correo,Cargo,Contacto")] Tecnico tecnico)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    tecnico.Id = Guid.NewGuid().ToString();
                    _context.Add(tecnico);
                    await _context.SaveChangesAsync();
                    TempData["mensaje"] = "<div class='alert alert-success' role='alert'>El técnico "+tecnico.Nombres+" ha sido guardado correctamente</div>";
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    TempData["mensaje"] = "<div class='alert alert-danger' role='alert'>Ha ocurrido un error al crear un nuevo técnico, revise la información ingresada.</div>";
                    return View(tecnico);
                }
            }
            return View(tecnico);
        }

        // GET: Tecnico/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnico = await _context.Tecnicos.FindAsync(id);
            if (tecnico == null)
            {
                return NotFound();
            }
            return View(tecnico);
        }

        // POST: Tecnico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Nombres,Correo,Cargo,Contacto")] Tecnico tecnico)
        {
            if (!id.Equals(tecnico.Id))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tecnico);
                    TempData["mensaje"] = "<div class='alert alert-success' role='alert'>El técnico "+tecnico.Nombres+" ha sido modificado correctamente</div>";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    TempData["mensaje"] = "<div class='alert alert-danger' role='alert'>Ha ocurrido un error al modificar los datos del técnico "+tecnico.Nombres+"</div>";
                    if (!TecnicoExists(tecnico.Id))
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
            return View(tecnico);
        }

        // GET: Tecnico/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnico = await _context.Tecnicos
                .FirstOrDefaultAsync(m => m.Id.Equals(id));
            if (tecnico == null)
            {
                return NotFound();
            }

            return View(tecnico);
        }

        // POST: Tecnico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tecnico = await _context.Tecnicos.FindAsync(id);
            try
            {                
                _context.Tecnicos.Remove(tecnico);
                await _context.SaveChangesAsync();
                TempData["mensaje"] = "<div class='alert alert-success' role='alert'>El técnico "+tecnico.Nombres+" ha sido eliminado correctamente</div>";
            }
            catch
            {
                TempData["mensaje"] = "<div class='alert alert-danger' role='alert'>El técnico "+tecnico.Nombres+" no se ha podido eliminar</div>";
            }
            return RedirectToAction(nameof(Index));
        }

        private bool TecnicoExists(string id)
        {
            return _context.Tecnicos.Any(e => e.Id.Equals(id));
        }
    }
}
