using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SolucionCacao.Models;

namespace SolucionCacao.Controllers
{
    [Authorize]
    public class PropietarioController : Controller
    {
        private readonly db_concursoContext _context;

        public PropietarioController(db_concursoContext context)
        {
            _context = context;
        }

        // GET: Propietario
        [Authorize(Roles ="Admin, Tecnico, Propietario")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Propietarios.ToListAsync());
        }

        // GET: Propietario/Details/5
        [Authorize(Roles ="Admin, Tecnico, Propietario")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propietario = await _context.Propietarios
                .FirstOrDefaultAsync(m => m.Id.Equals(id));
            if (propietario == null)
            {
                return NotFound();
            }

            return View(propietario);
        }

        // GET: Propietario/Create
        [Authorize(Roles ="Admin, Tecnico")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Propietario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin, Tecnico")]
        public async Task<IActionResult> Create([Bind("Nombre,Cedula,Celular")] Propietario propietario)
        {
            if (ModelState.IsValid)
            {
                propietario.Id = Guid.NewGuid().ToString();
                try
                {
                    _context.Add(propietario);
                    await _context.SaveChangesAsync();
                    TempData["mensaje"] = "<div class='alert alert-success' role='alert'>El propietario "+propietario.Nombre+" ha sido guardado correctamente</div>";
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    TempData["mensaje"] = "<div class='alert alert-danger' role='alert'>Error al intentar guardar los datos del propietario</div>";
                }
            }
            return View(propietario);
        }

        // GET: Propietario/Edit/5
        [Authorize(Roles ="Admin, Tecnico")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propietario = await _context.Propietarios.FindAsync(id);
            if (propietario == null)
            {
                return NotFound();
            }
            return View(propietario);
        }

        // POST: Propietario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin, Tecnico")]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Nombre,Cedula,Celular")] Propietario propietario)
        {
            if (id != propietario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propietario);
                    await _context.SaveChangesAsync();
                    TempData["mensaje"] = "<div class='alert alert-success' role='alert'>Los datos del propietario "+propietario.Nombre+" ha sido modificados correctamente</div>";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropietarioExists(propietario.Id))
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
            TempData["mensaje"] = "<div class='alert alert-danger' role='alert'>Error al modificar los datos del propietario</div>";
            return View(propietario);
        }

        // GET: Propietario/Delete/5
        [Authorize(Roles ="Admin, Tecnico")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propietario = await _context.Propietarios
                .FirstOrDefaultAsync(m => m.Id.Equals(id));
            if (propietario == null)
            {
                return NotFound();
            }

            return View(propietario);
        }

        // POST: Propietario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin, Tecnico")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var propietario = await _context.Propietarios.FindAsync(id);
            try
            {
                _context.Propietarios.Remove(propietario);
                await _context.SaveChangesAsync();
                TempData["mensaje"] = "<div class='alert alert-success' role='alert'>El propietario "+propietario.Nombre+" ha sido eliminado correctamente</div>";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["mensaje"] = "<div class='alert alert-danger' role='alert'>Ocurrio un error al eliminar el propietario</div>";
                return View(propietario);
            }
        }

        private bool PropietarioExists(string id)
        {
            return _context.Propietarios.Any(e => e.Id.Equals(id));
        }
    }
}
