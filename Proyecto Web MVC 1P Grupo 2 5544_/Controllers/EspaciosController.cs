using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_Web_MVC_1P_Grupo_2_5544_.Models;

namespace Proyecto_Web_MVC_1P_Grupo_2_5544_.Controllers
{
    public class EspaciosController : Controller
    {
        private readonly DBSsqlProyectoMVC_Grupo2 _context;

        public EspaciosController(DBSsqlProyectoMVC_Grupo2 context)
        {
            _context = context;
        }

        // GET: Espacios
        public async Task<IActionResult> Index()
        {
            var dBSsqlProyectoMVC_Grupo2 = _context.Espacios.Include(e => e.Vehiculo);
            return View(await dBSsqlProyectoMVC_Grupo2.ToListAsync());
        }

        // GET: Espacios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var espacios = await _context.Espacios
                .Include(e => e.Vehiculo)
                .FirstOrDefaultAsync(m => m.espacioId == id);
            if (espacios == null)
            {
                return NotFound();
            }

            return View(espacios);
        }

        // GET: Espacios/Create
        public IActionResult Create()
        {
            ViewData["vehiculoId"] = new SelectList(_context.Set<Vehiculo>(), "vehiculoId", "vehiculoId");
            return View();
        }

        // POST: Espacios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("espacioId,estadoEspacio,vehiculoId")] Espacios espacios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(espacios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["vehiculoId"] = new SelectList(_context.Set<Vehiculo>(), "vehiculoId", "vehiculoId", espacios.vehiculoId);
            return View(espacios);
        }

        // GET: Espacios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var espacios = await _context.Espacios.FindAsync(id);
            if (espacios == null)
            {
                return NotFound();
            }
            ViewData["vehiculoId"] = new SelectList(_context.Set<Vehiculo>(), "vehiculoId", "vehiculoId", espacios.vehiculoId);
            return View(espacios);
        }

        // POST: Espacios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("espacioId,estadoEspacio,vehiculoId")] Espacios espacios)
        {
            if (id != espacios.espacioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(espacios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspaciosExists(espacios.espacioId))
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
            ViewData["vehiculoId"] = new SelectList(_context.Set<Vehiculo>(), "vehiculoId", "vehiculoId", espacios.vehiculoId);
            return View(espacios);
        }

        // GET: Espacios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var espacios = await _context.Espacios
                .Include(e => e.Vehiculo)
                .FirstOrDefaultAsync(m => m.espacioId == id);
            if (espacios == null)
            {
                return NotFound();
            }

            return View(espacios);
        }

        // POST: Espacios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var espacios = await _context.Espacios.FindAsync(id);
            if (espacios != null)
            {
                _context.Espacios.Remove(espacios);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspaciosExists(int id)
        {
            return _context.Espacios.Any(e => e.espacioId == id);
        }
    }
}
