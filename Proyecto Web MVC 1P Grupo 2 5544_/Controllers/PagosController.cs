using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Web_MVC_1P_Grupo_2_5544_.Models;

namespace Proyecto_Web_MVC_1P_Grupo_2_5544_.Controllers
{
    public class PagosController : Controller
    {
        private readonly DBSsqlProyectoMVC_Grupo2 _context;

        public PagosController(DBSsqlProyectoMVC_Grupo2 context)
        {
            _context = context;
        }

        // GET: Pagos
        public async Task<IActionResult> Index()
        {
            var pagos = _context.Pago.Include(p => p.Cliente).Include(p => p.Vehiculo);
            return View(await pagos.ToListAsync());
        }

        // GET: Pagos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pago = await _context.Pago
                .Include(p => p.Cliente)
                .Include(p => p.Vehiculo)
                .FirstOrDefaultAsync(m => m.pagoId == id);
            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }
    }
}
