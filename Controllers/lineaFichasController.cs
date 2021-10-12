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
    public class lineaFichasController : Controller
    {
        private readonly db_concursoContext _context;

        public lineaFichasController(db_concursoContext context)
        {
            _context = context;
        }

        // GET: lineaFichas
        public async Task<IActionResult> Index(string id)
        {
            var lineaFichasBus = _context.lineaFichas.Where(m => m.IdFicha.Equals(id));
            ViewData["IdFicha"] = id;
            if (lineaFichasBus == null)
            {
                return NotFound();
            }
            return View(await lineaFichasBus.ToListAsync());
        }

        // GET: lineaFichas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lineaFichas = await _context.lineaFichas
                .FirstOrDefaultAsync(m => m.Id == id);
            ViewData["IdFicha"] = lineaFichas.IdFicha;
            if (lineaFichas == null)
            {
                return NotFound();
            }

            return View(lineaFichas);
        }

        // GET: lineaFichas/Create
        public IActionResult Create(string id)
        {
            ViewData["Ficha"] = new SelectList(_context.Fichas.Where(t => t.Id.Equals(id)), "Id","NombreFicha");
            ViewData["IdFicha"] = id;
            return View();
        }

        // POST: lineaFichas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Arbol,Fruto,Incidencia,Severidad,Fecha,IdFicha")] lineaFichas lineaFichas)
        {
            if (ModelState.IsValid)
            {
                lineaFichas.Id = Guid.NewGuid().ToString();
                _context.Add(lineaFichas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new {@id = lineaFichas.IdFicha});
            }
            return View(lineaFichas);
        }

        // GET: lineaFichas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var lineaFichas = await _context.lineaFichas.FindAsync(id);
            ViewData["IdFicha"] = lineaFichas.IdFicha;
            ViewData["Ficha"] = new SelectList(_context.Fichas.Where(t => t.Id.Equals(lineaFichas.IdFicha)), "Id","NombreFicha");

            if (lineaFichas == null)
            {
                return NotFound();
            }
            return View(lineaFichas);
        }

        // POST: lineaFichas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Arbol,Fruto,Incidencia,Severidad,Fecha, IdFicha")] lineaFichas lineaFichas)
        {
            if (id != lineaFichas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lineaFichas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!lineaFichasExists(lineaFichas.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new {@id = lineaFichas.IdFicha});
            }
            return View(lineaFichas);
        }

        // GET: lineaFichas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lineaFichas = await _context.lineaFichas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lineaFichas == null)
            {
                return NotFound();
            }
            ViewData["IdFicha"] = lineaFichas.IdFicha;
            return View(lineaFichas);
        }

        // POST: lineaFichas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lineaFichas = await _context.lineaFichas.FindAsync(id);
            _context.lineaFichas.Remove(lineaFichas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool lineaFichasExists(string id)
        {
            return _context.lineaFichas.Any(e => e.Id == id);
        }
    }
}