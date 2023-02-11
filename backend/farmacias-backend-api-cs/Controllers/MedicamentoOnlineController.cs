using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Farmacias.Data;
using Project.Models;

namespace Farmacias.Controllers
{
    public class MedicamentoOnlineController : Controller
    {
        private readonly FarmaciasContext _context;

        public MedicamentoOnlineController(FarmaciasContext context)
        {
            _context = context;
        }

        // GET: MedicamentoOnline
        public async Task<IActionResult> Index()
        {
            return View(await _context.MedicamentoOnline.ToListAsync());
        }

        // GET: MedicamentoOnline/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.MedicamentoOnline == null)
            {
                return NotFound();
            }

            var medicamentoOnline = await _context.MedicamentoOnline
                .FirstOrDefaultAsync(m => m.IntIdMedicamento == id);
            if (medicamentoOnline == null)
            {
                return NotFound();
            }

            return View(medicamentoOnline);
        }

        // GET: MedicamentoOnline/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MedicamentoOnline/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdMedicamento,DtFechaDescarga,StrCantidad,StrConcentracion,StrDescripcion,StrEan,StrImagen,StrLaboratorio,StrMarca,StrNombre,StrPaginaProducto,StrPrecioUnitario,StrPresentacion,StrPrincipioActivo,StrRegistroInvima,IntIdPortalOrigen")] MedicamentoOnline medicamentoOnline)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicamentoOnline);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicamentoOnline);
        }

        // GET: MedicamentoOnline/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.MedicamentoOnline == null)
            {
                return NotFound();
            }

            var medicamentoOnline = await _context.MedicamentoOnline.FindAsync(id);
            if (medicamentoOnline == null)
            {
                return NotFound();
            }
            return View(medicamentoOnline);
        }

        // POST: MedicamentoOnline/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdMedicamento,DtFechaDescarga,StrCantidad,StrConcentracion,StrDescripcion,StrEan,StrImagen,StrLaboratorio,StrMarca,StrNombre,StrPaginaProducto,StrPrecioUnitario,StrPresentacion,StrPrincipioActivo,StrRegistroInvima,IntIdPortalOrigen")] MedicamentoOnline medicamentoOnline)
        {
            if (id != medicamentoOnline.IntIdMedicamento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicamentoOnline);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicamentoOnlineExists(medicamentoOnline.IntIdMedicamento))
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
            return View(medicamentoOnline);
        }

        // GET: MedicamentoOnline/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.MedicamentoOnline == null)
            {
                return NotFound();
            }

            var medicamentoOnline = await _context.MedicamentoOnline
                .FirstOrDefaultAsync(m => m.IntIdMedicamento == id);
            if (medicamentoOnline == null)
            {
                return NotFound();
            }

            return View(medicamentoOnline);
        }

        // POST: MedicamentoOnline/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.MedicamentoOnline == null)
            {
                return Problem("Entity set 'FarmaciasContext.MedicamentoOnline'  is null.");
            }
            var medicamentoOnline = await _context.MedicamentoOnline.FindAsync(id);
            if (medicamentoOnline != null)
            {
                _context.MedicamentoOnline.Remove(medicamentoOnline);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicamentoOnlineExists(long? id)
        {
            return _context.MedicamentoOnline.Any(e => e.IntIdMedicamento == id);
        }
    }
}
