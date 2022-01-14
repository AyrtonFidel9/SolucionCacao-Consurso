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
    public class ZonaEstudioController : Controller
    {
        private readonly db_concursoContext _context;

        public ZonaEstudioController(db_concursoContext context)
        {
            _context = context;
        }

        // GET: ZonaEstudio
        [Authorize(Roles ="Admin, Tecnico, Propietario")]
        public async Task<IActionResult> Index()
        {
            var lista_completa = _context.ZonaEstudios.Include(t => t.propietario);
            /*.Select(m => new ZonaEstudio(){
                Id = m.Id,
                IdPropietario = m.IdPropietario,
                Lugar = m.Lugar,
                Coordenadas = m.Coordenadas,
                Cultivo = m.Cultivo,            
                Densidad = m.Densidad,
                NombrePropietario = m.propietario.Nombre
            });*/

            return View(await lista_completa.ToListAsync());
        }
        
        [Authorize(Roles ="Admin, Tecnico, Propietario")]
        // GET: ZonaEstudio/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var lista_completa = _context.ZonaEstudios.Include(t => t.propietario);
            if (id == null)
            {
                return NotFound();
            }

            var zonaEstudio = await lista_completa
                .FirstOrDefaultAsync(m => m.Id.Equals(id));
            if (zonaEstudio == null)
            {
                return NotFound();
            }

            return View(zonaEstudio);
        }

        // GET: ZonaEstudio/Create
        [Authorize(Roles ="Admin, Tecnico")]
        public IActionResult Create()
        {
            var vm = new ZonaEstudio();
            vm._propietarios = _context.Propietarios.Select(a => new SelectListItem()
            {
                Value = a.Id,
                Text = a.Nombre
            }).ToList();
            return View(vm);
        }

        // POST: ZonaEstudio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin, Tecnico")]
        public async Task<IActionResult> Create([Bind("Id,IdPropietario,Lugar,Coordenadas,Cultivo,Densidad")] ZonaEstudio zonaEstudio)
        {
            zonaEstudio.Id = Guid.NewGuid().ToString();

            if (ModelState.IsValid)
            {
                if (zonaEstudio.IdPropietario != "Seleccione un propietario")
                {
                    _context.Add(zonaEstudio);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    recargarSelectPropietarios (ref zonaEstudio);
                }
            }
            else
            {
                recargarSelectPropietarios (ref zonaEstudio);
            }
            return View(zonaEstudio);
        }

        private void recargarSelectPropietarios (ref ZonaEstudio zonaEstudio)
        {
            zonaEstudio._propietarios = _context.Propietarios.Select(a => new SelectListItem()
                {
                    Value = a.Id,
                    Text = a.Nombre
                }).ToList();
        }

        // GET: ZonaEstudio/Edit/5
        [Authorize(Roles ="Admin, Tecnico")]
        public async Task<IActionResult> Edit(string id)
        {
            //var lista_completa = _context.ZonaEstudios.Include(t => t.propietario);
            if (id == null)
            {
                return NotFound();
            }

            var zonaEstudio = await _context.ZonaEstudios.FindAsync(id);
            if (zonaEstudio == null)
            {
                return NotFound();
            }
            zonaEstudio._propietarios = _context.Propietarios.Select(a => new SelectListItem()
            {
                Value = a.Id,
                Text = a.Nombre
            }).ToList();
            return View(zonaEstudio);
        }

        // POST: ZonaEstudio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin, Tecnico")]
        public async Task<IActionResult> Edit(string id, [Bind("Id,IdPropietario,Lugar,Coordenadas,Cultivo,Densidad")] ZonaEstudio zonaEstudio)
        {
            if (!id.Equals(zonaEstudio.Id))
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
        [Authorize(Roles ="Admin, Tecnico")]
        public async Task<IActionResult> Delete(string id)
        {
            var lista_completa = _context.ZonaEstudios.Include(t => t.propietario);
            if (id == null)
            {
                return NotFound();
            }

            var zonaEstudio = await lista_completa
                .FirstOrDefaultAsync(m => m.Id.Equals(id));
            if (zonaEstudio == null)
            {
                return NotFound();
            }

            return View(zonaEstudio);
        }

        // POST: ZonaEstudio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin, Tecnico")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var zonaEstudio = await _context.ZonaEstudios.FindAsync(id);
            _context.ZonaEstudios.Remove(zonaEstudio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZonaEstudioExists(string id)
        {
            return _context.ZonaEstudios.Any(e => e.Id.Equals(id));
        }
    }


}
