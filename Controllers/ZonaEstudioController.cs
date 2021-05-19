using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SolucionCacao.Models;

namespace SolucionCacao.Controllers
{
    public class ZonaEstudioController : Controller
    {
        private readonly db_concursoContext _context;

        public ZonaEstudioController(db_concursoContext context)
        {
            _context = context;
        }

        // GET: ZonaEstudio
        public async Task<IActionResult> Index()
        {
            return View(await _context.ZonaEstudios.ToListAsync());
        }

        // GET: ZonaEstudio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zonaEstudio = await _context.ZonaEstudios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zonaEstudio == null)
            {
                return NotFound();
            }

            return View(zonaEstudio);
        }

        // GET: ZonaEstudio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ZonaEstudio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdPropietario,Lugar,Coordenadas,Cultivo,Densidad")] ZonaEstudio zonaEstudio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zonaEstudio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zonaEstudio);
        }

        // GET: ZonaEstudio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zonaEstudio = await _context.ZonaEstudios.FindAsync(id);
            if (zonaEstudio == null)
            {
                return NotFound();
            }
            return View(zonaEstudio);
        }

        // POST: ZonaEstudio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdPropietario,Lugar,Coordenadas,Cultivo,Densidad")] ZonaEstudio zonaEstudio)
        {
            if (id != zonaEstudio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zonaEstudio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZonaEstudioExists(zonaEstudio.Id))
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
            return View(zonaEstudio);
        }

        // GET: ZonaEstudio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zonaEstudio = await _context.ZonaEstudios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zonaEstudio == null)
            {
                return NotFound();
            }

            return View(zonaEstudio);
        }

        // POST: ZonaEstudio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zonaEstudio = await _context.ZonaEstudios.FindAsync(id);
            _context.ZonaEstudios.Remove(zonaEstudio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZonaEstudioExists(int id)
        {
            return _context.ZonaEstudios.Any(e => e.Id == id);
        }
    }
}
