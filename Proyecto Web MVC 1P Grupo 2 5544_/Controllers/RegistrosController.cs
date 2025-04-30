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
    public class RegistrosController : Controller
    {
        private readonly DBSsqlProyectoMVC_Grupo2 _context;

        public RegistrosController(DBSsqlProyectoMVC_Grupo2 context)
        {
            _context = context;
        }

        // GET: Registros
        public async Task<IActionResult> Index()
        {
            var dBSsqlProyectoMVC_Grupo2 = _context.Registros.Include(r => r.Cliente).Include(r => r.Vehiculo);
            return View(await dBSsqlProyectoMVC_Grupo2.ToListAsync());
        }

        // GET: Registros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registros = await _context.Registros
                .Include(r => r.Cliente)
                .Include(r => r.Vehiculo)
                .FirstOrDefaultAsync(m => m.registroId == id);
            if (registros == null)
            {
                return NotFound();
            }

            return View(registros);
        }

        // GET: Registros/Create
        public IActionResult Create()
        {
            ViewData["clienteId"] = new SelectList(_context.Cliente, "clienteId", "clienteId");
            ViewData["vehiculoId"] = new SelectList(_context.Set<Vehiculo>(), "vehiculoId", "vehiculoId");
            return View();
        }

        // POST: Registros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("registroId,vehiculoId,clienteId,fechaEntrada,fechaSalida,pagoRealizado")] Registros registros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["clienteId"] = new SelectList(_context.Cliente, "clienteId", "clienteId", registros.clienteId);
            ViewData["vehiculoId"] = new SelectList(_context.Set<Vehiculo>(), "vehiculoId", "vehiculoId", registros.vehiculoId);
            return View(registros);
        }

        // GET: Registros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registros = await _context.Registros.FindAsync(id);
            if (registros == null)
            {
                return NotFound();
            }
            ViewData["clienteId"] = new SelectList(_context.Cliente, "clienteId", "clienteId", registros.clienteId);
            ViewData["vehiculoId"] = new SelectList(_context.Set<Vehiculo>(), "vehiculoId", "vehiculoId", registros.vehiculoId);
            return View(registros);
        }

        // POST: Registros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("registroId,vehiculoId,clienteId,fechaEntrada,fechaSalida,pagoRealizado")] Registros registros)
        {
            if (id != registros.registroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrosExists(registros.registroId))
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
            ViewData["clienteId"] = new SelectList(_context.Cliente, "clienteId", "clienteId", registros.clienteId);
            ViewData["vehiculoId"] = new SelectList(_context.Set<Vehiculo>(), "vehiculoId", "vehiculoId", registros.vehiculoId);
            return View(registros);
        }

        // GET: Registros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registros = await _context.Registros
                .Include(r => r.Cliente)
                .Include(r => r.Vehiculo)
                .FirstOrDefaultAsync(m => m.registroId == id);
            if (registros == null)
            {
                return NotFound();
            }

            return View(registros);
        }

        // POST: Registros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registros = await _context.Registros.FindAsync(id);
            if (registros != null)
            {
                _context.Registros.Remove(registros);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistrosExists(int id)
        {
            return _context.Registros.Any(e => e.registroId == id);
        }
    }
}
